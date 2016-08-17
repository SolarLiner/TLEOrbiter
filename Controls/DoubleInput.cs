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
    public partial class DoubleInput: UserControl, IInputControl<double>
    {
        public DoubleInput()
        {
            InitializeComponent();

            NUD_Value.Minimum = decimal.MinValue;
            NUD_Value.Maximum = decimal.MaxValue;
        }

        public double Value
        {
            get
            {
                return (double)NUD_Value.Value;
            }

            set
            {
                NUD_Value.Value = (decimal)value;
            }
        }

        public new string Name
        {
            get { return LB_Name.Text.Split(':')[0]; }
            set { LB_Name.Text = value + ": "; }
        }
    }
}
