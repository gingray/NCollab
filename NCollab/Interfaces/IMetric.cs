using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCollab.Interfaces
{
    public interface IMetric
    {
        double Compute(PreferencesBase val1, PreferencesBase val2);
    }
}
