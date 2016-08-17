// Copyright (c) 2016 SolarLiner - Part of the TLE Orbiter Sceneraio Generator (TLEOSG)
using AOSP;
using System;
using System.Collections.Generic;
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
            List<string> errorVessels = new List<string>();

            if (IT.ShowDialog() != DialogResult.OK) return;

            string[] content = IT.TLEData.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < content.Length; i += 3)
            {
                string tname = content[i + 0].Trim();
                string strTle = tname + '\n';
                strTle += content[i + 1] + '\n';
                strTle += content[i + 2];

                ListViewItem lvi = LV_Ships.Items.Add(tname);
                try
                {
                    OrbVessel OV = new OrbVessel("ShuttlePB", strTle.Split('\n'));
                    lvi.SubItems.Add(OV.Name);
                    lvi.SubItems.Add(OV.VesselClass);
                    lvi.SubItems.Add(strTle);
                    lvi.Tag = OV;
                    lvi.Checked = true;
                } catch (Exception ex )
                {
                    Log.Write(string.Format("[ERROR] Could not add '{0}':", tname));
                    Log.WriteError(ex);
                    errorVessels.Add(tname);
                    lvi.Remove();
                }
            }

            MessageBox.Show("These entries could not be added:\n" + string.Join("\n", errorVessels.ToArray())
                            + "\n\nPlease check the logs.", "Error importing TLE", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void PopulateSCN()
        {
            // Populate ships
            Log.Write("MainForm.PopulateSCN()");
            SCN.Ships.Clear();
            SCN.MJD = SCN.HasMJD ? SCN.MJD : Misc.GetMJD(DateTime.UtcNow);
            foreach( ListViewItem lvi in LV_Ships.Items )
            {
                if( !lvi.Checked ) continue;
                Log.Write("Ship: " + (lvi.Tag as OrbVessel).Name);
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
            PopulateSCN();
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
