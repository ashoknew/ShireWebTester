using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShireWebtester.Helper
{
    public class TestScript
    {

        public string TestId { get; set; }

        public List<BrowsersType> Browsers { get; set; }

        public List<IpluginAction> Actions { get; set; }
    }
}
