using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab;
using NCollab.Interfaces;

namespace NCollabSandbox
{
    public class CustomRecommendation : Recommendation<User, Preference>
    {
        public CustomRecommendation(IMetric<Preference> metric, IEqualityComparer<Preference> preferenceEqualityComparer, IEqualityComparer<User> userEqualityComparer) : base(metric, preferenceEqualityComparer, userEqualityComparer)
        {
        }

        public override List<User> LoadData()
        {
            throw new NotImplementedException();
        }
    }
}
