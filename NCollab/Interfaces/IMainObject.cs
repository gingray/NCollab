using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCollab.Interfaces
{
    public interface IMainObject<TMainObject, TPref> : IEqualityComparer<TMainObject>
        where TPref : IPreference<TPref>, new()
        where TMainObject : new()
    {
        List<TPref> Preferenceses { get; }
    }
}
