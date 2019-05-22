using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInquiry.Data.Models
{
    public class ParameterInput
    {
        [Range(1, 1000000000, ErrorMessage = "Invalid Customer ID")]
        public int? customerID { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [StringLength(25)]
        public string email { get; set; }
    }
}
