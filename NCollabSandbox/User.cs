using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab;
using NCollab.Interfaces;

namespace NCollabSandbox
{
    public class User : IMainObject<User, Preference>
    {
        public string Name { get; set; }
        public List<Preference> Preferenceses { get; set; }

        public bool Equals(User x, User y)
        {
            return x.Name.Equals(y.Name, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(User obj)
        {
            return 0;
        }
    }
}
