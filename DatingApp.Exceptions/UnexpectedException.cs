using System;
using DA.Digital.CRM.Exceptions.Enums;

namespace DA.Digital.CRM.Exceptions
{
    public class UnexpectedException : ApiException
    {
        public UnexpectedException(ErrorCodesReference errorCodes, string errorMessage, Exception innerException = null) : base(errorCodes, errorMessage, innerException)
        {
        }

        public override ErrorType Type => ErrorType.General;
    }
}
