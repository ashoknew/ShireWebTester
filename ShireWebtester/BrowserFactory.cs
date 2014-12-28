using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShireWebtester
{
    public class BrowserFactory
    {
        public RemoteWebDriver GetBrowser(BrowsersType browser)
        {
            RemoteWebDriver page = null;
            if (browser == BrowsersType.IE)
            {
                var options = new InternetExplorerOptions();
                options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                page = new InternetExplorerDriver(options);
            }
            else if (browser == BrowsersType.FireFox)
            {
                page = new FirefoxDriver();
            }
            else if (browser == BrowsersType.Chrome)
            {
                page = new ChromeDriver();
            }
            return page;
        }
    }
}
