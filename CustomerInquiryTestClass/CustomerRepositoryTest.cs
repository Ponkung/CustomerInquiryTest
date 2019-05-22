using CustomerInquiry.Data;
using CustomerInquiry.Data.Models;
using CustomerInquiry.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInquiryTestClass
{
    public class CustomerRepositoryTest
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ICustomerRepository customerRepository;

        public CustomerRepositoryTest()
        {
            dbContext = new InMemoryDbContextFactory().GetApplicationDbContext();
            customerRepository = new CustomerRepository(dbContext);
        }

        [Test]
        public void TestGetCustomerByCustEmail_WithHaveEmail_ReturnCustomerWithEmail() {
            // Arrange
            var email = "ponkung@gmail.com";
            var customer = new Customers
            {
                ContactEmail = email
            };
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
            //Act
            var customerResult = customerRepository.GetCustomerByCustEmail(email).Result;
            // Assert
            Assert.AreEqual(email,customerResult.ContactEmail);
        }

        [Test]
        public void TestGetCustomerByCustID_WithHaveCustId_ReturnCustomerWithCustId()
        {
            // Arrange
            var customerId = 123;
            var customer = new Customers
            {
                CustomerId = customerId
            };
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
            //Act
            var customerResult = customerRepository.GetCustomerByCustID(customerId).Result;
            // Assert
            Assert.AreEqual(customerId, customerResult.CustomerId);
        }

        [Test]
        public void TestGetCustomerByCustIdAndEmail_WithHaveCustIdAndEmail_ReturnCustomerWithCustIdAndEmail()
        {
            // Arrange
            var customerId = 123;
            var email = "ponkung@gmail.com";
            var customer = new Customers
            {
                CustomerId = customerId,
                ContactEmail = email
            };
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
            //Act
            var customerResult = customerRepository.GetCustomerByCustIdAndEmail(customerId,email).Result;
            // Assert
            Assert.AreEqual(customerId, customerResult.CustomerId);
            Assert.AreEqual(email, customerResult.ContactEmail);
        }

        [Test]
        public void TestSaveCustomer_WithHaveCustomer_ReturnCustomerWithNewCustomer()
        {
            // Arrange
            var customerId = 123;
            var email = "ponkung@gmail.com";
            var customer = new Customers
            {
                CustomerId = customerId,
                ContactEmail = email
            };
            //Act
            customerRepository.SaveCustomer(customer);
            dbContext.SaveChanges();
            // Assert
            var result = dbContext.Customers.Find(customer.Id);
            Assert.AreEqual(customerId, result.CustomerId);
            Assert.AreEqual(email, result.ContactEmail);
        }
    }
}
