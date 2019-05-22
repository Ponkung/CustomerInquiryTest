using CustomerInquiry.Data;
using CustomerInquiry.Data.Models;
using CustomerInquiry.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInquiryTestClass
{
    public class TransactionRepositoryTest
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ITransactionRepository transactionRepository;

        public TransactionRepositoryTest()
        {
            dbContext = new InMemoryDbContextFactory().GetApplicationDbContext();
            transactionRepository = new TransactionRepository(dbContext);
        }

        [Test]
        public void TestGetTransactionByCustomer_WithHaveCustomerInTransaction_ReturnListTransactionNotOverFive() {
            // Arrange
            var customer = new Customers
            {
                CustomerId = 123,
                ContactEmail = "ponkung@gmail.com",
                Transactions = new List<Transactions>()
                {
                    new Transactions{ TransactionId = 111, TransactionDate=DateTime.Now },
                    new Transactions{ TransactionId = 112, TransactionDate=DateTime.Now },
                    new Transactions{ TransactionId = 113, TransactionDate=DateTime.Now },
                    new Transactions{ TransactionId = 117, TransactionDate=DateTime.Now },
                    new Transactions{ TransactionId = 118, TransactionDate=DateTime.Now },
                    new Transactions{ TransactionId = 119, TransactionDate=DateTime.Now }
                }
            };
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
            //Act
            var transactionResult = transactionRepository.GetTransactionByCustomer(customer).Result;
            // Assert
            Assert.AreEqual(5, transactionResult.Count);
        }
    }
}
