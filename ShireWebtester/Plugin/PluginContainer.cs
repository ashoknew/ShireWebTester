using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShireWebtester
{
    public class PluginContainer
    {
        private static List<Iplugin> _container = null;
        public static List<Iplugin> GetPluginContainer()
        {
            if (_container == null) 
            {
                _container = LoadContainer();
            }
            return _container;
        }

        public PluginContainer()
        {

        }

        private static List<Iplugin> LoadContainer()
        {
            var PluginDlls = Directory.GetFiles("./Plugins");
            foreach(var file in PluginDlls)
            {
                Console.WriteLine(file.ToString());
            }
            return null;
        }
    }
}
