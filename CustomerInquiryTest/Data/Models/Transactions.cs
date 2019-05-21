using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInquiryTest.Data.Models
{
    public class Transactions
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid Amount")]
        public decimal Amount { get; set; }
        [StringLength(3)]
        public string CurrencyCode { get; set; }
        public StatusCode Status { get; set; }
    }

    public enum StatusCode
    {
        Success, Failed, Canceled
    }
}
