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
    public partial class VectorInput: UserControl, IInputControl<Vector3>
    {
        public Vector3 Value
        {
            get
            {
                return new Vector3((double)NUD_X.Value, (double)NUD_Y.Value, (double)NUD_Z.Value);
            }
            set
            {
                NUD_X.Value = (decimal)value.x;
                NUD_Y.Value = (decimal)value.y;
                NUD_Z.Value = (decimal)value.z;
            }
        }

        public new string Name
        {
            get { return LB_Name.Text.Split(':')[0]; }
            set { LB_Name.Text = value + ": "; }
        }

        public VectorInput()
        {
            InitializeComponent();
        }
    }
}
