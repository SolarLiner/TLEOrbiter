using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOSP
{
    /// <summary>
    /// Handles camera stuff.
    /// </summary>
    public class OrbCamera
    {
        /// <summary>
        /// Camera Mode. GlassCockpit, PanelCockpit and VirtualCockpit are the "Cockpit" mode.
        /// </summary>
        public enum CameraMode
        {
            Extern,
            GlassCockpit,
            PanelCockpit,
            VirtualCockpit
        }

        /// <summary>
        /// Camera track mode.
        /// </summary>
        public enum CameraTrackMode
        {
            TargetRelative,
            AbsoluteDirection,
            GlobalFrame,
            TargetTo,
            TargetFrom,
            Ground
        }

        /// <summary>
        /// Camera mode used by the scenario.
        /// </summary>
        public CameraMode Mode { get; set; }

        /// <summary>
        /// Target of the camera.
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// Camera position relative to target.
        /// </summary>
        public Vector3 Pos { get; set; }

        /// <summary>
        /// Camera behaviour. For modes with a target, <see cref="RefBody">RefBody</see> is used.
        /// </summary>
        public CameraTrackMode TrackMode { get; set; }

        /// <summary>
        /// Reference body for camera with a reference.
        /// </summary>
        public string RefBody { get; set; }

        /// <summary>
        /// Ground location (longitude [0], latitude[1] and altitude[2]) of the observer.
        /// </summary>
        public double[] GroundLocation
        {
            get { return _gloc; }
            set { if (value.Length == 3) _gloc = value; }
        }
        private double[] _gloc;

        /// <summary>
        /// Polar coordinates of the ground observer orientation
        /// </summary>
        public double[] GroundDirection
        {
            get { return _gdir; }
            set { if (value.Length == 2) _gdir = value; }
        }
        private double[] _gdir;

        /// <summary>
        /// Field of view in degrees.
        /// </summary>
        public double FieldOfView { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public OrbCamera()
        {
            Mode = CameraMode.Extern;
            Target = string.Empty;
            Pos = new Vector3(0, 5, 2);
            TrackMode = CameraTrackMode.TargetRelative;
            GroundLocation = new double[3] { 0, 0, 0 };
            GroundDirection = new double[2] { 0, 0 };
            FieldOfView = 60.0;
        }

        /// <summary>
        /// Defines a chasing camera around the target (or the first ship to come).
        /// </summary>
        /// <param name="mode">Camera mode (cockpit or external).</param>
        /// <param name="target">Target ship name.</param>
        public OrbCamera(CameraMode mode, string target = "")
        {
            Mode = mode;
            Target = target;
            Pos = new Vector3(0, 5, 2);
            TrackMode = CameraTrackMode.TargetRelative;
            GroundLocation = new double[3] { 0, 0, 0 };
            GroundDirection = new double[2] { 0, 0 };
            FieldOfView = 60.0;
        }

        /// <summary>
        /// Defines a camera with a target ship and a reference body (if any)
        /// </summary>
        /// <param name="tmode">Track Mode.</param>
        /// <param name="target">Target ship.</param>
        /// <param name="refbody">Reference body (Target[from|to] and Ground modes)</param>
        public OrbCamera(CameraTrackMode tmode, string target = "", string refbody = "")
        {
            Mode = CameraMode.Extern;
            Target = target;
            RefBody = refbody;
            Pos = new Vector3(0, 5, 2);
            TrackMode = tmode;
            GroundLocation = new double[3] { 0, 0, 0 };
            GroundDirection = new double[2] { 0, 0 };
            FieldOfView = 60.0;
        }

        /// <summary>
        /// Defines a camera - with the mode and the track method.
        /// </summary>
        /// <param name="mode">Camera mode.</param>
        /// <param name="tmode">Camera track mode.</param>
        /// <param name="target">Target ship.</param>
        /// <param name="refbody">Reference body (for Target[from|to] and Ground track modes).</param>
        public OrbCamera(CameraMode mode, CameraTrackMode tmode, string target = "", string refbody = "")
        {
            Mode = CameraMode.Extern;
            Target = target;
            RefBody = refbody;
            Pos = new Vector3(0, 5, 2);
            TrackMode = CameraTrackMode.TargetRelative;
            GroundLocation = new double[3] { 0, 0, 0 };
            GroundDirection = new double[2] { 0, 0 };
            FieldOfView = 60.0;
        }

        /// <summary>
        /// Changes camera to a ground camera with defined position.
        /// </summary>
        /// <param name="longitude">Longitude of the camera on the reference body.</param>
        /// <param name="latitude">Latitude of the camera on the reference body.</param>
        /// <param name="altitude">Altitude of the camera on the reference body.</param>
        /// <param name="refbody">Reference body. Leave blank for no change.</param>
        public void ChangeCamPosition(double longitude, double latitude, double altitude, string refbody = "")
        {
            TrackMode = CameraTrackMode.Ground;
            GroundLocation = new double[3] { longitude, latitude, altitude };
            if (String.IsNullOrWhiteSpace(refbody)) RefBody = refbody;
        }

        /// <summary>
        /// Orbiter Camera block in string format
        /// </summary>
        /// <param name="firstship">First ship in the list to track to when no target is avaliable.</param>
        /// <returns>Orbiter formatted string containing the Camera block of the scenario.</returns>
        public string ToString(OrbVessel firstship)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("BEGIN_CAMERA");
            switch (Mode)
            {
                case CameraMode.Extern:
                    sb.AppendLine("  MODE Extern");

                    break;
                case CameraMode.GlassCockpit:
                case CameraMode.PanelCockpit:
                case CameraMode.VirtualCockpit:
                    sb.AppendLine("  MODE Cockpit");

                    break;
            }

            if (!String.IsNullOrWhiteSpace(Target)) sb.AppendLine("  TARGET " + Target);
            else sb.AppendLine("  TARGET " + firstship.Name);

            sb.AppendLine(String.Format("  POS {0:0.00} {1:0.00} {2:0.00}", Pos.x, Pos.y, Pos.z));
            switch (TrackMode)
            {
                case CameraTrackMode.TargetRelative:
                    sb.AppendLine("  TRACKMODE TargetRelative");
                    break;
                case CameraTrackMode.AbsoluteDirection:
                    sb.AppendLine("  TRACKMODE AbsoluteDirection");
                    break;
                case CameraTrackMode.GlobalFrame:
                    sb.AppendLine("  TRACKMODE GlobalFrame");
                    break;
                case CameraTrackMode.TargetTo:
                    sb.AppendLine("  TRACKMODE TargetTo " + RefBody);
                    break;
                case CameraTrackMode.TargetFrom:
                    sb.AppendLine("  TRACKMODE TargetFrom " + RefBody);
                    break;
                case CameraTrackMode.Ground:
                    sb.AppendLine("  TRACKMODE Ground " + RefBody);
                    sb.AppendLine(String.Format("  GROUNDLOCATION {0:0.00} {1:0.00} {2:0.00}", GroundLocation));
                    sb.AppendLine(String.Format("  GROUNDDIRECTION {0:0.000} {1:0.000}", GroundDirection));
                    break;
            }

            sb.AppendLine(String.Format("  FOV {0:0.0}", FieldOfView));

            sb.Append("END_CAMERA");
            switch (Mode)
            {
                case CameraMode.PanelCockpit:
                    sb.AppendLine("BEGIN_PANEL");
                    sb.Append("END_PANEL");
                    break;
                case CameraMode.VirtualCockpit:
                    sb.AppendLine("BEGIN_VC");
                    sb.Append("END_VC");
                    break;
                default:
                    break;
            }

            return sb.ToString();
        }
    }
}
