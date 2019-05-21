using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInquiry.Data.Models
{
    public class ParameterInput
    {
        [Range(1, 1000000000, ErrorMessage = "Value must be between 1 to 1000000000")]
        public int customerID { get; set; }
        [EmailAddress]
        [StringLength(25)]
        public string email { get; set; }
    }
}
