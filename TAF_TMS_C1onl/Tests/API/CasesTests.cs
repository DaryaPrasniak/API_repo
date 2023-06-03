using AngleSharp.Text;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using Newtonsoft.Json.Linq;
using NLog;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Clients;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Services;
using TAF_TMS_C1onl.Utilites.Configuration;
using TAF_TMS_C1onl.Utilites.Helpers;

namespace TAF_TMS_C1onl.Tests.API
{
    public class CasesTests : BaseApiTest
    {

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        [Test]
        public void AddCaseTest()
        {
            var expectedCase = new Case();
            expectedCase.Title = "Test";
            expectedCase.SectionId = 1;
            expectedCase.TypeId = 2;
            expectedCase.PriorityId = 3;
            expectedCase.CreatedBy = 15;
            expectedCase.CreatedOn = 4;
            expectedCase.SuiteId = 1;

            var actualCase = _caseService.AddCase(expectedCase.SectionId, expectedCase);
            _logger.Info("Actual Case: " + actualCase.ToString());

            Assert.That(actualCase.Title,Is.EqualTo(expectedCase.Title));
        }

        [Test]
        public void GetCaseTest()
        {
            var newCase = new Case();
            newCase.Title = "Stop creating tests";
            newCase.SectionId = 1;
            newCase.SuiteId = 15;

            var expectedCase = _caseService.AddCase(newCase.SectionId, newCase);
            _logger.Info("Expected Case: " + expectedCase.ToString());

            var actualCase = _caseService.GetAsCase(expectedCase.Id);
            _logger.Info("Actual Case: " + expectedCase.ToString());

            Assert.That(actualCase.Title, Is.EqualTo(expectedCase.Title));
        }

        [Test]
        public void UpdateCaseTest()
        {
            var newCase = new Case();
            newCase.Title = "Stop creating tests";
            newCase.SectionId = 1;
            newCase.TypeId = 2;
            newCase.PriorityId = 3;
            newCase.CreatedBy = 15;
            newCase.CreatedOn = 4;
            newCase.SuiteId = 1;

            var expectedCase = _caseService.AddCase(newCase.SectionId, newCase);
            _logger.Info("Expected Case: " + expectedCase.ToString());

            newCase.Title = "New Title";
            newCase.TypeId = 1;

            var actualCase = _caseService.UpdateCase(expectedCase.Id, newCase);
            _logger.Info("Updated Case: " + actualCase.ToString());

            Assert.That(actualCase.Title, Is.EqualTo(newCase.Title));
        }

        [Test]
        public void DeleteCaseTest()
        { 
            var newCase = new Case();                                                                                   
            newCase.Title = "        Stop creating tests";                   
            newCase.SectionId = 1;        

            var expectedCase = _caseService.AddCase(newCase.SectionId, newCase);
            _logger.Info("Expected Case: " + expectedCase.ToString());

            _caseService.DeleteCase(expectedCase.Id);

            try
            {
                var actualCase = _caseService.GetAsCase(expectedCase.Id);
                Assert.That(actualCase, Is.Null);
            }
            catch (HttpRequestException ex)
            {
                _logger.Info("Message: " + ex.Message);
                Assert.That(true);
                return;
            }
            catch (Exception ex)                                      
            {
                _logger.Info("Message: " + ex.Message);
                Assert.That(false);
            }

            Assert.That(false);
        }
    }
}
