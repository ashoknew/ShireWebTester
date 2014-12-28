using OpenQA.Selenium.Remote;
using ShireWebtester.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShireWebtester
{
    public interface Iplugin
    {
        void Initialize(RemoteWebDriver page,TestScript test);
    }
}
