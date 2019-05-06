using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mk.BusinessLibrary.Payment.Entities;

namespace Mk.BusinessLibrary.Payment
{
    public interface IPaymentModule
    {
        Task<string> CreatePaymentInfoAsync(PaymentInfo paymentInfo);
        Task<PaymentStatusInfo> GetPaymentDetailAsync(string paymentNo);
        Task<TransactionResponse> PostTransactionPrepareAsync(TransactionRequest transactionRequest);
    }
}
