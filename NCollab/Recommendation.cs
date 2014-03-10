using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab.Interfaces;

namespace NCollab
{
    public abstract class Recommendation<TVal, TPref>
        where TPref : IPreference
    {
        private readonly IMetric _metric;
        private readonly IEqualityComparer<PreferencesBase> _preferenceEqualityComparer;
        private readonly IEqualityComparer<UserBase> _keyEqualityComparer;

        protected Recommendation(IMetric metric, IEqualityComparer<PreferencesBase> preferenceEqualityComparer, IEqualityComparer<UserBase> keyEqualityComparer)
        {
            _metric = metric;
            _preferenceEqualityComparer = preferenceEqualityComparer;
            _keyEqualityComparer = keyEqualityComparer;
        }

        public abstract List<UserBase> LoadData();

        public List<PreferencesBase> GetRecomendations(UserBase userBase, List<UserBase> others)
        {
            var simliarCoef = new Dictionary<UserBase, double>(_keyEqualityComparer);
            foreach (var preferencese in userBase.Preferenceses)
            {
                foreach (var other in others.Where(other => userBase != other).Where(other => other.Preferenceses.Contains(preferencese, _preferenceEqualityComparer)))
                {
                    simliarCoef[other] = CalculateSimiliar(userBase, other);
                }
            }
            var result =
                simliarCoef.ToList()
                    .OrderByDescending(c => c.Value)
                    .Select(s => s.Key.Preferenceses.Except(userBase.Preferenceses))
                    .SelectMany(s => s)
                    .ToList();
            return result;
        }

        protected virtual double CalculateSimiliar(UserBase mainUserBase, UserBase otherUserBase)
        {
            var prefs = mainUserBase.Preferenceses.Intersect(otherUserBase.Preferenceses, _preferenceEqualityComparer).ToList();
            var result = 0.0D;
            foreach (var preferencese in prefs)
            {
                var main = mainUserBase.Preferenceses.First(c => _preferenceEqualityComparer.Equals(c, preferencese));
                var other = otherUserBase.Preferenceses.First(c => _preferenceEqualityComparer.Equals(c, preferencese));
                result += _metric.Compute(main, other);
            }
            return result / prefs.Count;
        }
    }
}
