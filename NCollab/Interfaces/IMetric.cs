using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCollab.Interfaces
{
    public interface IMetric<TPref> where TPref : IPreference
    {
        double Compute(TPref val1, TPref val2);
    }
}
