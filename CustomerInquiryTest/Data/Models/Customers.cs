using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInquiryTest.Data.Models
{
    public class Customers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Range(1, 1000000000, ErrorMessage = "Value must be between 1 to 1000000000")]
        public int CustomerId { get; set; }
        [StringLength(30)]
        public string CustomerName { get; set; }
        [EmailAddress]
        [StringLength(25)]
        public string ContactEmail { get; set; }
        [DataType(DataType.PhoneNumber)]
        public int MobileNo { get; set; }
        public virtual List<Transactions> Transactions { get; set; }
}
}
