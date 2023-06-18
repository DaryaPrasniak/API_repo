using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Core;
using TechTalk.SpecFlow;

namespace SpecFlow.Specs.Hooks
{
 
    public class BrowserHook
    {
        private readonly Browser _browser;
        public BrowserHook(Browser browser)
        {
            _browser = browser;
        }

        [BeforeScenario("GUI")]
        public void BeforeScenario()
        {
            Console.WriteLine("GUI");
        }

        [BeforeScenario("GeneralUser")]
        public void CreateGeneralUser()
        {
            Console.WriteLine("GeneralUser");
        }

        [AfterScenario("GUI")]
        public void AfterScenario() 
        {
            _browser.Driver.Quit();
        }
    }
}
