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
            Log.Init();
            Log.Write("Starting application");

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.EnableVisualStyles();

            Settings.Load();

            Application.CurrentCulture = Settings.Lang;
            System.Threading.Thread.CurrentThread.CurrentUICulture = Settings.Lang;
            Application.CurrentCulture.NumberFormat = System.Globalization.CultureInfo.InvariantCulture.NumberFormat; // To parse point separated decimals
            Log.Write("Culture: " + Application.CurrentCulture.EnglishName);
            Log.Write("Culture: Decimal point: " + Application.CurrentCulture.NumberFormat.CurrencyDecimalSeparator);

            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            Settings.Save();
            Log.Write("Bye!");
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Log.Write((Exception)e.ExceptionObject);
            if (e.IsTerminating) Log.WriteError("Fatal error, terminating...");
        }
    }
}
