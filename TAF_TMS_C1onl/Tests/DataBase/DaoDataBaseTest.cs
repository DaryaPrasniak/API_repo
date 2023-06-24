using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.DAO;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Services.DataBases;

namespace TAF_TMS_C1onl.Tests.DataBase
{
    public class DaoDataBaseTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private SimpleDBConnector _simpleDbConnector;
        private CustomersDao _customersDao;

        [OneTimeSetUp]
        public void SetUp()
        {
            _simpleDbConnector = new SimpleDBConnector();
            _customersDao = new CustomersDao(_simpleDbConnector.Connection);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _simpleDbConnector.CloseConnection();
        }

        [Test]
        public void GetAllCustomersTest()
        {
            var customersList = _customersDao.getAllCustomers();

            Assert.That(customersList, Has.Count.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void AddCustomerTest()
        {
            _logger.Info("Find Customer Test started...");
            _logger.Info($"Find Customer: {_customersDao.GetById(9).FirstName}");
            _logger.Info("Find Customer Test ended...");
        }

        //[Test]
        //public void DeleteCustomerTest()
        //{
        //    _logger.Info("DeleteCustomer Test started...");

        //    int affectedRows = _customersDao.DeleteCustomer("George", "Test");

        //    Assert.That(1, Is.EqualTo(affectedRows));

        //    _logger.Info("DeleteCustomer Test ended...");
        //}
    }
}
