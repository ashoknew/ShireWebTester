using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using ShireWebtester.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShireWebtester.Component
{
    public class DefaultAction : IpluginAction
    {
        public string type { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        IWebElement e = null;
        RemoteWebDriver page = null;
        public void ExecuteAction()
        {
            try
            {
                if ("Url".Equals(type))
                {
                    page.Navigate().GoToUrl(value);
                }
                else
                {
                    e = FindElement(page);
                    if ("text".Equals(e.GetAttribute("type")) 
                        || "password".Equals(e.GetAttribute("type")))
                    {
                        e.SendKeys(value);
                    }
                    else if ("button".Equals(e.GetAttribute("type"))
                        || "span".Equals(e.TagName)
                        || "a".Equals(e.TagName)
                        || "radio".Equals(e.GetAttribute("type")))
                    {
                        e.Click();
                    }
                    else if ("select-one".Equals(e.GetAttribute("type")))
                    {
                        new SelectElement(e).SelectByValue(value);
                    }
                }
            }
            catch (NoSuchElementException e)
            {
                throw new Exception("Component Not Found",e);
            }
        }

        private IWebElement FindElement(RemoteWebDriver page)
        {
            if(page.FindElementsByName(name).Count>0)
                e = page.FindElement(By.Name(name));
            if(e==null && (page.FindElementsById(name).Count>0))
            {
                e = page.FindElement(By.Id(name));
            }
            else if (e == null && (page.FindElementsByXPath(name).Count > 0))
            {
                e = page.FindElement(By.XPath(name));
            }
            else if (e == null && (page.FindElementsByLinkText(name).Count > 0))
            {
                e = page.FindElement(By.LinkText(name));
            }
            else if(e==null && page.FindElementsByTagName("a").Count>0)
            {
                var elements = page.FindElementsByTagName("a");
                foreach(var element in elements){
                    if (element.GetAttribute("href").Equals(name))
                    {
                        e = element;
                        break;
                    }
                }
            }
            else if (e == null)
                throw new Exception("Component Not Found");
            return e;
        }

        public void Initialize(RemoteWebDriver page, TestScript test)
        {
            this.page = page;
        }
    }
}
