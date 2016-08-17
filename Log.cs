// Copyright (c) 2016 SolarLiner - Part of the TLE Orbiter Sceneraio Generator (TLEOSG)
using System;
using System.Collections.Generic;
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

            sb.AppendLine(" **");
            sb.AppendLine(" *  TLE Scenario Generator");
            sb.AppendLine(" *   Log file: " + DateTime.Now.ToShortDateString());
            sb.AppendLine(" **");
            sb.AppendLine();

            File.WriteAllText(FileName, sb.ToString());
        }

        internal static void Write(string[] v, int pad)
        {
            string Date = DateTime.Now.ToLongTimeString();
            pad += Date.Length;
            StringBuilder sb = new StringBuilder();
            for( int i = 0; i < v.Length; i++ )
            {
                if( i == 0 ) sb.AppendLine(string.Format("[{0}] {1}", Date, v[0].Trim()));
                else sb.AppendLine("".PadLeft(pad) + v[i].Trim());
            }

            File.AppendAllText(FileName, sb.ToString());
        }

        internal static void Write(string v)
        {
            Write(v.Split('\n'), 3);
        }

        internal static void WriteError(Exception e)
        {
            List<string> lines = new List<string>();
            lines.Add("[ERROR] " + e.Message);
            lines.AddRange(e.StackTrace.Split('\n'));

            Write(lines.ToArray(), 11);
        }
    }
}