using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCollab.Interfaces
{
    public interface IUser<TPref> where TPref : IPreference
    {
        List<TPref> Preferenceses { get; }
    }
}
