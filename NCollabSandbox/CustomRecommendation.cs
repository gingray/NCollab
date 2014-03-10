using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab;
using NCollab.Interfaces;

namespace NCollabSandbox
{
    public class CustomRecommendation : Recommendation<CustomUser, CustomPreference>
    {
        public CustomRecommendation(IMetric<CustomPreference> metric, IEqualityComparer<Preferences<CustomPreference>> preferenceEqualityComparer, IEqualityComparer<User<CustomUser, CustomPreference>> keyEqualityComparer) : base(metric, preferenceEqualityComparer, keyEqualityComparer)
        {
        }

        public override List<User<CustomUser, CustomPreference>> LoadData()
        {
            var user = new User<CustomUser, CustomPreference>();
            throw new NotImplementedException();
        }
    }
}
