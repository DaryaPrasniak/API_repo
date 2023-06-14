using OpenQA.Selenium;
using System;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Pages;
using TAF_TMS_C1onl.Steps;
using TechTalk.SpecFlow;

namespace SpecFlow.Specs.Steps
{
    [Binding]
    public class ProblemsStepDefinitions : BaseSteps
    {
        public ProblemsStepDefinitions(ScenarioContext scenarioContext): base(scenarioContext)
        {
        }

        [Given(@"new browser is open")]
        public void NewBrowserIsOpen()
        {
        }

        [Given(@"new login page is displayed")]
        public void NewLoginPageIsDisplayed()
        {
            _navigationSteps.NavigateToLoginPage();
        }

        [Given(@"the user ""([^""]*)"" with password ""([^""]*)"" logged in")]
        public void TheUserWithPasswordLoggedIn(string username, string password)
        {
            _navigationSteps.SuccessfulLogin(username, password);
        }
    }
}
