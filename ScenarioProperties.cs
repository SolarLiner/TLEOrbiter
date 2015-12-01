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
    public partial class ScenarioProperties : Form
    {
        public ScenarioProperties()
        {
            InitializeComponent();
        }

        private DateTime dt;
        public double MJD { get; set; }
        public string ScenarioName { get; set; }
        public string Description { get; set; }


        private void ScenarioProperties_Load(object sender, EventArgs e)
        {
            if (MJD == -1d) CB_UseSysTime.Checked = true;
            else dt = AOSP.Misc.GetTime(MJD);

            TB_ScnName.Text = ScenarioName;
            richTextBox1.Text = Description;
        }

        private void CB_UseSysTime_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_UseSysTime.Checked) BT_ChangeDate.Enabled = false;
            else BT_ChangeDate.Enabled = true;

            MJD = CB_UseSysTime.Checked ? -1 : AOSP.Misc.GetMJD(dt);
        }

        private void BT_ChangeDate_Click(object sender, EventArgs e)
        {
            DateChange DC = new DateChange();
            DC.PickedTime = dt;

            if (DC.ShowDialog() != DialogResult.OK) return;
            MJD = DC.PickedMJD;
            dt = DC.PickedTime;
            DialogResult = DialogResult.None;
        }

        private void TB_ScnName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TB_ScnName.Text))
                ER_Verifier.SetError(TB_ScnName, "Name cannot be empty.");
            else
                ScenarioName = TB_ScnName.Text;
        }

        private void BT_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BT_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            Description = richTextBox1.Text;
        }
    }
}
