using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab;

namespace NCollabSandbox
{
    public class CustomKeyEqualityComparer : IEqualityComparer<UserBase>
    {
        public bool Equals(UserBase x, UserBase y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode(UserBase obj)
        {
            throw new NotImplementedException();
        }
    }
}
