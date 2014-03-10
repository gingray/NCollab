using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab.Interfaces;

namespace NCollab
{
    public abstract class Recommendation<TMainObject, TPref>
        where TPref : class, IPreference
        where TMainObject : class, IUser<TPref>
    {
        private readonly IMetric<TPref> _metric;
        private readonly IEqualityComparer<TPref> _preferenceEqualityComparer;
        private readonly IEqualityComparer<TMainObject> _userEqualityComparer;

        protected Recommendation(IMetric<TPref> metric, IEqualityComparer<TPref> preferenceEqualityComparer, IEqualityComparer<TMainObject> userEqualityComparer)
        {
            _metric = metric;
            _preferenceEqualityComparer = preferenceEqualityComparer;
            _userEqualityComparer = userEqualityComparer;
        }

        public abstract List<TMainObject> LoadData();

        public List<TPref> GetRecomendations(TMainObject userBase, List<TMainObject> others)
        {
            throw new NotImplementedException();
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

        protected double CalculateSimiliar(TMainObject mainObject, TMainObject otherObjects)
        {
            return _metric.Compute(mainObject.Preferenceses, otherObjects.Preferenceses,_preferenceEqualityComparer);
        }
    }
}
