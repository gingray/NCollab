using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab;

namespace NCollabSandbox
{
    public class CustomPreferenceEqualityComparer : IEqualityComparer<Preferences<CustomPreference>>
    {
        public bool Equals(Preferences<CustomPreference> x, Preferences<CustomPreference> y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode(Preferences<CustomPreference> obj)
        {
            throw new NotImplementedException();
        }
    }
}
