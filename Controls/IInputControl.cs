// Copyright (c) 2016 SolarLiner - Part of the TLE Orbiter Sceneraio Generator (TLEOSG)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TLEOrbiter.Controls
{
    interface IInputControl<T>
    {
        T Value { get; set; }
        string Name { get; set; }
    }
}
