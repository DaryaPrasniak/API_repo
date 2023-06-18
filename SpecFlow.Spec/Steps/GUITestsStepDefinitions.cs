using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Steps;
using TechTalk.SpecFlow;

namespace SpecFlow.Specs.Steps
{
    [Binding]
    public class GUITestsStepDefinitions: BaseSteps
    {
        public GUITestsStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [Given(@"chrome browser is open")]
        public void ChromeBrowserIsOpen()
        {
        }

        [Given(@"loginpage is displayed")]
        public void LoginpageIsDisplayed()
        {
            _navigationSteps.NavigateToLoginPage();
        }

        [Given(@"a user ""([^""]*)"" with password ""([^""]*)"" logged in")]
        [When(@"a user ""([^""]*)"" with password ""([^""]*)"" logged in")]
        public void AUserWithPasswordLoggedIn(string username, string password)
        {
            _navigationSteps.SuccessfulLogin(username, password);
        }

        [Given(@"dashboard page is open")]
        [Then(@"dashboard page is open")]
        public void DashboardPageIsOpen()
        {
            Assert.IsTrue(_navigationSteps.DashboardPage.IsPageOpened());
        }

        [When(@"new project ""([^""]*)"" added")]
        public void NewProjectAdded(string projectName)
        {
            _projectSteps.NavigateToAddProjectPage();
            _projectSteps.CreateNewProject(projectName);
        }

        [Then(@"the project ""([^""]*)"" is displayed")]
        public void TheProjectIsDisplayed(string projectName)
        {
            var newProject = Driver.FindElement(By.PartialLinkText("Test Project")).Text;
            Assert.AreEqual(newProject, projectName);
        }
    }
}
