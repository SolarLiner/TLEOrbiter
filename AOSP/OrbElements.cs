// Copyright (c) 2016 SolarLiner - Part of the TLE Orbiter Sceneraio Generator (TLEOSG)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOSP
{
    /// <summary>
    /// Handles the Elements for Orbiter.
    /// </summary>
    public struct OrbElements
    {
        double a;
        double e;
        double i;
        double omega;
        double w;
        double lrd;
        double reference;

        /// <summary>
        /// Semi-Major Axis [m]
        /// </summary>
        public double SMA { get { return a; } set { a = value; } }

        /// <summary>
        /// Eccentricity
        /// </summary>
        public double Ecc { get { return e; } set { e = value; } }

        /// <summary>
        /// Inclination [°]
        /// </summary>
        public double Inc { get { return i; } set { i = value; } }

        /// <summary>
        /// Longitude of Ascending Node [°]
        /// </summary>
        public double AscNode { get { return omega; } set { omega = value; } }

        /// <summary>
        /// Longitude of Periapsis [°]
        /// </summary>
        public double PeLong { get { return w; } set { w = value; } }

        /// <summary>
        /// Mean Longitude [°]
        /// </summary>
        public double MeanLong { get { return lrd; } set { lrd = value; } }

        /// <summary>
        /// Reference date in MJD format
        /// </summary>
        public double ReferenceMJD { get { return reference; } set { reference = value; } }


        /// <summary>Constructor for elements in Orbiter.</summary>
        /// <param name="sma">Semi-Major axis in meters.</param>
        /// <param name="ecc">Eccentricity.</param>
        /// <param name="inc">Inclination in degrees.</param>
        /// <param name="asc">Longitude of Ascending node in degrees.</param>
        /// <param name="pelng">Periapsis longitude in degrees.</param>
        /// <param name="meanlng">Mean longitude at reference date.</param>
        /// <param name="refdate">Reference date in MJD.</param>
        public OrbElements(double sma, double ecc, double inc, double asc, double pelng, double meanlng, double refdate)
        {
            a = sma;
            e = ecc;
            i = inc;
            omega = asc;
            w = pelng;
            lrd = meanlng;
            reference = refdate;
        }

        /// <summary>
        /// Initializes an OrbElements given TLE lines.
        /// </summary>
        /// <param name="tle">TLE lines. Indices 1 &amp; 2 are used (since 0 is the name of the ship)</param>
        [Obsolete("Converting TLE through OrbElements does not make use of SDP4/SGP4 integration. The results will be in ELEMENTS form. Use OrbVessel.ProcessTLE instead.")]
        public OrbElements(string[] tle)
        {
            this = FromTLE(tle[1], tle[2]);
        }

        /// <summary>
        /// Converts a TLE line into Orbiter Elements. Special thanks to Ajaja for the help ;)
        /// </summary>
        /// <param name="line1">First TLE line.</param>
        /// <param name="line2">Second TLE line.</param>
        [Obsolete("Converting TLE through OrbElements does not make use of SDP4/SGP4 integration. The results will be in ELEMENTS form.")]
        static public OrbElements FromTLE(string line1, string line2)
        {
            string tle1;
            string[] tle2 = new string[6];

            tle1 = line1.Substring(18, 14);
            double tm = double.Parse(tle1);

            tle2[0] = line2.Substring(26, 7);
            double e = double.Parse("0." + tle2[0]);

            tle2[1] = line2.Substring(8, 8);
            double eq_i = double.Parse(tle2[1]);

            tle2[2] = line2.Substring(17, 7);
            double eq_RAAN = double.Parse(tle2[2]);

            tle2[3] = line2.Substring(34, 8);
            double eq_ap = double.Parse(tle2[3]);

            tle2[4] = line2.Substring(43, 8);
            double eq_ma = double.Parse(tle2[4]);

            tle2[5] =line2.Substring(52, 11);
            double r = double.Parse(tle2[5]);

            return tlecalc(tm, e, rg(eq_i), rg(eq_RAAN), rg(eq_ap), rg(eq_ma), r);
        }

        private static double gr(double x)
        {
            x *= 57.295779513082320875;
            while ((x < 0) || (x >= 360))
            {
                if (x < 0) { x += 360; continue; }
                if (x >= 360) { x -= 360; continue; }
            }

            return x;
        }

        private static double rg(double x) => x * 0.01745329251994329577;

        private static OrbElements tlecalc(double tm, double e, double eq_i, double eq_RAAN, double eq_ap, double eq_ma, double r)
        {
            double pi = 3.141592653589793238463;
            double gm = 3.9860044e14;
            double ob_ecl = 0.40927970966248346;

            int tm1 = (int)Math.Truncate(tm / 1000.0);
            double tm2 = tm - tm1 * 1000.0;
            double mjd = tm2 + 51544 + 365 * tm1 + (tm1 - 1) / 4;

            double a = 0.720e3 * Math.Pow(0.5e1, 0.1e1 / 0.3e1) * Math.Pow(Math.Pow(r, -0.2e1) * gm * Math.Pow(pi, -0.2e1), 0.1e1 / 0.3e1);

            double eq_ml = eq_ma + eq_RAAN + eq_ap;

            double t1 = Math.Cos(eq_i);
            double t2 = Math.Cos(ob_ecl);
            double t3 = t1 * t2;
            double t4 = Math.Sin(eq_i);
            double t5 = Math.Cos(eq_RAAN);
            double t7 = Math.Sin(ob_ecl);
            double t8 = t4 * t5 * t7;
            double t11 = t5 * t5;
            double t12 = t2 * t2;
            double t14 = t1 * t1;
            double t16 = t14 * t12;
            double t19 = Math.Sqrt(-2.0 * t3 * t8 + 1.0 - t11 + t12 * t11 + t14 * t11 - t16 - t16 * t11);
            double ecl_i = Math.Atan2(t19, t3 + t8);
            double t21 = Math.Sin(eq_RAAN);
            double t23 = 1 / t19;
            double t25 = t2 * t4;
            double ecl_RAAN = Math.Atan2(t4 * t21 * t23, (t25 * t5 - t1 * t7) * t23);
            double t30 = Math.Sin(eq_ap);
            double t33 = Math.Cos(eq_ap);
            double t36 = t1 * t5;
            double t37 = t30 * t7;
            double ecl_ap = Math.Atan2((t4 * t30 * t2 - t21 * t33 * t7 - t36 * t37) * t23, (t25 * t33 - t33 * t7 * t36 + t37 * t21) * t23);

            double ecl_ma = eq_ma;
            double ecl_lp = ecl_ap + ecl_RAAN;
            double ecl_ml = ecl_lp + ecl_ma;

            return new OrbElements(a, e, gr(ecl_i), gr(ecl_RAAN), gr(ecl_lp), gr(ecl_ml), mjd);
        }

        /// <summary>
        /// Returns the Orbiter formatted string. (SMA, Ecc, Inc, AscNode, PeLong, MeanLong, ReferenceMJD)
        /// </summary>
        public override string ToString() => string.Format("{0:0.00000} {1:0.0000000} {2:0.00000} {3:0.00000} {4:0.00000} {5:0.00000} {6:00000.00000}",
    SMA, Ecc, Inc, AscNode, PeLong, MeanLong, ReferenceMJD);
    }
}
