using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOSP;
using TLEOrbiter.PluginManager;

namespace SolarLiner.Generic
{
    public class OrbVesselGeneric: IOrbVesselPlugin
    {
        public PluginMetadata Metadata => new PluginMetadata
        {
            Author = "SolarLiner",
            Name = "Generic OrbVessel input plugin"
        };

        public bool PreventUserFromEnteringName => false;

        public Guid UID => Guid.Parse("{95B05482-6887-498A-B6CA-EC6D57002E1A}"); // Guid.NewGuid() could also work, but I prefer a static property.

        public string VesselAuthor => string.Empty;
        public string VesselClassName => string.Empty;
        public string VesselName => "Generic";

        public OrbVessel SendOrbVesselData(IOrbVesselContext context)
        {
            var v = context.Vessel;
            v.Fuel = (float)(double)context.InputData["Fuel level"];
            v.VesselClass = (string)context.InputData["Class Name"];

            var extra = new Dictionary<string, string>();
            double xpdr = (double)context.InputData["Transponder (kHz)"];
            xpdr = (xpdr - 108.0) * 20.0;
            extra.Add("XPDR", Math.Round(xpdr<0? 0 : xpdr).ToString());

            return v;
        }

        public Dictionary<string, OrbVesselScenarioDataType> SetOrbVesselInput()
        {
            Dictionary<string, OrbVesselScenarioDataType> dic = new Dictionary<string, OrbVesselScenarioDataType>();
            dic.Add("Class Name", OrbVesselScenarioDataType.STRING);
            dic.Add("Transponder (kHz)", OrbVesselScenarioDataType.DOUBLE);
            dic.Add("Fuel level", OrbVesselScenarioDataType.PERCENTAGE);

            return dic;
        }
    }
}
