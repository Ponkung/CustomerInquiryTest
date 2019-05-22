using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerInquiry.Data.Models;
using CustomerInquiry.Repository;

namespace CustomerInquiry.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly ITransactionRepository transactionRepository;
        private readonly IUnitOfWork unitOfWork;
        public CustomerService(ICustomerRepository customerRepository, ITransactionRepository transactionRepository, IUnitOfWork unitOfWork) {
            this.customerRepository = customerRepository;
            this.transactionRepository = transactionRepository;
            this.unitOfWork = unitOfWork;
        }
        public Customers GetCustomerTransactionByCustomerId(int customerId)
        {
            var customerData = customerRepository.GetCustomerByCustID(customerId).Result;
            if (customerData != null){
                customerData.Transactions = GetTransactionData(customerData);
            }
            return customerData;
        }

        public Customers GetCustomerTransactionByCustomerEmail(string email)
        {
            var customerData = customerRepository.GetCustomerByCustEmail(email).Result;
            if (customerData != null){
                customerData.Transactions = GetTransactionData(customerData);
            }
            return customerData;
        }

        public Customers GetCustomerTransactionByCustomerIdAndEmail(int customerId, string email)
        {
            var customerData = customerRepository.GetCustomerByCustIdAndEmail(customerId, email).Result;
            if (customerData != null) {
                customerData.Transactions = GetTransactionData(customerData);
            }
            return customerData;
        }

        private List<Transactions> GetTransactionData(Customers customer) {
            return transactionRepository.GetTransactionByCustomer(customer).Result;
        }

        public void AddCustomer(Customers customer)
        {
            customerRepository.SaveCustomer(customer);
            unitOfWork.SaveChanges();
        }
    }
}
