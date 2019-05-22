using AutoMapper;
using CustomerInquiry.Controllers;
using CustomerInquiry.Data;
using CustomerInquiry.Data.Models;
using CustomerInquiry.Mappings;
using CustomerInquiry.Repository;
using CustomerInquiry.Service;
using CustomerInquiryTestClass;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;

namespace Tests
{
    public class CustomerInquiryControllerTests
    {
        private readonly IMapper mapper;
        private readonly Mock<ICustomerService> mockcustomerService;
        private readonly Customers customerData;

        public CustomerInquiryControllerTests() {

            customerData = new Customers
            {
                CustomerName = "Sophon",
                ContactEmail = "Sophon@gmail.com"
            };
            mockcustomerService = new Mock<ICustomerService>();
            mockcustomerService.Setup(x => x.GetCustomerTransactionByCustomerId(123)).Returns(customerData);
            mockcustomerService.Setup(x => x.GetCustomerTransactionByCustomerEmail("Sophon@gmail.com")).Returns(customerData);
            mockcustomerService.Setup(x => x.GetCustomerTransactionByCustomerIdAndEmail(12345, "Sophon@gmail.com")).Returns(customerData);
            mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new DomainProfile())));
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestCustomerInquiryController_WithCustID_ShouldReturnSuccess()
        {
            // Arrange
            ParameterInput parm = new ParameterInput();
            parm.customerID = 123;

            //Act
            CustomerInquiryController controller = new CustomerInquiryController(mockcustomerService.Object, mapper);
            var resultData = await controller.Post(parm);

            // Assert
            var result = resultData.Result as OkObjectResult;
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsNotNull(result.Value as CustomersViewModel);
        }

        [Test]
        public async Task TestCustomerInquiryController_WithCustEmail_ShouldReturnSuccess()
        {
            // Arrange
            ParameterInput parm = new ParameterInput();
            parm.email = "Sophon@gmail.com";

            //Act
            CustomerInquiryController controller = new CustomerInquiryController(mockcustomerService.Object, mapper);
            var resultData = await controller.Post(parm);

            // Assert
            var result = resultData.Result as OkObjectResult;
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsNotNull(result.Value as CustomersViewModel);
        }

        [Test]
        public async Task TestCustomerInquiryController_WithCustIdAndEmail_ShouldReturnSuccessAsync()
        {
            // Arrange
            ParameterInput parm = new ParameterInput();
            parm.customerID = 12345;
            parm.email = "Sophon@gmail.com";

            //Act
            CustomerInquiryController controller = new CustomerInquiryController(mockcustomerService.Object, mapper);
            var resultData = await controller.Post(parm);

            // Assert
            var result = resultData.Result as OkObjectResult;
            Assert.AreEqual(200, result.StatusCode);
            Assert.IsNotNull(result.Value as CustomersViewModel);
        }
        [Test]
        public async Task TestCustomerInquiryController_WithCustIdAndEmailButNohaveDataInDatabase_ShouldReturnSuccessWithNotFound()
        {
            // Arrange
            ParameterInput parm = new ParameterInput();
            parm.customerID = 123456789;
            parm.email = "Sophon@gmail.com";

            //Act
            CustomerInquiryController controller = new CustomerInquiryController(mockcustomerService.Object, mapper);
            var resultData = await controller.Post(parm);

            // Assert
            var result = resultData.Result as OkObjectResult;
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual("Not found", result.Value);
        }

        [Test]
        public async Task TestCustomerInquiryController_WithCustIdAndEmailIsNull_ShouldReturnBadRequest()
        {
            // Arrange
            ParameterInput parm = new ParameterInput();

            //Act
            CustomerInquiryController controller = new CustomerInquiryController(mockcustomerService.Object, mapper);
            var resultData = await controller.Post(parm);

            // Assert
            var result = resultData.Result as BadRequestObjectResult;
            Assert.AreEqual(400, result.StatusCode);
            Assert.NotNull(result.Value);
        }

    }
}