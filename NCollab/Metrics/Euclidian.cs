using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab.Interfaces;

namespace NCollab.Metrics
{
    public class Euclidian<TPref> : IMetric<TPref> where TPref : IPreference
    {
        public double Compute(TPref val1, TPref val2)
        {
            return 1.0D / (1 + Math.Sqrt(Math.Pow(val1.Compute() - val2.Compute(), 2)));
        }
    }
}
