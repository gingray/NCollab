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
        private readonly IMetric<TPref> _metric;
        private readonly IEqualityComparer<Preferences<TPref>> _preferenceEqualityComparer;
        private readonly IEqualityComparer<User<TVal, TPref>> _keyEqualityComparer;

        protected Recommendation(IMetric<TPref> metric, IEqualityComparer<Preferences<TPref>> preferenceEqualityComparer, IEqualityComparer<User<TVal, TPref>> keyEqualityComparer)
        {
            _metric = metric;
            _preferenceEqualityComparer = preferenceEqualityComparer;
            _keyEqualityComparer = keyEqualityComparer;
        }

        public abstract List<User<TVal, TPref>> LoadData();

        public List<Preferences<TPref>> GetRecomendations(User<TVal, TPref> user, List<User<TVal, TPref>> others)
        {
            var simliarCoef = new Dictionary<User<TVal, TPref>, double>(_keyEqualityComparer);
            foreach (var preferencese in user.Preferenceses)
            {
                foreach (var other in others.Where(other => user != other).Where(other => other.Preferenceses.Contains(preferencese, _preferenceEqualityComparer)))
                {
                    simliarCoef[other] = CalculateSimiliar(user, other);
                }
            }
            var result =
                simliarCoef.ToList()
                    .OrderByDescending(c => c.Value)
                    .Select(s => s.Key.Preferenceses.Except(user.Preferenceses))
                    .SelectMany(s => s)
                    .ToList();
            return result;
        }

        protected virtual double CalculateSimiliar(User<TVal, TPref> mainUser, User<TVal, TPref> otherUser)
        {
            var prefs = mainUser.Preferenceses.Intersect(otherUser.Preferenceses, _preferenceEqualityComparer).ToList();
            var result = 0.0D;
            foreach (var preferencese in prefs)
            {
                var main = mainUser.Preferenceses.First(c => _preferenceEqualityComparer.Equals(c, preferencese));
                var other = otherUser.Preferenceses.First(c => _preferenceEqualityComparer.Equals(c, preferencese));
                result += _metric.Compute(main.Value, other.Value);
            }
            return result / prefs.Count;
        }
    }
}
