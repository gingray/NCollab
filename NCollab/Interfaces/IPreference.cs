using System;
using System.Collections;
using System.Collections.Generic;

namespace NCollab.Interfaces
{
    public interface IPreference<T> : IComputable,IEqualityComparer<T> where T : new()
    {

    }
}
