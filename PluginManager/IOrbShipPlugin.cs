using AOSP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Reflection;

namespace TLEOrbiter.PluginManager
{
    /// <summary>
    /// Enum displaying the data to expect from an input.
    /// </summary>
    public enum OrbVesselScenarioDataType
    {
        STRING,
        INT,
        DOUBLE,
        VECTOR,
        UMMU,
        PERCENTAGE
    }

    /// <summary>
    /// Interface for a plugin that processes information about a particular Orbiter Vessel in a scenario.
    /// </summary>
    public interface IOrbVesselPlugin
    {
        /// <summary>
        /// Plugin metadata
        /// </summary>
        PluginMetadata Metadata { get; }
        /// <summary>
        /// Unique ID that identifies the plugin.
        /// </summary>
        Guid UID { get; }

        /// <summary>
        /// Name of the vessel. This property will be displayed in the dropdown menu in the ship selection dialog.
        /// </summary>
        string VesselName { get; }
        /// <summary>
        /// Author of the Orbiter vessel. Can be left empty, but is good practice to give credits where it's due. ;)
        /// </summary>
        string VesselAuthor { get; }

        /// <summary>
        /// Vessel class name to load in the scenario. If left null here, it needs to be entered in OrbVessel.VesselClass in SendOrbVesselData().
        /// </summary>
        string VesselClassName { get; }

        /// <summary>
        /// Sends a dictionary of properties for the user to input.
        /// </summary>
        /// <returns></returns>
        Dictionary<string, OrbVesselScenarioDataType> SetOrbVesselInput();
        OrbVessel SendOrbVesselData(IOrbVesselContext context);
    }

    /// <summary>
    /// Provides context to plugins that wishes to create and OrbVessel out of TLE.
    /// </summary>
    public interface IOrbVesselContext
    {
        /// <summary>
        /// Raw 2-line TLE data plus name.
        /// </summary>
        string[] RawTLE { get; set; }
        /// <summary>
        /// Vessel status before being processed by the plugin. Use as starting point.
        /// </summary>
        OrbVessel Vessel { get; set; }
        /// <summary>
        /// Data returned by the user. Same keys from SetOrbVesselInput().
        /// </summary>
        Dictionary<string, object> InputData { get; set; }
    }

    /// <summary>
    /// Defines the metadata for one plugin.
    /// </summary>
    public struct PluginMetadata
    {
        /// <summary>
        /// Plugin name. Will get displayed in the ship selection dialog and in the "About" dialog in the settings.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Plugin author (you, surely). Will get displayed in the "About" dialog in the settings.
        /// </summary>
        public string Author { get; set; }

        public override int GetHashCode() => (Name + Author).GetHashCode();
        public override bool Equals(object obj)
        {
            var b = (PluginMetadata)obj;
            return b.GetHashCode() == this.GetHashCode();
        }
    }

    static class PluginManager
    {
        static string PluginsPath => Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Plugins");

        static IOrbVesselPlugin[] loadedPlugins;

        static void LoadPlugins()
        {
            Type pType = typeof(IOrbVesselPlugin);
            List<IOrbVesselPlugin> newPlugins = new List<IOrbVesselPlugin>();

            foreach(string dll in Directory.GetFiles(PluginsPath, "*.dll"))
            {
                AssemblyName an = AssemblyName.GetAssemblyName(dll);
                Assembly ass = Assembly.Load(an);

                if(ass == null) continue;

                foreach(Type T in ass.GetTypes())
                {
                    if(T.GetInterface(pType.FullName) == null) continue;

                    newPlugins.Add((IOrbVesselPlugin)Activator.CreateInstance(T));
                }
            }

            loadedPlugins = newPlugins.ToArray<IOrbVesselPlugin>();
        }

        static Dictionary<Guid, PluginMetadata> GetPluginMetadata()
        {
            var dic = new Dictionary<Guid, PluginMetadata>();

            foreach(IOrbVesselPlugin p in loadedPlugins)
            {
                Guid ID = p.UID;
                if(!dic.Keys.ToList().Exists(x => x == ID)) dic.Add(ID, p.Metadata);
            }

            return dic;
        }

        static Dictionary<Guid, string> GetVesselNames()
        {
            var dic = new Dictionary<Guid, string>();

            foreach(IOrbVesselPlugin p in loadedPlugins)
            {
                Guid ID = p.UID;
                if( !dic.Keys.ToList().Exists(x => x == ID) ) dic.Add(p.UID, p.VesselName);
            }

            return dic;
        }

        static IOrbVesselPlugin GetPlugin(Guid ID) => loadedPlugins.First(x => x.UID == ID);

        internal static Dictionary<string, string> PopulateDropdown()
        {
            var dic = new Dictionary<string, string>();

            foreach(KeyValuePair<Guid, string> kvp in GetVesselNames() )
                dic.Add(kvp.Key.ToString(), kvp.Value);

            return dic;
        }
    }
}
