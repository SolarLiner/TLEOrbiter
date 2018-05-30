// Copyright (c) 2016 SolarLiner - Part of the TLE Orbiter Sceneraio Generator (TLEOSG)
using System;
using System.Net;
using System.Windows.Forms;

namespace TLEOrbiter
{
    public partial class ImportTLE : Form
    {
        public ImportTLE()
        {
            InitializeComponent();
        }
        public string TLEData { get; private set; }

        private void BT_OK_Click(object sender, EventArgs e)
        {
            WebClient WC = new WebClient();
            try
            {
                Log.Write("Getting URL: " + TB_TleUrl.Text);
                TLEData = WC.DownloadString(TB_TleUrl.Text);
            }
            catch(Exception ex)
            {
                Log.WriteError(ex);
                EP_Validator.SetError(TB_TleUrl, ex.Message);
                return;
            }

            DialogResult = DialogResult.OK;
            //this.Close();
        }

        private void TB_TleUrl_TextChanged(object sender, EventArgs e)
        {
            if (!Uri.IsWellFormedUriString(TB_TleUrl.Text, UriKind.Absolute))
                EP_Validator.SetError(TB_TleUrl, "Must enter a validate URL");
        }

        private void BT_BrowseLocalFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                TB_TleUrl.Text = new Uri(openFileDialog.FileName).AbsoluteUri;
            }
        }
    }
}
