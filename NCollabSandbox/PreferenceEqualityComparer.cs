using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab;

namespace NCollabSandbox
{
    public class PreferenceEqualityComparer : IEqualityComparer<Preference>
    {
        public bool Equals(Preference x, Preference y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode(Preference obj)
        {
            throw new NotImplementedException();
        }
    }
}
