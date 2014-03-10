using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab;

namespace NCollabSandbox
{
    public class UserEqualityComparer : IEqualityComparer<User>
    {
        public bool Equals(User x, User y)
        {
            return x.Name.Equals(y.Name);
        }

        public int GetHashCode(User obj)
        {
            return obj.GetHashCode();
        }
    }
}
