using OpenQA.Selenium.Remote;
using ShireWebtester.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShireWebtester.Action
{
    public class ScreenShotAction : IpluginAction
    {
        public string type{ get; set; }

        public string name { get; set; }

        public string value { get; set; }

        TestScript script = null;

        RemoteWebDriver page = null; 

        public void ExecuteAction()
        {
            ScreenShotCreator.GetInstance(Directory.GetCurrentDirectory(), script.TestId, script.TestId).TakeScreenShot(page);
        }

        public void Initialize(RemoteWebDriver page, TestScript test)
        {
            this.page = page;
            script = test;
        }
    }
}
