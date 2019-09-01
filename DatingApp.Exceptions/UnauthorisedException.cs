using System;
using DA.Digital.CRM.Exceptions.Enums;

namespace DA.Digital.CRM.Exceptions
{
    public class UnauthorisedException : ApiException
    {
        public UnauthorisedException(ErrorCodesReference errorCodes, string exMessage, Exception innerException = null) : base(errorCodes, exMessage, innerException)
        {
        }
        public override ErrorType Type => ErrorType.Security;
    }
}