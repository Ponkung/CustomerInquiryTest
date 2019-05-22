using CustomerInquiry.Data.Models;
using CustomerInquiry.Repository;
using CustomerInquiry.Service;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInquiryTestClass
{
    public class CustomerServiceTest
    {
        private readonly Customers customerData;
        private readonly Customers customerData2;
        private readonly List<Transactions> transactionData;

        public CustomerServiceTest() {
            customerData = new Customers
            {
                CustomerName = "Sophon",
                ContactEmail = "abc@mail.com"
            };
            customerData2 = new Customers
            {
                CustomerId = 128,
                CustomerName = "Sophon",
                ContactEmail = "abc@mail.com"
            };
            transactionData = new List<Transactions>()
            {
                new Transactions{ TransactionId = 111, TransactionDate=DateTime.Now,Amount=1234.56M,CurrencyCode="THB",Status=StatusCode.Success },
                new Transactions{ TransactionId = 112, TransactionDate=DateTime.Now,Amount=0.56M,CurrencyCode="USD",Status=StatusCode.Failed },
                new Transactions{ TransactionId = 113, TransactionDate=DateTime.Now }
            };
        }

        [Test]
        public void TestGetCustomerTransactionByCustomerEmail_WithCustomerNotNull_ShouldHaveTransactionsData() {
            //Arrange
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository.Setup(x => x.GetCustomerByCustEmail("abc@mail.com")).ReturnsAsync(customerData);
            var mockTransactionRepository = new Mock<ITransactionRepository>();
            mockTransactionRepository.Setup(x => x.GetTransactionByCustomer(customerData)).ReturnsAsync(transactionData);
            var customerService = new CustomerService(mockCustomerRepository.Object, mockTransactionRepository.Object, null);

            //Act
            var data = customerService.GetCustomerTransactionByCustomerEmail("abc@mail.com");

            //Assert
            mockCustomerRepository.Verify(x => x.GetCustomerByCustEmail(It.IsAny<string>()), Times.Once);
            mockTransactionRepository.Verify(x => x.GetTransactionByCustomer(It.IsAny<Customers>()), Times.Once);
            Assert.AreEqual(3, data.Transactions.Count);
        }

        [Test]
        public void TestGetCustomerTransactionByCustomerId_WithCustomerNotNull_ShouldHaveTransactionsData()
        {
            //Arrange
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository.Setup(x => x.GetCustomerByCustID(128)).ReturnsAsync(customerData2);
            var mockTransactionRepository = new Mock<ITransactionRepository>();
            mockTransactionRepository.Setup(x => x.GetTransactionByCustomer(customerData2)).ReturnsAsync(transactionData);
            var customerService = new CustomerService(mockCustomerRepository.Object, mockTransactionRepository.Object, null);

            //Act
            var data = customerService.GetCustomerTransactionByCustomerId(128);

            //Assert
            mockCustomerRepository.Verify(x => x.GetCustomerByCustID(It.IsAny<int>()), Times.Once);
            mockTransactionRepository.Verify(x => x.GetTransactionByCustomer(It.IsAny<Customers>()), Times.Once);
            Assert.AreEqual(3, data.Transactions.Count);
        }

        [Test]
        public void TestGetCustomerTransactionByCustomerIdAndEmail_WithCustomerNotNull_ShouldHaveTransactionsData()
        {
            //Arrange
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository.Setup(x => x.GetCustomerByCustIdAndEmail(128, "abc@mail.com")).ReturnsAsync(customerData2);
            var mockTransactionRepository = new Mock<ITransactionRepository>();
            mockTransactionRepository.Setup(x => x.GetTransactionByCustomer(customerData2)).ReturnsAsync(transactionData);
            var customerService = new CustomerService(mockCustomerRepository.Object, mockTransactionRepository.Object, null);

            //Act
            var data = customerService.GetCustomerTransactionByCustomerIdAndEmail(128, "abc@mail.com");

            //Assert
            mockCustomerRepository.Verify(x => x.GetCustomerByCustIdAndEmail(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
            mockTransactionRepository.Verify(x => x.GetTransactionByCustomer(It.IsAny<Customers>()), Times.Once);
            Assert.AreEqual(3, data.Transactions.Count);
        }

        [Test]
        public void TestGetCustomerTransactionByCustomerIdAndEmail_WithCustomerIsNull_ShouldNotHaveTransactionsData()
        {
            //Arrange
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockTransactionRepository = new Mock<ITransactionRepository>();
            mockTransactionRepository.Setup(x => x.GetTransactionByCustomer(customerData2)).ReturnsAsync(transactionData);
            var customerService = new CustomerService(mockCustomerRepository.Object, mockTransactionRepository.Object, null);

            //Act
            var data = customerService.GetCustomerTransactionByCustomerIdAndEmail(128, "abc@mail.com");

            //Assert
            mockCustomerRepository.Verify(x => x.GetCustomerByCustIdAndEmail(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
            mockTransactionRepository.Verify(x => x.GetTransactionByCustomer(It.IsAny<Customers>()), Times.Never);
            Assert.AreEqual(null, data);
        }

        [Test]
        public void TestAddCustomer_WithCustomerIsNotNull_ShouldHaveNewCustomer()
        {
            //Arrange
            Customers savedCustomer = null;
            var customerData = new Customers
            {
                CustomerName = "test123",
                ContactEmail = "abc123@mail.com"
            };
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository.Setup(x => x.SaveCustomer(customerData)).Callback<Customers>(x => savedCustomer = x);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(x => x.SaveChanges());
            var customerService = new CustomerService(mockCustomerRepository.Object, null, mockUnitOfWork.Object);
            

            //Act
            customerService.AddCustomer(customerData);

            //Assert
            mockCustomerRepository.Verify(x => x.SaveCustomer(customerData), Times.Once);
            mockUnitOfWork.Verify(x => x.SaveChanges(), Times.Once);
            Assert.AreEqual(customerData.CustomerName, savedCustomer.CustomerName);
            Assert.AreEqual(customerData.ContactEmail, savedCustomer.ContactEmail);
        }
    }
}
