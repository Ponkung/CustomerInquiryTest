using CustomerInquiry.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInquiry.Service
{
    public interface ICustomerService
    {
        Customers GetCustomerTransactionByCustomerId(int customerId);
        Customers GetCustomerTransactionByCustomerEmail(string email);
        Customers GetCustomerTransactionByCustomerIdAndEmail(int customerId, string email);
        void AddCustomer(Customers customer);
    }
}
