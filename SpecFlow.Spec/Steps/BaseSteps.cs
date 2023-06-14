using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Steps;
using TechTalk.SpecFlow;

namespace SpecFlow.Specs.Steps
{
    public class BaseSteps
    {
        protected IWebDriver Driver;
        protected NavigationSteps _navigationSteps;

        public BaseSteps(ScenarioContext scenarioContext)
        {
            Driver = scenarioContext.Get<IWebDriver>("Driver");
            _navigationSteps = new NavigationSteps(Driver);
        }
    }
}
