using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShireWebtester
{
    public class PluginManager
    {
        public static List<IpluginConfigReader> _ConfigPluginContainer;
        public static List<IpluginAction> _ComponentPluginContainer;
        public static List<IpluginLogging> _LoggingPluginContainer;        

        public static List<IpluginConfigReader> GetAllConfigPlugins()
        {
            if (_ConfigPluginContainer == null)
                _ConfigPluginContainer = LoadPlugin<IpluginConfigReader>();
            return _ConfigPluginContainer;
        }

        public static List<IpluginAction> GetAllComponentPlugins()
        {
            if (_ComponentPluginContainer != null)
                return _ComponentPluginContainer;
            return null;
        }

        public static List<IpluginLogging> GetAllLoggingPlugins()
        {
            if (_LoggingPluginContainer != null)
                return _LoggingPluginContainer;
            return null;
        }

        public static List<T> LoadPlugin<T>()
        {
            var PluginDlls = Directory.GetFiles(@".\plugins","*.dll");
            List<T> _PluginContainer = null;
            foreach (var file in PluginDlls)
            {
                _PluginContainer = new List<T>();
                var PluginAssembly = Assembly.LoadFrom(AppDomain.CurrentDomain.BaseDirectory.ToString() + file);
                var configuration = PluginAssembly.GetManifestResourceStream("Configuration.xml");
                var obj = PluginAssembly.CreateInstance(PluginAssembly.GetTypes()[0].ToString());
                if (obj is T)
                    _PluginContainer.Add((T)obj);
            }
            return _PluginContainer;
        }
    }
}
