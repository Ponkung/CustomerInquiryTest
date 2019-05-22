using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerInquiry.Data;
using CustomerInquiry.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerInquiry.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DbSet<Transactions> TransactionsEntity;

        public TransactionRepository(ApplicationDbContext context)
        {
            TransactionsEntity = context.Set<Transactions>();
        }
        public Task<List<Transactions>> GetTransactionByCustomer(Customers customer)
        {
            return TransactionsEntity.Where(x => x.Customer == customer).OrderBy(x => x.TransactionId).Take(5).ToListAsync();
        }
    }
}
