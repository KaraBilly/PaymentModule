using System;

namespace Mk.BusinessLibrary.Payment.Errors
{
    public class PaymentException : Exception
    {
        public PaymentException(ModuleError error)
        {
            Error = error;
        }

        public ModuleError Error { get; set; }
    }
}
