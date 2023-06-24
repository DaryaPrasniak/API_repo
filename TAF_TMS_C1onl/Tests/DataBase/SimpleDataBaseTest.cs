using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Services.DataBases;

namespace TAF_TMS_C1onl.Tests.DataBase
{
    public class SimpleDataBaseTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private SimpleDBConnector _simpleDbConnector;
        private CustomersService _customersService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _simpleDbConnector = new SimpleDBConnector();
            _customersService = new CustomersService(_simpleDbConnector.Connection);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _simpleDbConnector.CloseConnection();
        }

        [Test]
        public void GetAllCustomersTest()
        {
            var customersList = _customersService.GetAllCustomers();

            Assert.That(customersList, Has.Count.GreaterThanOrEqualTo(2));
        }

        [Test]
        public void AddCustomerTest()
        {
            _logger.Info("AddCustomer Test started...");

            int affectedRows = _customersService.AddCustomer(new Customer
            {
                FirstName = "George",
                LastName = "Test",
                Email = "nvfgdjf@gmail.com",
                Age = 78
            });

            Assert.That(1, Is.EqualTo(affectedRows));

            _logger.Info("AddCustomer Test ended...");
        }

        [Test]
        public void DeleteCustomerTest()
        {
            _logger.Info("DeleteCustomer Test started...");

            int affectedRows = _customersService.DeleteCustomer("George", "Test");

            Assert.That(1, Is.EqualTo(affectedRows));

            _logger.Info("DeleteCustomer Test ended...");
        }
    }
}
