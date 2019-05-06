using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Mk.BusinessLibrary.Payment.Entities
{
    public class PaymentInfo
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("bank_id")]
        public short BankId { get; set; }
        [JsonProperty("channel_id")]
        public short ChannelId { get; set; }
        [JsonProperty("is_need_split_pay")]
        public bool IsNeedSplitPay { get; set; }
        [JsonProperty("ref_desc")]
        public string RefDesc { get; set; }
        [JsonProperty("ref_id")]
        public string RefId { get; set; }
        [JsonProperty("source")]
        public string Source { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("user_type")]
        public short UserType { get; set; }
    }
}