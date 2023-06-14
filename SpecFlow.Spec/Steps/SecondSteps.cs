using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Steps;

namespace SpecFlow.Specs.Steps
{
    [Binding]
    public class SecondSteps
    {
        private Browser _browser;
        private NavigationSteps _navigationSteps;

        [Given(@"browser is open")]
        public void BrowserIsOpen()
        {
            _browser = new Browser();
        }

        [Given(@"login page is opened")]
        public void LoginPageIsOpened()
        {
            _navigationSteps = new NavigationSteps(_browser.Driver);
            _navigationSteps.NavigateToLoginPage();
        }

        [When(@"user ""([^""]*)"" with password ""([^""]*)"" logged in")]
        public void UserWithPasswordLoggedIn(string username, string password)
        {
            _navigationSteps.SuccessfulLogin(username, password);
        }

        [Then(@"the title is ""([^""]*)""")]
        public void TheTitleIs(string expectedValue)
        {
            Assert.AreEqual(expectedValue, _browser.Driver.Title);
        }

        [Then(@"project ID is (.*)")]
        public void ProjectIDIs(int expectedValue)
        {
            Assert.AreEqual(expectedValue, expectedValue);
        }

       // [After()]
        //public void TearDown()
        //{
        //    _browser.Driver.Quit();
        //}
    }
}
