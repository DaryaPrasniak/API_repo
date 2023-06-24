using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NLog;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Models;

namespace TAF_TMS_C1onl.Services.DataBases
{
    public class CustomersService
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly NpgsqlConnection _connection;

        public CustomersService(NpgsqlConnection connection)
        { 
            _connection = connection;
        }

        public void CreateTable()
        {
            var sqlQuery = "CREATE TABLE customers (" +
                               "id SERIAL PRIMARY KEY, " +
                               "firstname CHARACTER VARYING(30), " +
                               "lastname CHARACTER VARYING(30), " +
                               "email CHARACTER VARYING(30), " +
                               "age INTEGER" +
                               ");";

            using var cmd = new NpgsqlCommand(sqlQuery, _connection);
            cmd.ExecuteNonQuery();
        }
        public void DropTable()
        {
            var sqlQuery = "drop table if exists customers";

            using var cmd = new NpgsqlCommand(sqlQuery, _connection);         
            cmd.ExecuteNonQuery();
            
        }
        public List<Customer> GetAllCustomers()
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

        public int AddCustomer(Customer customer)
        {
            var sqlQuery = "INSERT INTO customers (firstname, lastname, email, age) VALUES ($1, $2, $3, $4);";

            using var cmd = new NpgsqlCommand(sqlQuery, _connection)
            { 
                Parameters =
                { 
                    new() { Value = customer.FirstName },
                    new() { Value = customer.LastName },
                    new() { Value = customer.Email },
                    new() { Value = customer.Age }
                }
            };

            return cmd.ExecuteNonQuery();
        }

        public int DeleteCustomer(string firstname, string lastname)
        {
            var sqlQuery = "DELETE FROM customers WHERE firstname = $1 AND lastname = $2;";

            using var cmd = new NpgsqlCommand(sqlQuery, _connection)
            {
                Parameters =
                {
                    new() { Value = firstname},
                    new() { Value = lastname}
                }
            };

            return cmd.ExecuteNonQuery();
        }
    }
}
