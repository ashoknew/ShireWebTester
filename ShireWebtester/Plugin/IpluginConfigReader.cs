using ShireWebtester.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShireWebtester
{
    public interface IpluginConfigReader:Iplugin
    {
        string Type { get; }
        TestScript GetTestScriptInfo(string ScriptFile);
    }
}
