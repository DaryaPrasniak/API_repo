using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_TMS_C1onl.Models;

namespace TAF_TMS_C1onl.DAO
{
    public interface ICustomersDao
    {
        List<Customer> getAllCustomers();
        Customer GetById(int id);
        int Add(Customer customer);
        int Delete(int? id);
    }
}
