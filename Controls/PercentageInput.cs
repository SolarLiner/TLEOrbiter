// Copyright (c) 2016 SolarLiner - Part of the TLE Orbiter Sceneraio Generator (TLEOSG)
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TLEOrbiter.Controls
{
    public partial class PercentageInput: UserControl, IInputControl<double>
    {
        public PercentageInput()
        {
            InitializeComponent();
        }

        public double Value
        {
            get
            {
                return (double)NUD_Value.Value / 100d;
            }

            set
            {
                NUD_Value.Value = (decimal)(value * 100d);
            }
        }

        public new string Name
        {
            get { return LB_Name.Text.Split(':')[0]; }
            set { LB_Name.Text = value + ": "; }
        }
    }
}
