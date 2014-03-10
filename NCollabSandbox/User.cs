using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab;
using NCollab.Interfaces;

namespace NCollabSandbox
{
    public class User : IUser<Preference>
    {
        public string Name { get; set; }
        public List<Preference> Preferenceses { get; set; }
    }
}
