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
    public partial class TextInput: UserControl, IInputControl<string>
    {
        public TextInput()
        {
            InitializeComponent();
        }

        public string Value
        {
            get
            {
                return TB_Value.Text.Trim();
            }

            set
            {
                TB_Value.Text = value.Trim();
            }
        }

        public new string Name
        {
            get { return LB_Name.Text.Split(':')[0]; }
            set { LB_Name.Text = value + ": "; }
        }
    }
}
