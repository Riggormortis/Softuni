﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IRobot
    {
        string Model { get; } //<- higher level of encapsulation

        string Id { get; }
    }
}
