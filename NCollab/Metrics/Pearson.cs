using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab.Interfaces;

namespace NCollab.Metrics
{
    public class Pearson<TPref> : IMetric<TPref> where TPref : class, IPreference
    {
        public double Compute(List<TPref> val1, List<TPref> val2, IEqualityComparer<TPref> equalityComparer)
        {
            var dict1 = val1.ToDictionary(k => k, v => v, equalityComparer);
            var dict2 = val2.ToDictionary(k => k, v => v, equalityComparer);
            var intesection = val1.Intersect(val2, equalityComparer).ToList();
            var sum1 = 0.0D;
            var sum2 = 0.0D;
            var sumSq1 = 0.0D;
            var sumSq2 = 0.0D;
            var sumMul = 0.0D;
            foreach (var pref in intesection)
            {
                sum1 += dict1[pref].Compute();
                sum2 += dict2[pref].Compute();

                sumSq1 += Math.Pow(dict1[pref].Compute(), 2);
                sumSq2 += Math.Pow(dict2[pref].Compute(), 2);

                sumMul += dict1[pref].Compute() * dict2[pref].Compute();
            }

            var num = (sum1*sum2)/intesection.Count;
            throw new NotImplementedException();
        }
    }
}
