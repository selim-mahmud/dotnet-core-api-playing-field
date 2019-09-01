using System;
using DA.Digital.CRM.Exceptions.Enums;

namespace DA.Digital.CRM.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(ErrorCodesReference errorCodes, string exMessage, Exception innerException = null)
            : base(exMessage, innerException)
        {
            ErrorCodes = errorCodes;
        }

        public virtual ErrorType Type => ErrorType.General;
        public ErrorCodesReference ErrorCodes { get; set; }
    }
}
