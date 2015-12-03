using AOSP;
using System;
using System.Windows.Forms;

namespace TLEOrbiter
{
    public partial class MainForm : Form
    {
        public OrbScenario SCN { get; set; }
        public string ScnName { get; set; }

        public MainForm()
        {
            Log.Write("new MainForm()");
            InitializeComponent();
            SCN = new OrbScenario();
            SCN.Camera = new OrbCamera(OrbCamera.CameraMode.GlassCockpit);
            SCN.MJD = -1d;
            SCN.Description = "Imported TLE with TLE Scenario Generator";
            ScnName = "Imported TLE";
        }

        private void BT_EditScenario_Click(object sender, EventArgs e)
        {
            ScenarioProperties SP = new ScenarioProperties();
            SP.MJD = SCN.MJD;
            SP.ScenarioName = ScnName;
            SP.Description = SCN.Description;

            if (SP.ShowDialog() != DialogResult.OK) return;
            //SP.ShowDialog();
            SCN.MJD = SP.MJD;
            SCN.Description = SP.Description;
            ScnName = SP.ScenarioName;
        }

        private void BT_ImportTLE_Click(object sender, EventArgs e)
        {
            ImportTLE IT = new ImportTLE();

            if (IT.ShowDialog() != DialogResult.OK) return;

            string[] content = IT.TLEData.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < content.Length; i += 3)
            {
                string tname = content[i + 0].Trim() + '\n';
                string tle = tname;
                tle += content[i + 1] + '\n';
                tle += content[i + 2];

                ListViewItem lvi = LV_Ships.Items.Add(tname);
                OrbVessel OV = new OrbVessel("ShuttlePB", tle.Split('\n'));
                lvi.SubItems.Add(OV.Name);
                lvi.SubItems.Add(OV.VesselClass);
                lvi.SubItems.Add(tle);
                lvi.Tag = OV;
                lvi.Checked = true;
            }
        }

        private void GenerateSCN()
        {
            // Populate ships
            SCN.Ships.Clear();
            foreach (ListViewItem lvi in LV_Ships.Items)
            {
                if (!lvi.Checked) continue;
                SCN.Ships.Add((OrbVessel)lvi.Tag);
            }
        }

        private void BT_SelectNone_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in LV_Ships.Items)
            {
                lvi.Checked = false;
            }
        }
        private void BT_SelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in LV_Ships.Items)
            {
                lvi.Checked = true;
            }
        }
        private void BT_InvertSelection_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in LV_Ships.Items)
            {
                lvi.Checked = !lvi.Checked;
            }
        }

        private void BT_GenScn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Orbiter Scenario|*.scn";
            sfd.FileName = ScnName.Trim().Replace(' ', '_') + ".scn";

            if (sfd.ShowDialog() != DialogResult.OK) return;
            GenerateSCN();
            System.IO.File.WriteAllText(sfd.FileName, SCN.RenderScenario());
        }

        private void LV_Ships_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem lvi = LV_Ships.SelectedItems[0];
            lvi.Checked = !lvi.Checked;

            VesselEdit VE = new VesselEdit();
            VE.Vessel = (OrbVessel)lvi.Tag;
            VE.TLE = lvi.SubItems[3].Text.Split('\n');

            if (VE.ShowDialog() != DialogResult.OK) return;

            lvi.SubItems[1].Text = VE.OrbiterName;
            lvi.SubItems[2].Text = VE.VesselClass;
            lvi.SubItems[3].Text = string.Join("\n", VE.TLE);
            lvi.Text = VE.TLE[0];
            lvi.Tag = VE.Vessel;
        }

        private void LL_Settings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            (new SettingsForm()).ShowDialog();
        }
    }
}
