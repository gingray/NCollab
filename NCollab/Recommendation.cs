using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab.Interfaces;

namespace NCollab
{
    public abstract class Recommendation<TUser, TPref>
        where TPref : class, IPreference
        where TUser : class, IUser<TPref>
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
            throw new NotImplementedException();
        }

        public Dictionary<TUser, double> GetSimilars(TUser master, List<TUser> others)
        {
            var result = new Dictionary<TUser, double>(_userEqualityComparer);
            foreach (var preferencese in master.Preferenceses)
            {
                foreach (var other in others.Where(other => !_userEqualityComparer.Equals(master, other)).Where(other => other.Preferenceses.Contains(preferencese, _preferenceEqualityComparer)))
                {
                    result[other] = CalculateSimiliar(master, other);
                }
            }
            return result;
        }

        protected double CalculateSimiliar(TUser mainUserBase, TUser otherUserBase)
        {
            return _metric.Compute(mainUserBase.Preferenceses, otherUserBase.Preferenceses,_preferenceEqualityComparer);
        }
    }
}
