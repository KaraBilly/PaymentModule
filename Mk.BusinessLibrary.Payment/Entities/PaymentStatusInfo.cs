using Newtonsoft.Json;

namespace Mk.BusinessLibrary.Payment.Entities
{
    public class PaymentStatusInfo
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("pay_date")]
        public string PayDate { get; set; }
        [JsonProperty("payment_no")]
        public string PaymentNo { get; set; }
        [JsonProperty("return_code")]
        public string ReturnCode { get; set; }
        [JsonProperty("return_msg")]
        public string ReturnMsg { get; set; }
        [JsonProperty("trade_desc")]
        public string TradeDesc { get; set; }
        [JsonProperty("trade_state")]
        public string TradeState { get; set; }
    }
}