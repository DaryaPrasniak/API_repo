using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Core;
using TechTalk.SpecFlow;

namespace SpecFlow.Specs.Hooks
{
    [Binding]
    public class Hook
    {
        private readonly ScenarioContext _scenarioContext;
        private Browser _browser;
        public Hook(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario("GUI")]
        public void BeforeScenario()
        {
            _browser = new Browser();
            _scenarioContext.Add("Driver", _browser.Driver);
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
