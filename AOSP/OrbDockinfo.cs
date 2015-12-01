using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace AOSP
{
    /// <summary>
    /// This class handles the DockInfo part of a ship in the scenario.
    /// </summary>
    /// <remarks></remarks>
    public struct OrbDockInfo
    {
        /// <summary>
        /// Identifier of the docking port.
        /// </summary>
        public int DockID { get; set; }

        /// <summary>
        /// Identifier of the target docking port.
        /// </summary>
        public int TargetDockID { get; set; }

        /// <summary>
        /// Target vessel name. AOSP does not perform verification if the ship actually exists.
        /// </summary>
        public string TargetVessel { get; set; }

        /// <summary>
        /// Return the Orbiter formatted string. (DockID:TargetDockID,TargetVessel)
        /// </summary>
        public override string ToString()
        {
            return DockID + ':' + TargetDockID + ',' + TargetVessel;
        }
    }
}