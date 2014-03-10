using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab.Interfaces;

namespace NCollab
{
    public abstract class PreferencesBase : IPreference
    {
        public abstract double Compute();
    }
}
