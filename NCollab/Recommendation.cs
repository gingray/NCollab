﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab.Interfaces;

namespace NCollab
{
    public abstract class Recommendation<TMainObject, TPref>
        where TPref : class, IPreference<TPref>, new()
        where TMainObject : class, IMainObject<TMainObject, TPref>, new()
    {
        private readonly IMetric<TPref> _metric;
        private readonly IEqualityComparer<TPref> _preferenceEqualityComparer;
        private readonly IEqualityComparer<TMainObject> _userEqualityComparer;

        protected Recommendation(IMetric<TPref> metric)
        {
            _metric = metric;
            _preferenceEqualityComparer = new TPref();
            _userEqualityComparer = new TMainObject();
        }

        public abstract List<TMainObject> LoadData();

        public Dictionary<TPref, double> GetRecomendations(TMainObject mainObject, List<TMainObject> others)
        {
            var similiar = GetSimilars(mainObject, others);
            var result = new Dictionary<TPref, double>(_preferenceEqualityComparer);
            var resultCount = new Dictionary<TPref, double>(_preferenceEqualityComparer);
            foreach (var other in similiar.Keys)
            {
                if (_userEqualityComparer.Equals(mainObject, other))
                    continue;
                foreach (var otherPref in other.Preferenceses.Except(mainObject.Preferenceses, _preferenceEqualityComparer))
                {
                    if (!result.ContainsKey(otherPref))
                    {
                        result[otherPref] = 0.0D;
                        resultCount[otherPref] = 0;
                    }
                    result[otherPref] += otherPref.Compute() * similiar[other];
                    resultCount[otherPref] += similiar[other];
                }
            }
            foreach (var d in new List<TPref>(result.Keys))
            {
                result[d] /= resultCount[d];
            }
            return result;
        }

        public Dictionary<TMainObject, double> GetSimilars(TMainObject master, List<TMainObject> others)
        {
            var result = new Dictionary<TMainObject, double>(_userEqualityComparer);
            foreach (var preferencese in master.Preferenceses)
            {
                foreach (var other in others.Where(other => !_userEqualityComparer.Equals(master, other)).Where(other => other.Preferenceses.Contains(preferencese, _preferenceEqualityComparer)))
                {
                    result[other] = CalculateSimiliar(master, other);
                }
            }
            return result;
        }

        public Dictionary<TPref, List<TMainObject>> GroupMainObjectsByPreference(List<TMainObject> mainObjects)
        {
            var result = new Dictionary<TPref, List<TMainObject>>(_preferenceEqualityComparer);
            foreach (var mainObject in mainObjects)
            {
                foreach (var preference in mainObject.Preferenceses)
                {
                    if (!result.ContainsKey(preference))
                    {
                        result[preference] = new List<TMainObject>();
                    }
                    result[preference].Add(mainObject);
                }
            }
            return result;
        }

        protected double CalculateSimiliar(TMainObject mainObject, TMainObject otherObjects)
        {
            return _metric.Compute(mainObject.Preferenceses, otherObjects.Preferenceses);
        }
    }
}
