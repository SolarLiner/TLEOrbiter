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
    public partial class VesselEdit : Form
    {
        private List<VesselExtraDataControl> VEDCList;
        private string[] _tle;
        public string[] TLE { get { return _tle; }
            set
            {
                this.Text += " - " + value[0];
                TB_TleName.Text = value[0];
                TB_TLE.Text = value[1] + '\n' + value[2];
                _tle = value;
            }
        }
        public AOSP.OrbVessel Vessel { get; set; }
        public string OrbiterName { get { return Vessel.Name; } }
        public string VesselClass { get { return Vessel.VesselClass; } }

        public VesselEdit()
        {
            InitializeComponent();
            string _dir = (Settings.OrbiterPath + "\\Config\\Vessels").Replace(@"\\", @"\");
            try
            {
                foreach (string path in System.IO.Directory.GetFiles(_dir))
                {
                    CB_VesselClass.Items.Add(System.IO.Path.GetFileNameWithoutExtension(path));
                }
            }
            catch { }

            VEDCList = new List<VesselExtraDataControl>();
        }

        private void VesselEdit_Load(object sender, EventArgs e)
        {
            TB_OrbiterName.Text = Vessel.Name;
            CB_VesselClass.Text = Vessel.VesselClass;

            /*//Vessel.Extra.Add("XPDR", "466"); // Doesn't work yet
            //Vessel.Extra.Add("AFCMODE", "0 0");

            int x = 5, y = 15;
            foreach (KeyValuePair<string, string> kvp in Vessel.Extra)
            {
                VesselExtraDataControl vedc = new VesselExtraDataControl();
                vedc.Item = kvp;
                vedc.Location = new Point(x, y);
                vedc.Size = new Size(420, 25);
                y += 25;

                GB_VesselData.Controls.Add(vedc);
            }*/
        }

        private void BT_OK_Click(object sender, EventArgs e)
        {
            string[] content = TB_TLE.Text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            _tle[1] = content[0];
            _tle[2] = content[1];

            Vessel.Name = TB_OrbiterName.Text.Trim().Replace(' ', '_');
            Vessel.VesselClass = CB_VesselClass.Text;

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BT_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
