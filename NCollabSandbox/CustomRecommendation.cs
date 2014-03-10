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
        public CustomRecommendation(IMetric metric, IEqualityComparer<PreferencesBase> preferenceEqualityComparer, IEqualityComparer<UserBase> keyEqualityComparer) : base(metric, preferenceEqualityComparer, keyEqualityComparer)
        {
        }

        public override List<UserBase> LoadData()
        {
            var user = new CustomUser();
            throw new NotImplementedException();
        }
    }
}
