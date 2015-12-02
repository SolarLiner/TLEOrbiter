using System;
using System.Windows.Forms;

namespace TLEOrbiter
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            Settings.Load();

            Application.CurrentCulture = Settings.Lang;
            System.Threading.Thread.CurrentThread.CurrentUICulture = Settings.Lang;
            Application.CurrentCulture.NumberFormat = System.Globalization.CultureInfo.InvariantCulture.NumberFormat; // To parse point separated decimals

            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            Settings.Save();
        }
    }
}
