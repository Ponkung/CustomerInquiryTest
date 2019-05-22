using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CustomerInquiry.Data.Models;
using CustomerInquiry.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerInquiry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInquiryController : Controller
    {
        private ICustomerService customerService;
        private readonly IMapper mapper;
        public CustomerInquiryController(ICustomerService customerService, IMapper mapper) {
            this.customerService = customerService;
            this.mapper = mapper;
        }
        // GET: /<controller>/
        public ActionResult<string> Index()
        {
            return "Please use postman to test this api (use post method)";
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Customers>> Post(ParameterInput value)
        {
            if (!value.customerID.HasValue && string.IsNullOrEmpty(value.email))
            {
                var validationMessage = "No inquiry criteria";
                this.ModelState.AddModelError("customerID", validationMessage);
            }
            if (ModelState.IsValid)
            {
                try
                {
                    Customers customer = null;
                    if (value.customerID.HasValue && !string.IsNullOrEmpty(value.email)) {
                        customer = customerService.GetCustomerTransactionByCustomerIdAndEmail(value.customerID.Value, value.email);
                    } else if (value.customerID.HasValue) {
                        customer = customerService.GetCustomerTransactionByCustomerId(value.customerID.Value); 
                    } else if (!string.IsNullOrEmpty(value.email)){
                        customer = customerService.GetCustomerTransactionByCustomerEmail(value.email);
                    }
                    if (customer != null) {
                        return Ok(new { results = mapper.Map<CustomersViewModel>(customer) });
                    }
                    return Ok("Not found");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return BadRequest();
                }
            }

            return BadRequest(ModelState);
        }
    }
}
