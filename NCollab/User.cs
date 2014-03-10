using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab.Interfaces;

namespace NCollab
{
    public class User<TVal, TPref>
        where TPref : IPreference
    {
        public TVal Value;
        public List<Preferences<TPref>> Preferenceses;
    }
}
