using CustomerInquiry.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInquiry.Repository
{
    public interface ICustomerRepository
    {
        void SaveCustomer(Customers Customer);
        Task<Customers> GetCustomerByCustID(int id);
        Task<Customers> GetCustomerByCustEmail(string email);
        Task<Customers> GetCustomerByCustIdAndEmail(int id, string email);
    }
}
