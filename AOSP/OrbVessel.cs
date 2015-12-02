using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AOSP
{
    /// <summary>
    /// This class handles everything (or almost everything) for vessel manipulation in a scenario.
    /// </summary>
    public class OrbVessel
    {
        #region Methods

        public struct OrbStatus
        {
            public const string Orbiting = "Orbiting";
            public const string Landed = "Landed";
        }

        string _name;
        string _class;
        string _stat;
        string _body;
        string _base;
        double _heading;
        double[] _pos;
        Vector3 _rpos;
        Vector3 _rvel;
        Vector3 _arot;
        Vector3 _vrot;

        /// <summary>
        /// Name of the ship.
        /// </summary>
        public string Name
        { 
            get { return _name; }
            set { _name = value; }
        } 

        /// <summary>
        /// Class of the ship.
        /// </summary>
        public string VesselClass
        { 
            get { return _class; }
            set { _class = value; }
        } 

        /// <summary>
        /// Status of the vessel: Landed or Orbiting.
        /// </summary>
        public string Status
        { 
            get { return _stat; }
            set
            {
                switch (value.ToLowerInvariant())
                {
                    case "landed":
                        _stat = "Landed";
                        break;
                    case "orbiting":
                        _stat = "Orbiting";
                        break;
                }
            }
        } 

        /// <summary>
        /// Reference body.
        /// </summary>
        public string RefBody
        { 
            get { return _body; }
            set { _body = value; }
        }

        /// <summary>
        /// Landed base, in case of status Landed. Throws a WrongVesselStatus if orbiting.
        /// </summary>
        public string Base
        {
            get
            {
                /*if (_stat == "Landed")
                    return _base;
                else
                    throw new WrongVesselStatusError("Requested status: Landed | Current Status: Orbiting", new Exception("Vessel: " + _name + " | event: getBase"));*/
                return _base;
            }
        }

        /// <summary>
        /// Sets the ship's landed base and pad.
        /// </summary>
        /// <param name="sBase">Base landed on.</param>
        /// <param name="landingpad">Landing pad of the base.</param>
        public void SetBase(string sBase, int landingpad)
        {
            _base = sBase+":"+landingpad.ToString();
        }

        /// <summary>
        /// Sets the ship's landed base.
        /// </summary>
        /// <param name="sBase">Base landed on.</param>
        public void SetBase(string sBase)
        {
            _base = sBase;
        }

        /// <summary>
        /// Heading of landed vessel, in case of status Landed. Throws a WrongVesselStatus if orbiting.
        /// </summary>
        public double Heading
        {
            get
            {
                /*if (_stat == "Landed")
                    return _heading;
                else
                    throw new WrongVesselStatusError("Requested status: Landed | Current Status: Orbiting", new Exception("Vessel: " + _name + " | event: getHeading"));*/
                return _heading;
            }
            set
            {
                if (_stat == "Landed")
                    _heading = value;
                else
                    throw new WrongVesselStatusError("Requested status: Landed | Current Status: Orbiting", new Exception("Vessel: " + _name + " | event: setHeading"));
            }
        }

        /// <summary>
        /// Position relative to the reference, in case of status Landed. Throws a WrongVesselStatus if orbiting.
        /// </summary>
        public double[] Pos
        {
            get
            {
                /*if (_stat == "Landed")
                    return _pos;
                else
                    throw new WrongVesselStatusError("Requested status: Landed | Current Status: Orbiting", new Exception("Vessel: " + _name + " | event: getPOS"));*/
                return _pos;
            }
        }

        /// <summary>
        /// Sets new position over the surface.
        /// </summary>
        /// <param name="lat">Latitude.</param>
        /// <param name="lng">Longitude.</param>
        public void SetPOS(double lat, double lng)
        {
            if (_stat == "Landed")
                    _pos = new double[] {lng, lat};
                else
                    throw new WrongVesselStatusError("Requested status: Landed | Current Status: Orbiting", new Exception("Vessel: " + _name + " | event: setPOS"));
        }

        /// <summary>
        /// Relative porition to the Reference Body, in case of status Orbiting. Throws a WrongVesselStatus if orbiting
        /// </summary>
        public Vector3 RPos
        {
            get; set;
        }

        /// <summary>
        /// Relative velocity to the reference, in case of status Orbiting. Throws a WrongVesselStatus if landed.
        /// </summary>
        public Vector3 RVel { get; set; }

        /// <summary>
        /// Angular position, in case of status Orbiting. Throws a WrongVesselStatus if orbiting.
        /// </summary>
        public Vector3 ARot { get; set; }

        /// <summary>
        /// Angular velocity, incase of status Orbiting.  Throws a WrongVesselStatusError if orbiting.
        /// </summary>
        public Vector3 VRot { get; set; }

        /// <summary>
        /// Returns true if orbit is defined with vector, else false (even if not defined at all).
        /// </summary>
        public bool HasPOSROT
        {
            get
            {
                switch (_stat)
                {
                    default:
                    case "Landed":
                        return false;
                    case "Orbiting":
                        return RPos == null || RVel == null;
                }
            }
        }

        /// <summary>
        /// Orbital elements of the ship. Useless if landed.
        /// </summary>
        public OrbElements Elements
        { 
            get;
            set;
        }

        /// <summary>
        /// Fuel level [0-1]. Overrides any other propellant definition if added.
        /// </summary>
        public float Fuel
        {
            get;
            set;
        }

        /// <summary>
        /// Propellant levels [0-1]. Is overriden by the Fuel member if present.
        /// </summary>
        public List<OrbLevels> PrpLevel
        {
            get;
            set;
        }

        /// <summary>
        /// Thrust level for each activated thruster. Not activated thrusters can be omitted. Can be let null.
        /// </summary>
        public List<OrbLevels> ThLevel
        {
            get;
            set;
        }

        /// <summary>
        /// Informations about docking status. Can be null.
        /// </summary>
        public List<OrbDockInfo> DockInfo
        {
            get;
            set;
        }

        /// <summary>
        /// Handle every "not-default" parameter.
        /// </summary>
        //public List<string> Extra { get; set; }
        public Dictionary<string, string> Extra { get; set; }

        private void Init()
        {
            PrpLevel = new List<OrbLevels>();
            ThLevel = new List<OrbLevels>();
            DockInfo = new List<OrbDockInfo>();

            Extra = new Dictionary<string, string>();
        }

        #endregion

        ///<summary>Default constructor</summary>
        public OrbVessel() { }

        /// <summary>OrbVessel constructor for a vessel in orbit.</summary>
        public OrbVessel(string name, string Class, string BodyRef, Vector3 RPos, Vector3 Rvel)
        {
            Init();

            _name = name;
            _class = Class;
            _body = BodyRef;
            _rpos = RPos;
            _rvel = Rvel;

            _stat = "Orbiting";
        }

        /// <summary>
        /// OrbVessel constructor for a landed vessel, anywhere.
        /// </summary>
        /// <param name="name">Name of the vessel.</param>
        /// <param name="Class">Class of the vessel (path to the config file, relative to Config folder).</param>
        /// <param name="BodyRef">Reference body.</param>
        /// <param name="pos">Porition on the surface.</param>
        /// <param name="heading">Heading.</param>
        public OrbVessel(string name, string Class, string BodyRef, double[] pos, double heading)
        {
            Init();

            _name = name;
            _class = Class;
            _body = BodyRef;
            _pos = pos;
            _heading = heading;

            _stat = "Landed";
        }

        /// <summary>
        /// OrbVessel constructor for a landed vessel on a base.
        /// </summary>
        /// <param name="name">Name of the vessel.</param>
        /// <param name="Class">Class of the vessel (path to the config file, relative to Config folder).</param>
        /// <param name="BodyRef">Reference body.</param>
        /// <param name="landed_base">Landed base.</param>
        /// <param name="heading">Heading.</param>
        /// <param name="pad">Pad number. Leave blank or use "-1" to put the vessel on the center of the base.</param>
        public OrbVessel(string name, string Class, string BodyRef, string landed_base, double heading, int pad = -1)
        {
            Init();

            _name = name;
            _class = Class;
            _body = BodyRef;
            _heading = heading;
            _base = (pad == -1 ? landed_base : landed_base + ":" + pad);

            _stat = "Landed";
        }

        /// <summary>
        /// Special constructor: Put the three TLE lines (title, line 1 & 2) and have a vessel properly configured !
        /// </summary>
        /// <param name="Class">Class of the vessel (path to the config file, relative to Config folder).</param>
        /// <param name="TLE">TLE lines (title, and lines 1&2).</param>
        public OrbVessel(string Class, string[] TLElines)
        {
            Init();

            VesselClass = Class;
            _body = "Earth";
            Elements = new OrbElements(TLElines);
            Name = TLElines[0];

            _stat = "Orbiting";
        }

        /// <summary>
        /// Returns the properly formatted Ship scenario block. 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Name + ':' + VesselClass);
            if (_stat == "Landed")
            {
                sb.AppendLine("  STATUS Landed " + RefBody);
                if(String.IsNullOrWhiteSpace(Base)) sb.AppendLine(String.Format("  POS {0} {1}", Pos));
                else sb.AppendLine("  BASE "+Base);
                sb.AppendLine(String.Format("  HEADING {0:0.00}", Heading));
            }
            else
            {
                sb.AppendLine("  STATUS Orbiting " + RefBody);
                
                if(HasPOSROT)
                {
                    sb.AppendLine("  RPOS " + RPos.ToString());
                    sb.AppendLine("  RVEL " + RVel.ToString());
                }
                else
                {
                    sb.AppendLine("  ELEMENTS " + Elements.ToString());
                }
            }

            sb.AppendLine("  AROT " + ARot.ToString());
            sb.AppendLine("  VROT " + VRot.ToString());

            try
            {
                string prplevels = "";
                foreach (OrbLevels lvl in PrpLevel)
                {
                    prplevels += lvl.ToString() + " ";
                }
                sb.AppendLine("  PRPLEVEL " + prplevels.Trim());
            }
            catch { }

            try
            {
                string thlevel = "";
                foreach (OrbLevels lvl in ThLevel)
                {
                    thlevel += lvl.ToString() + " ";
                }
                sb.AppendLine("  THLEVEL " + thlevel.Trim());
            }
            catch { }

            try
            {
                string dockinfo = "";
                foreach (OrbDockInfo dock in DockInfo)
                {
                    dockinfo += dock.ToString() + " ";
                }
                sb.AppendLine("  DOCKINFO " + dockinfo.Trim());
            }
            catch { }

            try
            {
                foreach (KeyValuePair<string, string> pair in Extra)
                {
                    sb.AppendLine("  " + pair.Key + " " + pair.Value);
                }
            }
            catch { }
            sb.Append("END");

            return sb.ToString();
        }
    }
}
