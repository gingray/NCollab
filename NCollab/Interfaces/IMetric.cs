using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCollab.Interfaces
{
    public interface IMetric<TPref>
    {
        double Compute(List<TPref> val1, List<TPref> val2, IEqualityComparer<TPref> equalityComparer );
    }
}
