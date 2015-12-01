using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TLEOrbiter
{
    public partial class DateChange : Form
    {
        public DateChange()
        {
            InitializeComponent();
            //PickedTime = DateTime.UtcNow;
        }
        public DateChange(DateTime DT)
        {
            InitializeComponent();
            PickedTime = DT;
        }
        public DateChange(double MJD)
        {
            InitializeComponent();
            PickedTime = AOSP.Misc.GetTime(MJD);
        }

        private DateTime _dt;
        private bool _updating = false;
        public DateTime PickedTime
        {
            get
            {
                return _dt;
            }
            set
            {
                if (_updating) return;
                if (value == _dt) return;
                _dt = value;
                _updating = true;

                NU_Hours.Value = _dt.Hour;
                NU_Minutes.Value = _dt.Minute;
                NU_Seconds.Value = _dt.Second;
                MC_Calendar.SetDate(_dt);

                NU_MJD.Value = (decimal)PickedMJD;
                _updating = false;
            }
        }
        public double PickedMJD { get { return AOSP.Misc.GetMJD(_dt); } }

        private void UpdatePickedTime()
        {
            if (_updating) return;
            DateTime d = MC_Calendar.SelectionStart.Date.Add(new TimeSpan((int)NU_Hours.Value, (int)NU_Minutes.Value, (int)NU_Seconds.Value));

            if (PickedTime != d) PickedTime = d;
        }

        private void NU_ValueChanged(object sender, EventArgs e)
        {
            UpdatePickedTime();
        }

        private void MC_Calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            UpdatePickedTime();
        }

        private void NU_MJD_ValueChanged(object sender, EventArgs e)
        {
            if (_updating) return;
            PickedTime = AOSP.Misc.GetTime((double)NU_MJD.Value);
        }

        private void BT_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void BT_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
