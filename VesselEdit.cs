// Copyright (c) 2016 SolarLiner - Part of the TLE Orbiter Sceneraio Generator (TLEOSG)
using AOSP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TLEOrbiter.Controls;

namespace TLEOrbiter
{
    public partial class VesselEdit: Form
    {
        string[] _tle;
        Dictionary<Guid, string> vessels;

        public OrbVessel Vessel { get; set; }
        public string[] TLE
        {
            get
            {
                return _tle;
            }
            set
            {
                _tle = value;
                this.Text = "Vessel Edit - " + value[0];
                this.TB_TLEData.Text = value[1] + '\n' + value[2];
            }
        }

        public string OrbiterName => Vessel.Name;
        public string VesselClass => Vessel.VesselClass;

        public VesselEdit()
        {
            InitializeComponent();

            vessels = PluginManager.PluginManager.GetVesselNames();
            foreach(KeyValuePair<Guid, string> kvp in vessels )
                CB_VesselName.Items.Add(kvp.Value);
        }

        private void VesselEdit_Load(object sender, EventArgs e)
        {
            TB_VesselName.Text = Vessel.Name;
        }

        private void CB_VesselName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selVessel = (string)CB_VesselName.SelectedItem;
            Guid ID = vessels.First(x => x.Value == selVessel).Key;

            var userData = PluginManager.PluginManager.GetUserInputValues(ID);
            int i=0;

            GB_VesselData.Controls.Clear();
            Log.Write("VesselEdit: Clearing controls");

            // Loc (7, 20)
            // Size (457, 27)
            foreach(KeyValuePair<string, PluginManager.OrbVesselScenarioDataType> kvp in userData )
            {
                UserControl control = new UserControl();
                var loc = new Point (7, 20 + 27*i);
                var size = new Size(457, 27);

                switch( kvp.Value )
                {
                    case PluginManager.OrbVesselScenarioDataType.STRING:
                        var ti = new TextInput();
                        ti.Name = kvp.Key;
                        ti.Value = string.Empty;
                        Log.Write(string.Format("VesselEdit: Adding '{0}' as TextInput", kvp.Key));
                        control = ti;
                        break;
                    case PluginManager.OrbVesselScenarioDataType.INT:
                    case PluginManager.OrbVesselScenarioDataType.DOUBLE:
                        var di = new DoubleInput();
                        di.Name = kvp.Key;
                        di.Value = 0d;
                        Log.Write(string.Format("VesselEdit: Adding '{0}' as DoubleInput", kvp.Key));
                        control = di;
                        break;
                    case PluginManager.OrbVesselScenarioDataType.VECTOR:
                        var vi = new VectorInput();
                        vi.Name = kvp.Key;
                        vi.Value = new Vector3(0, 0, 0);
                        Log.Write(string.Format("VesselEdit: Adding '{0}' as VectorInput", kvp.Key));
                        control = vi;
                        break;
                    case PluginManager.OrbVesselScenarioDataType.PERCENTAGE:
                        var pi = new PercentageInput();
                        pi.Name = kvp.Key;
                        pi.Value = 1d;
                        Log.Write(string.Format("VesselEdit: Adding '{0}' as PercentageInput", kvp.Key));
                        control = pi;
                        break;
                }

                control.Location = loc;
                control.Size = size;
                control.Tag = kvp.Value;

                GB_VesselData.Controls.Add(control);

                i++;
            }
        }

        private void BT_OK_Click(object sender, EventArgs e)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();

            foreach( UserControl uc in GB_VesselData.Controls )
            {
                switch( (PluginManager.OrbVesselScenarioDataType)uc.Tag )
                {
                    case PluginManager.OrbVesselScenarioDataType.STRING:
                        var ti = (TextInput)uc;
                        data.Add(ti.Name, ti.Value);
                        break;
                    case PluginManager.OrbVesselScenarioDataType.INT:
                        var ii = (DoubleInput)uc;
                        data.Add(ii.Name, (int)Math.Round(ii.Value));
                        break;
                    case PluginManager.OrbVesselScenarioDataType.DOUBLE:
                        var di = (DoubleInput)uc;
                        data.Add(di.Name, di.Value);
                        break;
                    case PluginManager.OrbVesselScenarioDataType.VECTOR:
                        var vi = (VectorInput)uc;
                        data.Add(vi.Name, vi.Value);
                        break;
                    case PluginManager.OrbVesselScenarioDataType.PERCENTAGE:
                        var pi = (PercentageInput)uc;
                        var val = pi.Value>1.0? 1.0 : (pi.Value<0.0? 0.0 : pi.Value);
                        data.Add(pi.Name, val);
                        break;
                }
            }

            var context = new OrbVesselContext(data, TLE, Vessel);

            string selVessel = (string)CB_VesselName.SelectedItem;
            Guid ID = vessels.First(x => x.Value == selVessel).Key;

            var vessel = PluginManager.PluginManager.ProcessVesselData(context, ID);
            vessel.Name = TB_VesselName.Text.Trim().Replace(" ", "_");
            vessel.ProcessTLE(_tle);

            DialogResult = DialogResult.OK;
        }

        class OrbVesselContext: PluginManager.IOrbVesselContext
        {
            Dictionary<string, object> _vesselData;
            string[] _tle;
            OrbVessel _vessel;

            public OrbVesselContext(Dictionary<string, object> data, string[] tle, OrbVessel Vessel)
            {
                _vesselData = data;
                _tle = tle;
                _vessel = Vessel;
            }

            public Dictionary<string, object> InputData => _vesselData;

            public string[] RawTLE => _tle;

            public OrbVessel Vessel => _vessel;
        }
    }
}
