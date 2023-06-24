using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Models;

namespace TAF_TMS_C1onl.Tests.DataBase
{
    public class AdvancedDataBaseTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private DBConnector _dataBaseConnector;

        [OneTimeSetUp]
        public void SetUp()
        {
            _dataBaseConnector = new DBConnector();
        }

        [Test]
        public void SelectTest()
        {
            _logger.Info("Start Advanced Select Test");
            using (var dbConnector = _dataBaseConnector)
            {
                var customer1 = new Customer
                {
                    FirstName = "George",
                    LastName = "Test",
                    Email = "nvfgdjf@gmail.com",
                    Age = 78
                };

                var customer2 = new Customer
                {
                    FirstName = "Jhon",
                    LastName = "TestTest"
                };

                var entityCustomer1 = dbConnector.Customers.Add(customer1);               
                var entityCustomer2 = dbConnector.Customers.Add(customer2);
                dbConnector.SaveChanges();

                _logger.Info(entityCustomer1.ToString);
                _logger.Info(entityCustomer1.ToString);

                _logger.Info($"FirstName: {dbConnector.Customers.Find(entityCustomer1.Entity.Id)?.FirstName}");

                var customers = dbConnector.Customers.ToList();

                foreach (var customer in customers)
                {
                    _logger.Info($"{customer.FirstName}, {customer.LastName}");
                    dbConnector.Customers.Remove(customer);
                }

                dbConnector.SaveChanges();
            }
        }
    }
}
