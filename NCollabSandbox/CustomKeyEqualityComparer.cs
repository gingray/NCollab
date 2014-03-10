using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCollab;

namespace NCollabSandbox
{
    public class CustomKeyEqualityComparer : IEqualityComparer<User<CustomUser, CustomPreference>>
    {
        public bool Equals(User<CustomUser, CustomPreference> x, User<CustomUser, CustomPreference> y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode(User<CustomUser, CustomPreference> obj)
        {
            throw new NotImplementedException();
        }
    }
}
