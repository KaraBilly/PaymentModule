using System;
using System.Collections.Generic;
using System.Text;

namespace Mk.BusinessLibrary.Payment.Errors
{
    public static class ErrorExtensions
    {
        public static ModuleError WithMessageParameters(this ModuleError error, params object[] args)
        {
            var result = error.Copy();
            result.Message = string.Format(error.Message, args);
            return result;
        }

        public static ModuleError Copy(this ModuleError error)
        {
            return new ModuleError
            {
                Code = error.Code,
                Message = error.Message,
                Data = error.Data
            };
        }
    }
}
