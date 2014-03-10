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
            return x.FilmName.Equals(y.FilmName);
        }

        public int GetHashCode(Preference obj)
        {
            return obj.FilmName.GetHashCode();
        }
    }
}
