using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab;

namespace NCollabSandbox
{
    public class CustomPreferenceEqualityComparer : IEqualityComparer<PreferencesBase>
    {
        public bool Equals(PreferencesBase x, PreferencesBase y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode(PreferencesBase obj)
        {
            throw new NotImplementedException();
        }
    }
}
