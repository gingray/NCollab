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
            var mean1 = intesection.Sum(s => dict1[s].Compute()) / intesection.Count;
            var mean2 = intesection.Sum(s => dict2[s].Compute()) / intesection.Count;
            var sum1 = intesection.Sum(pref => (dict1[pref].Compute() - mean1)*(dict2[pref].Compute() - mean2));
            var sum2 =
                Math.Sqrt(intesection.Sum(pref => (Math.Pow(dict1[pref].Compute() - mean1, 2))) * intesection.Sum(pref => Math.Pow(dict2[pref].Compute() - mean2, 2)));
            if (sum2 == 0.0D)
                return 0.0D;
            return sum1/sum2;
        }
    }
}
