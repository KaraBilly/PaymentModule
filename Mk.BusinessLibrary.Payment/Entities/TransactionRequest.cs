using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Mk.BusinessLibrary.Payment.Entities
{

    public class TransactionRequest
    {
        [JsonProperty("ocean_wechat_additional_params")]
        public OceanWechatAdditionalParams OceanWechatAdditionalParams { get; set; }
        [JsonProperty("payment_no")]
        public long PaymentNo { get; set; }
        [JsonProperty("product_desc")]
        public string ProductDesc { get; set; }
    }
    public class OceanWechatAdditionalParams
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("product_name")]
        public string ProductName { get; set; }
        [JsonProperty("residence_id")]
        public string ResidenceId { get; set; }
    }

}
