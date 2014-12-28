using ShireWebtester;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShireWebTestRunner
{
    class TestRunner
    {
        static void Main(string[] args)
        {
            Tester UiTest = new Tester("YahooXMLTest.xml");
            UiTest.Start();
        }
    }
}
