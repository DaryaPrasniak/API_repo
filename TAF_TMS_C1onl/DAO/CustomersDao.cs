using NLog;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Models;

namespace TAF_TMS_C1onl.DAO
{
    public class CustomersDao : ICustomersDao
    {
        private NpgsqlConnection _connection;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public CustomersDao(NpgsqlConnection connection)
        { 
            _connection = connection;
        }
        public int Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> getAllCustomers()
        {
            var sqlQuery = "SELECT * FROM customers";
            var actualList = new List<Customer>();

            using var cmd = new NpgsqlCommand(sqlQuery, _connection);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var customer = new Customer()
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(reader.GetOrdinal("firstname")),
                    LastName = reader.GetString(reader.GetOrdinal("lastname")),
                    Email = reader.GetString(reader.GetOrdinal("email")),
                    Age = reader.GetInt32(reader.GetOrdinal("age"))
                };
                _logger.Info(customer.ToString);
                actualList.Add(customer);
            }

            return actualList;
        }

        public Customer GetById(int id)
        {
            var sqlQuery = "SELECT * FROM customers WHERE id = @id;";
            using (var cmd = new NpgsqlCommand(sqlQuery, _connection))
            { 
                cmd.Parameters.AddWithValue("id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Customer()
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(reader.GetOrdinal("firstname")),
                            LastName = reader.GetString(reader.GetOrdinal("lastname")),
                            Email = reader.GetString(reader.GetOrdinal("email")),
                            Age = reader.GetInt32(reader.GetOrdinal("age"))
                        };
                    }
                }
            }
            return null;
        }
    }
}
