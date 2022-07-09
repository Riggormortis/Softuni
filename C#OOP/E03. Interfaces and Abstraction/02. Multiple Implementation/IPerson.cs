using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    //Convention -> most of the interfaces should be public
    //define public side of our class -> props (getters, setters), methods
    public interface IPerson
    {
        //Define public structure of the class

        string Name { get; set; }

        int Age { get; set; }
    }
}
