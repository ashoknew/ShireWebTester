using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShireWebtester
{
    public interface IpluginAction : Iplugin
    {
        string type { get; set; }
        string name { get; set; }
        string value { get; set; }
        void ExecuteAction();
    }
}
