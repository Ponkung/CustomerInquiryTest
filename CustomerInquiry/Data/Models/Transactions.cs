using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInquiry.Data.Models
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
        public Customers Customer { get; set; }
    }

    public enum StatusCode
    {
        Success, Failed, Canceled
    }

    public class TransactionsViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int TransactionId { get; set; }
        [JsonProperty(PropertyName = "date")]
        public string TransactionDate { get; set; }
        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }
        [JsonProperty(PropertyName = "currency")]
        public string CurrencyCode { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
