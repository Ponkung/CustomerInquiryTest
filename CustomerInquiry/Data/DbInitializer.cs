using CustomerInquiry.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInquiry.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context) {
            context.Database.EnsureCreated();
            // Look for any students.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            //MockData
            var customerData = new Customers();
            customerData.CustomerId = 125;
            customerData.CustomerName = "sophon kov";
            customerData.ContactEmail = "Ponkung@gmail.com";
            customerData.MobileNo = 0123456789;
            customerData.Transactions = new List<Transactions>()
            {
                new Transactions{ TransactionId = 111, TransactionDate=DateTime.Now,Amount=1234.56M,CurrencyCode="THB",Status=StatusCode.Success },
                new Transactions{ TransactionId = 112, TransactionDate=DateTime.Now,Amount=0.56M,CurrencyCode="USD",Status=StatusCode.Failed },
                new Transactions{ TransactionId = 113, TransactionDate=DateTime.Now }
            };
            context.Customers.Add(customerData);

            var customerData2 = new Customers();
            customerData2.CustomerId = 124;
            customerData2.ContactEmail = "sophon@gmail.com";
            customerData2.Transactions = new List<Transactions>()
            {
                new Transactions{ TransactionId = 111, TransactionDate=DateTime.Now },
                new Transactions{ TransactionId = 112, TransactionDate=DateTime.Now },
                new Transactions{ TransactionId = 113, TransactionDate=DateTime.Now },
                new Transactions{ TransactionId = 117, TransactionDate=DateTime.Now },
                new Transactions{ TransactionId = 118, TransactionDate=DateTime.Now },
                new Transactions{ TransactionId = 119, TransactionDate=DateTime.Now }
            };
            context.Customers.Add(customerData2);

            var customerData3 = new Customers();
            customerData3.CustomerId = 123456;
            customerData3.CustomerName = "FirstName LastName";
            customerData3.ContactEmail = "User@domain.com";
            customerData3.MobileNo = 0123456789;

            context.Customers.Add(customerData3);

            context.SaveChanges();
        }
    }
}
