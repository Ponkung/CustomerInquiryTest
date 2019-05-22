using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerInquiry.Data;
using CustomerInquiry.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerInquiry.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbSet<Customers> customersEntity;

        public CustomerRepository(ApplicationDbContext context) {
            customersEntity = context.Set<Customers>();
        }

        public Task<Customers> GetCustomerByCustEmail(string email)
        {
            return customersEntity.Where(x => x.ContactEmail == email).FirstOrDefaultAsync();
        }

        public Task<Customers> GetCustomerByCustID(int id)
        {
            // .Net core cannot use Include with limit T^T
            return customersEntity.Where(x => x.CustomerId == id).FirstOrDefaultAsync();
        }

        public Task<Customers> GetCustomerByCustIdAndEmail(int id, string email)
        {
            return customersEntity.Where(x => x.CustomerId == id && x.ContactEmail == email).FirstOrDefaultAsync();
        }

        public void SaveCustomer(Customers Customer)
        {
            customersEntity.Add(Customer);
        }
    }
}
