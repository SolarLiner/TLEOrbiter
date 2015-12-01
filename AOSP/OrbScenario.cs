using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOSP
{
    public class OrbScenario
    {
        /// <summary>
        /// Handles the desctiption of the scenario.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Handles the used solar system.
        /// </summary>
        public string System { get; set; }

        /// <summary>
        /// Returns true if the scenario has MJD date. Else false.
        /// </summary>
        public bool HasMJD { get { return MJD != -1d; } }

        /// <summary>
        /// Handles the MJD of the scenario.
        /// </summary>
        public double MJD { get; set; }

        /// <summary>
        /// Returns true if the scenario contains help.
        /// </summary>
        public bool HasHelp { get { return Help != null; } }

        /// <summary>
        /// Handles the "help" line of the scenario.Path is relative to the "Html\Scenarios" folder. Template: [path],[page].
        /// </summary>
        public string Help { get; set; }

        /// <summary>
        /// Returns true if the scenario has a special context for bases.
        /// </summary>
        public bool HasContext { get { return Context != null; } }

        /// <summary>
        /// Handles the context line of the scenario.
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        /// Returns true if the scenario contains a script.
        /// </summary>
        public bool HasScript { get { return Script != null; } }

        /// <summary>
        /// Handles the script path of the scenario, relative to the Script folder.
        /// </summary>
        public string Script { get; set; }

        /// <summary>
        /// Name of the controlled ship. Link to an non existing ship will make Orbiter focus the first ship.
        /// </summary>
        public string FocusShip { get; set; }

        /// <summary>
        /// Camera handle of the scenario.
        /// </summary>
        public OrbCamera Camera { get; set; }

        /// <summary>
        /// HUD Mode in the cockpit.
        /// </summary>
        public OrbHUD HUDmode { get; set; }

        /// <summary>
        /// List of ships on the scenario.
        /// </summary>
        public List<OrbVessel> Ships { get; set; }

        /// <summary>
        /// Extra blocks goes here.
        /// </summary>
        public Dictionary<string, string> Extra { get; set; }

        /// <summary>
        /// Creates a scenario.
        /// </summary>
        public OrbScenario()
        {
            System = "Sol";
            Ships = new List<OrbVessel>();
            Camera = new OrbCamera();
            HUDmode = OrbHUD.Surface;
            MJD = -1d;
        }

        /// <summary>
        /// initializes a new OrbScenario.
        /// </summary>
        /// <param name="filename">Relative or absolute path to the scenario</param>
        /// <remarks></remarks>
        public OrbScenario(string filename)
        {
	        if (Path.GetExtension(filename) == ".scn") {
		        Parse(File.ReadAllLines(filename));
	        } else {
		        throw new IOException("OrbScenario: Bad file extension");
	        }
        }

        /// <summary>
        /// initializes a new OrbScenario.
        /// </summary>
        /// <param name="filename">Uri of the scenario (could technically be remote!)</param>
        /// <remarks></remarks>
        public OrbScenario(Uri filename)
        {
            Ships = new List<OrbVessel>();
            
            if (Path.GetExtension(filename.AbsolutePath) == ".scn") {
		        Parse(File.ReadAllLines(filename.AbsolutePath));
	        } else {
		        throw new IOException("OrbScenario: Bad file extension");
	        }
        }

        private void Parse(string[] lines)
        {
	        int i;
            for (i = 0; i <= lines.Count()-1; i++)
            {
                switch (lines[i].ToUpperInvariant())
                {
                    case "BEGIN_DESC":
                        {
                            i++;
                            Description = lines[i];
                            i++;
                            while (!(lines[i] == "END_DESC"))
                            {
                                Description += '\n' + lines[i];
                                i++;
                            }
                            break;
                        }
                    case "BEGIN_ENVIRONMENT":
                        {
                            i++;
                            while (!(lines[i] == "END_ENVIRONMENT"))
                            {
                                string[] content = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                                switch (content[0].ToUpperInvariant())
                                {
                                    case "SYSTEM":
                                        System = content[1];
                                        break;
                                    case "DATE":
                                        switch (content[1])
                                        {
                                            case "MJD":
                                                MJD = double.Parse(content[2]);
                                                break;
                                            case "JD":
                                                MJD = double.Parse(content[2]) + 2400000.5;
                                                break;
                                            default:
                                                //MJD = Misc.GetMJD(DateTime.Now); // Wrong: we should only indicate there's no MJD data
                                                MJD = -1d; // Will trigger 'HasMJD = false'
                                                break;
                                        }
                                        break;
                                    case "HELP":
                                        Help = content[1];
                                        break;
                                    case "SCRIPT":
                                        Script = content[1];
                                        break;
                                }

                                i++;
                            }
                            break;
                        }
                    case "BEGIN_CAMERA":
                        {
                            OrbCamera cam = new OrbCamera();

                            while (lines[i] != "END_CAMERA")
                            {
                                string[] line = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                                switch (line[0].ToUpperInvariant())
                                {
                                    case "MODE":
                                        if (line[1] == "Extern") cam.Mode = OrbCamera.CameraMode.Extern;
                                        else cam.Mode = OrbCamera.CameraMode.GlassCockpit;

                                        break;
                                    case "TARGET":
                                        cam.Target = line[1];
                                        
                                        break;
                                    case "POS":
                                        try { cam.Pos = new Vector3(double.Parse(line[1]), double.Parse(line[2]), double.Parse(line[3])); }
                                        catch { }

                                        break;
                                    case "TRACKMODE":
                                        OrbCamera.CameraTrackMode tmode;
                                        if(Enum.TryParse<OrbCamera.CameraTrackMode>(line[1], out tmode)) cam.TrackMode = tmode;

                                        try { cam.RefBody = line[2]; }
                                        catch { }

                                        break;
                                    case "GROUNDLOCATION":
                                        if (line.Length < 4) break;
                                        cam.GroundLocation = new double[3] { double.Parse(line[1]), double.Parse(line[2]), double.Parse(line[3]) };

                                        break;
                                    case "GROUNDDIRECTION":
                                        if (line.Length < 3) break;
                                        cam.GroundDirection = new double[2] { double.Parse(line[1]), double.Parse(line[2]) };

                                        break;
                                    case "FOV":
                                        cam.FieldOfView = double.Parse(line[1]);

                                        break;
                                    default:
                                        break;
                                }
                                i++;
                            }
                            Camera = cam;

                            break;
                        }
                    case "BEGIN_PANEL":
                        Camera.Mode = OrbCamera.CameraMode.PanelCockpit;
                        while (lines[i] != "END_PANEL")
                        {
                            i++;
                        }

                        break;
                    case "BEGIN_VC":
                        Camera.Mode = OrbCamera.CameraMode.VirtualCockpit;
                        while (lines[i]!="END_VC")
                        {
                            i++;
                        }

                        break;
                    case "BEGIN_HUD":
                        i++;
                        while (lines[i]!="END_HUD")
                        {
                            string[] line2 = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            switch (line2[0].ToUpperInvariant())
                            {
                                case "TYPE":
                                    OrbHUD hud = OrbHUD.None;
                                    Enum.TryParse<OrbHUD>(line2[1], out hud);
                                    HUDmode = hud;

                                    break;
                                default:
                                    break;
                            }

                            i++;
                        }
                        
                        break;
                    case "BEGIN_SHIPS":
                        {
                            OrbVessel ship = new OrbVessel();

                            i++;
                            string[] content = lines[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                            if (content.Count() == 2)
                            {
                                ship.Name = content[0];
                                ship.VesselClass = content[1];

                                i++;
                                while (!(lines[i] == "END"))
                                {
                                    string[] line = lines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                                    switch (line[0].ToUpperInvariant())
                                    {
                                        case "STATUS":
                                                ship.Status = line[1];
                                                ship.RefBody = line[2];
                                                break;
                                        case "POS":
                                                ship.SetPOS(Double.Parse(line[2]), double.Parse(line[1]));
                                                break;
                                        case "HEADING":
                                                ship.Heading = double.Parse(line[1]);
                                                break;
                                        case "RPOS":
                                                ship.RPos = new Vector3(double.Parse(line[1]), double.Parse(line[2]), double.Parse(line[3]));
                                                break;
                                        case "RVEL":
                                                ship.RVel = new Vector3(double.Parse(line[1]), double.Parse(line[2]), double.Parse(line[3]));
                                                break;
                                        case "AROT":
                                                ship.ARot = new Vector3(double.Parse(line[1]), double.Parse(line[2]), double.Parse(line[3]));
                                                break;
                                        case "VROT":
                                                ship.VRot = new Vector3(double.Parse(line[1]), double.Parse(line[2]), double.Parse(line[3]));
                                                break;
                                        case "FUEL":
                                            {
                                                ship.Fuel = float.Parse(line[1]);
                                                break;
                                            }
                                        case "PRPLEVEL":
                                            {
                                                List<OrbLevels> level = new List<OrbLevels>();
                                                for (int j = 1; j < line.Count()-1; j++)
                                                {
                                                    string[] split = line[j].Split(':');
                                                    level.Add(new OrbLevels(int.Parse(split[0]), float.Parse(split[1])));
                                                }
                                                ship.PrpLevel = level;
                                                break;
                                            }
                                        case "THLEVEL":
                                            {
                                                List<OrbLevels> throttles = new List<OrbLevels>();
                                                for (int j = 1; j < line.Count()-1; j++)
                                                {
                                                    string[] split = line[j].Split(':');
                                                    throttles.Add(new OrbLevels(int.Parse(split[0]), float.Parse(split[1])));
                                                }
                                                ship.ThLevel = throttles;
                                                break;
                                            }
                                        case "DOCKINFO":
                                            {
                                                List<OrbDockInfo> dockinfo = new List<OrbDockInfo>();
                                                for (int j = 1; j<line.Count() - 1; j++)
                                                {
                                                    string[] split = line[j].Split(':');
                                                    dockinfo.Add(new OrbDockInfo() { DockID = int.Parse(split[0]), TargetDockID = int.Parse(split[1]), TargetVessel = split[2] });
                                                }
                                                ship.DockInfo = dockinfo;
                                                break;
                                            }
                                        default:
                                            {
                                                string key = line[0];
                                                string value = "";
                                                for (int j = 1; j < line.Count(); j++)
                                                {
                                                    value += line[j] + " ";
                                                }
                                                ship.Extra.Add(key, value.Trim());

                                                break;
                                            }
                                    }

                                    i++;
                                }
                            }
                        }

                        break;
                }
	        }
            if (MJD == 0) MJD = Misc.GetMJD(DateTime.Now);
        }

        public string RenderScenario()
        {
            StringBuilder sb = new StringBuilder("BEGIN_DESC\n");
            sb.AppendLine(Description.Replace("\n", "\n\n"));
            sb.AppendLine("END_DESC");

            sb.AppendLine();

            sb.AppendLine("BEGIN_ENVIRONMENT");
            sb.AppendLine("  System " + System);
            if(HasMJD) sb.AppendLine(String.Format("  Date MJD {0:00000.000000}", MJD));
            if (HasHelp) sb.AppendLine("  HELP " + Help);
            if (HasContext) sb.AppendLine("  CONTEXT " + Context);
            if (HasScript) sb.AppendLine("  SCRIPT " + Script);
            sb.AppendLine("END_ENVIRONMENT");

            sb.AppendLine();

            sb.AppendLine("BEGIN_FOCUS");
            if(Ships.Count > 0) sb.AppendLine("  Ship " + (FocusShip == null ? Ships[0].Name : FocusShip));
            sb.AppendLine("END_FOCUS");

            sb.AppendLine();

            sb.AppendLine(Camera.ToString(Ships[0]));

            sb.AppendLine();

            if (HUDmode != OrbHUD.None)
            {
                sb.AppendLine("BEGIN_HUD");
                sb.AppendLine("  TYPE " + Enum.GetName(typeof(OrbHUD), HUDmode));
                sb.AppendLine("END_HUD");

                sb.AppendLine();
            }

            sb.AppendLine("BEGIN_SHIPS");
            foreach (OrbVessel ship in Ships)
            {
                sb.AppendLine(ship.ToString());
            }
            sb.AppendLine("END_SHIPS");

            try
            {
                foreach (KeyValuePair<string, string> pair in Extra)
                {
                    sb.AppendLine("BEGIN_" + pair.Key);
                    foreach (string line in pair.Value.Split('\n')) sb.AppendLine("  " + line);
                    sb.AppendLine("END");
                    sb.AppendLine();
                }
            }
            catch { }

            return sb.ToString();
        }
    }
}
