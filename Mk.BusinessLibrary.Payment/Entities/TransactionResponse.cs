using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mk.BusinessLibrary.Payment.Entities
{
    public class TransactionResponse
    {
        [JsonProperty("bank_id")]
        public int BankId { get; set; }
        [JsonProperty("parameter_data")]
        public string ParameterData { get; set; }
        [JsonProperty("payment_url")]
        public string PaymentUrl { get; set; }
    }
}
