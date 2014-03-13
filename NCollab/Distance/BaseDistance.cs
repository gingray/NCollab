using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab.Interfaces;

namespace NCollab.Distance
{
    public class BaseDistance<TPref> where TPref : IPreference<TPref>,new()
    {
    }
}
