using NUnit.Framework;
using System;
using TAF_TMS_C1onl.Core;
using TechTalk.SpecFlow;

namespace SpecFlow.Specs.Steps
{
    [Binding]
    public class SettingSteps : BaseSteps
    {
        public SettingSteps(ScenarioContext scenarioContext) : base(scenarioContext) 
        {
        }

        [Then(@"settings page is open")]
        public void SettingsPageIsOpen()
        {
            Driver.Navigate().GoToUrl("https://aqac01onl01.testrail.io/index.php?/admin/site_settings");
            Assert.AreEqual("Site Settings - TestRail", Driver.Title);
        }
    }
}
