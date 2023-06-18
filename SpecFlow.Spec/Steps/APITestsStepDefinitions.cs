using NUnit.Framework;
using SeleniumExtras.WaitHelpers;
using System;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Services;
using TechTalk.SpecFlow;

namespace SpecFlow.Specs.Steps
{
    [Binding]
    public class APITestsStepDefinitions: BaseSteps
    {
        private Case expectedCase;
        private Case actualCase;
        private Case newCase;
        private Case expectedCaseUpdate;
        public APITestsStepDefinitions(ScenarioContext scenarioContext) : base()
        {
        }

        [Given(@"init api client")]
        public void InitApiClient()
        {
        }

        [When(@"new case ""([^""]*)"" with ""([^""]*)"" and ""([^""]*)"" and ""([^""]*)"" is added")]
        public void NewCaseWithAndAndIsAdded(string title, int sectionId, int typeId, int priorityId)
        {
            this.expectedCase = new Case();
            expectedCase.Title = "Test";
            expectedCase.SectionId = 1;
            expectedCase.TypeId = 2;
            expectedCase.PriorityId = 3;
            expectedCase.SuiteId = 1;

            this.actualCase = _caseService.AddCase(expectedCase.SectionId, expectedCase);
        }

        [Then(@"the case is added")]
        public void TheCaseIsAdded()
        {
            Assert.That(actualCase.Title, Is.EqualTo(expectedCase.Title));
        }

        [Then(@"the case is requested to get")]
        public void TheCaseIsRequestedToGet()
        {
            var createdCaseToGet = _caseService.GetAsCase(actualCase.Id);
            Assert.That(createdCaseToGet.Title, Is.EqualTo(actualCase.Title));
        }

        [When(@"the case is updated")]
        public void TheCaseIsUpdated()
        {
            this.newCase = new Case();
            newCase.Title = "Update Test Case";
            newCase.SectionId = 1;
            newCase.TypeId = 2;
            newCase.PriorityId = 3;
            newCase.SuiteId = 2;

            this.expectedCaseUpdate = _caseService.AddCase(newCase.SectionId, newCase);

            newCase.Title = "New Title";
        }

        [Then(@"the title is updated")]
        public void TheTitleIsUpdated()
        {
            var actualCaseUpdate = _caseService.UpdateCase(expectedCaseUpdate.Id, newCase);
            Assert.That(actualCaseUpdate.Title, Is.EqualTo(newCase.Title));
        }

        [Then(@"the case is deleted")]
        public void TheCaseIsDeleted()
        {
            _caseService.DeleteCase(actualCase.Id);
        }

        [Then(@"there is no deleted case")]
        public void ThereIsNoDeletedCase()
        {
            try
            {
                var actualCaseDeleted = _caseService.GetAsCase(actualCase.Id);
                Assert.That(actualCase, Is.Null);
            }
            catch (HttpRequestException ex)
            {
                Assert.That(true);
                return;
            }
            catch (Exception ex)
            {
                Assert.That(false);
            }

            Assert.That(false);
        }
    }
}
