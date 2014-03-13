using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab.Interfaces;

namespace NCollabSandbox
{
    public class Preference : IPreference<Preference>
    {
        public string FilmName { get; set; }
        public double Rating { get; set; }
        public double Compute()
        {
            return Rating;
        }

        public bool Equals(Preference x, Preference y)
        {
            return x.FilmName.Equals(y.FilmName, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(Preference obj)
        {
            return 0;
        }
    }
}
