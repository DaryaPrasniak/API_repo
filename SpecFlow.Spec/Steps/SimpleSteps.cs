using NUnit.Framework;
using System;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Steps;
using TechTalk.SpecFlow;

namespace SpecFlow.Specs.Steps
{
    [Binding]
    public class SimpleSteps
    {
        private Browser _browser;
        private NavigationSteps _navigationSteps;

        [Given(@"open browser")]
        public void OpenBrowser()
        {
            _browser = new Browser();
        }

        [When(@"login page is open")]
        [Given(@"login page is open")]
        public void LoginPageIsOpen()
        {
            _navigationSteps = new NavigationSteps(_browser.Driver);
            _navigationSteps.NavigateToLoginPage();
        }

        [Then(@"username field is displayed")]
        public void IsUsernameFieldDisplayed()
        {
            Assert.IsTrue(true);
        }

        [Then(@"password field is displayed")]
        public void IsPasswordFieldDisplayed()
        {
            Assert.IsTrue(true);
        }

        [Then(@"error is displayed")]
        public void IsErrorDisplayed()
        {
            Assert.IsTrue(true);
        }

        //[After()]
        //public void TearDown()
        //{
        //    _browser.Driver.Quit();
        //}
    }
}
