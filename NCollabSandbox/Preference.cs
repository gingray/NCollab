using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab.Interfaces;

namespace NCollabSandbox
{
    public class Preference : IPreference
    {
        public string FilmName { get; set; }
        public double Compute()
        {
            throw new NotImplementedException();
        }
    }
}
