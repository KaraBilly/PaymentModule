using Mk.BusinessLibrary.Payment.Entities;
using System;
using System.Threading.Tasks;
using Mk.BusinessLibrary.Payment.Utils;
using Newtonsoft.Json;
using Xunit;

namespace Mk.BusinessLibrary.Payment.Test
{
    public class PaymentModuleTest
    {
        private readonly IPaymentModule _paymentModule;
        private const string PaymentUrl = "https://services.ebz-chn-dev.mkaws.com/mkpayservices";
        
        public PaymentModuleTest()
        {
            _paymentModule = new PaymentModule(null, PaymentUrl);
        }
        [Fact]
        public async Task CreatePaymentInfoTest()
        {
            var paymentInfo = new PaymentInfo
            {
                Amount = 0.01M,
                BankId = 33,
                ChannelId = 6,
                IsNeedSplitPay = false,
                RefDesc ="SDS",
                UserType = 2
            };
            // await _paymentModule.CreatePaymentInfoAync(paymentInfo);
        }
    }
}
