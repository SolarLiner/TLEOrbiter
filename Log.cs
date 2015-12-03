using System;
using System.IO;
using System.Text;

namespace TLEOrbiter
{
    internal static class Log
    {
        internal const string FileName = "TLEOrbiter.log";

        internal static void Init()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(" ***************************");
            sb.AppendLine(" *  TLE Scenario Generator *");
            sb.AppendLine(" *   Log file: " + DateTime.Now.ToShortDateString() + "  *");
            sb.AppendLine(" ***************************");
            sb.AppendLine();

            File.WriteAllText(FileName, sb.ToString());
        }

        internal static void Write(string v)
        {
            string Date = DateTime.Now.ToLongTimeString();
            File.AppendAllText(FileName, string.Format("[{0}] {1}\n", Date, v));
        }
        internal static void Write(Exception e)
        {
            WriteError(e.Message);
            foreach(string line in e.StackTrace.Split('\n'))
            {
                WriteError(line);
            }
        }

        internal static void WriteError(string v)
        {
            Write("[ERROR] " + v);
        }
    }
}