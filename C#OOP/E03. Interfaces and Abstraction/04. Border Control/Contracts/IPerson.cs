using BorderControl.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IPerson
    {

        string Name { get; } //<- higher level of encapsulation

        int Age { get; }

        string Id { get; }
    }
}
