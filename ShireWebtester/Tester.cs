using OpenQA.Selenium.Remote;
using ShireWebtester.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShireWebtester
{
    public class Tester
    {
        private string _TestScriptFile = string.Empty;

        public Tester(string TestScriptFile)
        {
            this._TestScriptFile = TestScriptFile;
        }

        public void Start()
        {
            RemoteWebDriver page = null;
            string extensiontype = _TestScriptFile.Substring(_TestScriptFile.IndexOf('.')+1,(_TestScriptFile.Length - _TestScriptFile.IndexOf('.'))-1); 
            var ConfigReader = PluginManager.GetAllConfigPlugins().Find(m => m.Type == extensiontype);
            ConfigReader.Initialize(page,null);
            var Script = ConfigReader.GetTestScriptInfo(_TestScriptFile);
            foreach (var browser in Script.Browsers)
            {
                page = new BrowserFactory().GetBrowser(browser);
                foreach (var action in Script.Actions)
                {
                    action.Initialize(page, Script);
                    action.ExecuteAction();
                }
            }
        }
    }
}
