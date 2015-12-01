using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace AOSP
{
    /// <summary>
    /// A class to make PrpLevels and ThLevels work.
    /// </summary>
    /// <remarks></remarks>
    public struct OrbLevels
    {
        int _id;
        public int ID { get { return _id; } set { _id = value; } }

        float _lvl;
        public float Level
        {
            get { return _lvl; }
            set
            {
                if (value > 1) _lvl = 1;
                else if (value < 0) _lvl = 0;
                else _lvl = value;
            }
        }

        /// <summary>
        /// Returns a new instance of OrbLevels.
        /// </summary>
        /// <param name="ContainerID">The indentifier of the container (thrust id or propellant id)</param>
        /// <param name="ContainerLevel">The level of the container (thrust level or propellant level). Values are clamped to 0 to 1.</param>
        /// <remarks></remarks>
        public OrbLevels(int ContainerID, float ContainerLevel)
        {
            dynamic cLvl = ContainerLevel;
            if (cLvl < 0)
            {
                cLvl = 0;
            }
            else if (cLvl > 1)
            {
                cLvl = 1;
            }

            _id = ContainerID;
            _lvl = cLvl;
        }

        /// <summary>
        /// Returns the Orbiter formatted string. (ID:Level)
        /// </summary>
        public override string ToString()
        {
            return _id + ":" + _lvl;
        }
    }
}