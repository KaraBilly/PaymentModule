using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Mk.BusinessLibrary.Payment.Entities;
using Mk.BusinessLibrary.Payment.Errors;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mk.BusinessLibrary.Payment
{
    public class PaymentModule : IPaymentModule
    {
        private const string PaymentSvc = nameof(PaymentSvc);
        private const string CreatePaymentUrl = "/v1/payments";
        private const string PaymentQueryUrl = "/v1/payments/details/{0}/order-query";
        private const string TransactionPrepareUrl = "/v1/payments/transaction/prepare";
        private const string MediaType = "application/json";
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _paymentBaseUrl;
        
        public PaymentModule(IHttpClientFactory httpClientFactory,string paymentBaseUrl)
        {
            _httpClientFactory = httpClientFactory;
            _paymentBaseUrl = paymentBaseUrl;
        }
        
        public async Task<string> CreatePaymentInfoAsync(PaymentInfo paymentInfo)
        {
            var client = GetClient(_httpClientFactory);
            var content = JsonConvert.SerializeObject(paymentInfo);
            var stringContent = new StringContent(content, Encoding.UTF8);
            stringContent.Headers.ContentType = new MediaTypeHeaderValue(MediaType);

            var response = client.PutAsync(client.BaseAddress + CreatePaymentUrl,
                stringContent);

            var r = await response;

            if (_httpClientFactory == null)
            {
                client.Dispose();
            }

            if (r.StatusCode != HttpStatusCode.OK)
            {
                var resultTask = r.Content.ReadAsStringAsync();
                throw new PaymentException(AllModuleError.PaymentSvcError.WithMessageParameters(await resultTask));
            }

            var c = await r.Content.ReadAsStringAsync();
            var paymentDetails = JsonConvert.DeserializeObject<dynamic>(c).payment_details.ToString();
            var p = JArray.Parse(paymentDetails);
            return p.FirstOrDefault().Value<string>("payment_no");
        }

        public async Task<PaymentStatusInfo> GetPaymentDetailAsync(string paymentNo)
        {
            var client = GetClient(_httpClientFactory);
            
            var response = client.GetAsync(client.BaseAddress + string.Format(PaymentQueryUrl,paymentNo));

            var r = await response;

            if (_httpClientFactory == null)
            {
                client.Dispose();
            }

            if (r.StatusCode != HttpStatusCode.OK)
            {
                var resultTask = r.Content.ReadAsStringAsync();
                throw new PaymentException(AllModuleError.PaymentSvcError.WithMessageParameters(await resultTask));
            }

            var c = await r.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<PaymentStatusInfo>(c);
        }

        public async Task<TransactionResponse> PostTransactionPrepareAsync(TransactionRequest transactionRequest)
        {
            var client = GetClient(_httpClientFactory);
            var content = JsonConvert.SerializeObject(transactionRequest);
            var stringContent = new StringContent(content, Encoding.UTF8);
            var response = client.PostAsync(client.BaseAddress + TransactionPrepareUrl,stringContent);

            var r = await response;

            if (_httpClientFactory == null)
            {
                client.Dispose();
            }

            if (r.StatusCode != HttpStatusCode.OK)
            {
                var resultTask = r.Content.ReadAsStringAsync();
                throw new PaymentException(AllModuleError.PaymentSvcError.WithMessageParameters(await resultTask));
            }

            var c = await r.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TransactionResponse>(c);
        }

        private HttpClient GetClient(IHttpClientFactory httpClientFactory)
        {
            if (httpClientFactory == null)
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(_paymentBaseUrl);
                client.Timeout= new TimeSpan(0,0,60);
                return client;
            }

            return httpClientFactory.CreateClient(PaymentSvc);
        }
    }
}
