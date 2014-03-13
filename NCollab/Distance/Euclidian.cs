using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab.Interfaces;

namespace NCollab.Metrics
{
    public class Euclidian<TPref> : IMetric<TPref> where TPref: class, IPreference<TPref>,new()
    {
        public double Compute(List<TPref> val1, List<TPref> val2)
        {
            var sum = 0.0d;
            foreach (var pref in val1)
            {
                var item = val2.Find(c => c.Equals(pref));
                if(item == null)
                    continue;               
                sum += Math.Pow(pref.Compute() - item.Compute(), 2);
            }

            return 1.0D / (1 + Math.Sqrt(sum));
        }
    }
}
