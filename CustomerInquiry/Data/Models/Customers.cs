using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInquiry.Data.Models
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
        [RegularExpression(@"^[0-9]{8,10}$", ErrorMessage = "Enter a valid 10 digit Phone")]
        public int MobileNo { get; set; }
        public List<Transactions> Transactions { get; set; }
    }

    public class CustomersViewModel
    {
        [JsonProperty(PropertyName = "customerID")]
        public int CustomerId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string CustomerName { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string ContactEmail { get; set; }
        [JsonProperty(PropertyName = "mobile")]
        public int MobileNo { get; set; }
        [JsonProperty(PropertyName = "transactions")]
        public List<TransactionsViewModel> Transactions { get; set; }
    }
}
