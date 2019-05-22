using CustomerInquiry.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInquiry.Repository
{
    public interface ITransactionRepository
    {
        Task<List<Transactions>> GetTransactionByCustomer(Customers customer);
    }
}
