using System;
using System.Collections.Generic;
using System.Text;

namespace Mk.BusinessLibrary.Payment.Errors
{
    internal static class AllModuleError
    {
        internal static ModuleError PaymentSvcError => new ModuleError
        {
            Code = nameof(PaymentSvcError),
            Message = "{0}"
        };
    }
}
    