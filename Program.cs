using System;
using System.Windows.Forms;

namespace TLEOrbiter
{
    static class Program
    {
        static bool ShowMessageBox = false;
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.Init();
            Log.Write("Starting application");

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.EnableVisualStyles();

            Settings.Load();

            //Application.CurrentCulture = Settings.Lang;
            Application.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = Settings.Lang;
            //Application.CurrentCulture.NumberFormat = System.Globalization.CultureInfo.InvariantCulture.NumberFormat; // To parse point separated decimals
            Log.Write("Culture: " + Application.CurrentCulture.EnglishName);
            Log.Write("Culture: Decimal point: " + Application.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);

            Application.SetCompatibleTextRenderingDefault(false);

            ShowMessageBox = true;
            Application.Run(new MainForm());
            ShowMessageBox = false;

            Settings.Save();
            Log.Write("Bye!");
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            Log.Write(ex);
            if (e.IsTerminating) Log.WriteError("Fatal error, terminating...");

            if (ShowMessageBox)
            {
                if(e.IsTerminating)
                    MessageBox.Show(ex.Message + "\nThis is a fatal error and the app will close. Please send TLEOrbiter.log as a bug", "TLE Scenario Generator fatal error", MessageBoxButtons.OK);
                else
                    MessageBox.Show(ex.Message + "\nPlease send TLEOrbiter.log as a bug after you close the app.", "TLE Scenario Generator error", MessageBoxButtons.OK);
            }

        }
    }
}
