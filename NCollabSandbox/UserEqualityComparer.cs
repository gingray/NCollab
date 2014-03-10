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
            throw new NotImplementedException();
        }

        public int GetHashCode(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
