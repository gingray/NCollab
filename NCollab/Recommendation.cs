using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab.Interfaces;

namespace NCollab
{
    public abstract class Recommendation<TUser, TPref>
        where TPref : IPreference
        where TUser : IUser<TPref>
    {
        private readonly IMetric<TPref> _metric;
        private readonly IEqualityComparer<TPref> _preferenceEqualityComparer;
        private readonly IEqualityComparer<TUser> _userEqualityComparer;

        protected Recommendation(IMetric<TPref> metric, IEqualityComparer<TPref> preferenceEqualityComparer, IEqualityComparer<TUser> userEqualityComparer)
        {
            _metric = metric;
            _preferenceEqualityComparer = preferenceEqualityComparer;
            _userEqualityComparer = userEqualityComparer;
        }

        public abstract List<TUser> LoadData();

        public List<TPref> GetRecomendations(TUser userBase, List<TUser> others)
        {
            var simliarCoef = new Dictionary<TUser, double>(_userEqualityComparer);
            foreach (var preferencese in userBase.Preferenceses)
            {
                foreach (var other in others.Where(other => !_userEqualityComparer.Equals(userBase, other)).Where(other => other.Preferenceses.Contains(preferencese, _preferenceEqualityComparer)))
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

        protected virtual double CalculateSimiliar(TUser mainUserBase, TUser otherUserBase)
        {
            var prefs = mainUserBase.Preferenceses.Intersect(otherUserBase.Preferenceses,_preferenceEqualityComparer).ToList();
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
