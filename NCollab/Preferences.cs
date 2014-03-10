using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab.Interfaces;

namespace NCollab
{
    public class Preferences<TPref> where TPref : IPreference
    {
        public TPref Value;
    }
}
