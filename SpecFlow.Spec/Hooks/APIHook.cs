using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Clients;
using TAF_TMS_C1onl.Core;
using TechTalk.SpecFlow;

namespace SpecFlow.Specs.Hooks
{
    [Binding]
    public class APIHook
    {
        private readonly ScenarioContext _scenarioContext;
        private ApiClient _apiClient;
        public APIHook(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario("API")]
        public void BeforeScenario()
        {
            _apiClient = new ApiClient();
        }
    }
}
