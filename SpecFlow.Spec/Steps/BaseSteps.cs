using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Clients;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Services;
using TAF_TMS_C1onl.Steps;
using TechTalk.SpecFlow;

namespace SpecFlow.Specs.Steps
{
    public class BaseSteps
    {
        protected IWebDriver Driver;
        protected NavigationSteps _navigationSteps;
        protected ProjectSteps _projectSteps;
        protected CaseService _caseService;
        protected ApiClient _apiClient;

        public BaseSteps(ScenarioContext scenarioContext) : this()
        {
            Driver = scenarioContext.Get<IWebDriver>("Driver");
            _navigationSteps = new NavigationSteps(Driver);
            _projectSteps = new ProjectSteps(Driver);
        }

        public BaseSteps()
        {
            _apiClient = new ApiClient();
            _caseService = new CaseService(_apiClient);
        }
    }
}
