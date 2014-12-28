using OpenQA.Selenium.Remote;
using ShireWebtester;
using ShireWebtester.Action;
using ShireWebtester.Component;
using ShireWebtester.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace XMLConfigReaderPlugin
{
    public class XmlConfigReader : IpluginConfigReader
    {
        public TestScript GetTestScriptInfo(string ScriptFile)
        {
            XPathDocument doc = null;
            XPathNavigator nav = null;
            XmlNamespaceManager ns = null;
            XPathExpression expr;
            XPathNodeIterator iterator;
            TestScript testScript = null;
            try
            {
                testScript = new TestScript();
                doc = new XPathDocument(ScriptFile);
                nav = doc.CreateNavigator();
                ns = new XmlNamespaceManager(nav.NameTable);
                expr = nav.Compile("/TestScriptConfig/test");
                iterator = nav.Select(expr);
                foreach (XPathNavigator node in iterator)
                {
                    testScript.TestId = node.GetAttribute("TestId", ns.DefaultNamespace);
                    string browser = node.GetAttribute("Browsers", ns.DefaultNamespace);
                    string[] browserarray = browser.Split(',');
                    testScript.Browsers = new List<BrowsersType>();
                    foreach(string a in browserarray)
                    {
                        if (a == "IE")
                        {
                            testScript.Browsers.Add(BrowsersType.IE);
                        }
                        else if(a == "Chrome")
                        {
                            testScript.Browsers.Add(BrowsersType.Chrome);
                        }
                        else if (a == "FireFox")
                        {
                            testScript.Browsers.Add(BrowsersType.FireFox);
                        }
                    }                    
                }
                expr = nav.Compile("/TestScriptConfig/actions/action");
                iterator = nav.Select(expr);
                testScript.Actions = new List<IpluginAction>();
                foreach (XPathNavigator node in iterator)
                {
                    IpluginAction action = null;
                    if("ScreenShot".Equals(node.GetAttribute("type", ns.DefaultNamespace)))
                    {
                        action = new ScreenShotAction();
                    }
                    else
                    {
                        action = new DefaultAction();
                    }                    
                    action.type = node.GetAttribute("type", ns.DefaultNamespace); 
                    action.name = node.GetAttribute("name", ns.DefaultNamespace); 
                    action.value = node.GetAttribute("value", ns.DefaultNamespace); 
                    testScript.Actions.Add(action);
                }
                return testScript;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Type
        {
            get { return "xml"; }
        }

        public void Initialize(RemoteWebDriver page, TestScript test)
        {
            
        }
    }
}
