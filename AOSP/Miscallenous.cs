using System;
using System.Globalization;

namespace AOSP
{
    /// <summary>
    /// Trown when vessel status is incorrect to do the operation.
    /// </summary>
    public class WrongVesselStatusError : System.Exception
    {
        public WrongVesselStatusError() { }

        public WrongVesselStatusError(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public static class Misc
    {
        public static double GetMJD(DateTime dt)
        {
            int Y = dt.Year;
            int M = dt.Month;
            int D = dt.Day;

            if (M <= 2) { Y -= 1; M += 12; }

            int A = Y / 100;
            int B = A / 4;
            int C = 2 - A + B;
            int E = (int)Math.Floor(365.25 * (Y + 4716));
            int F = (int)Math.Floor(30.6001 * (M + 1));
            double jd = C + D + E + F - 1524.5;

            double day_remainder = dt.TimeOfDay.TotalDays;

            jd += day_remainder;

            return jd - 2400000.5;
        }

        public static DateTime GetTime(double MJD)
        {
            return new DateTime(1858, 11, 17).AddDays(MJD);
        }
    }
}