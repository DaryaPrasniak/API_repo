using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Utilites.Configuration;

namespace TAF_TMS_C1onl.Core
{
    public class DBConnector : DbContext
    {
        public DbSet<Customer>? Customers { get; set; }

        public DBConnector()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString =
                $"Host={Configurator.DbSettings.Server};" +
                $"Port={Configurator.DbSettings.Port};" +
                $"Database={Configurator.DbSettings.Schema};" +
                $"User Id={Configurator.DbSettings.Username};" +
                $"Password={Configurator.DbSettings.Password};";

            optionsBuilder.UseNpgsql(connectionString);
        }  
    }
}
