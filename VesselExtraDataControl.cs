using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TLEOrbiter
{
    public partial class VesselExtraDataControl : UserControl
    {
        public VesselExtraDataControl()
        {
            InitializeComponent();
        }

        public KeyValuePair<string, string> Item
        {
            get
            {
                return new KeyValuePair<string, string>(TB_Key.Text, TB_Value.Text);
            }
            set
            {
                TB_Key.Text = value.Key;
                TB_Value.Text = value.Value;
            }
        }
    }
}
