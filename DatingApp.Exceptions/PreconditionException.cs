using System;
using DA.Digital.CRM.Exceptions.Enums;

namespace DA.Digital.CRM.Exceptions
{
    public class PreconditionException : ApiException
    {
        public PreconditionException(ErrorCodesReference errorCodes, string exMessage, Exception innerException = null) : base(errorCodes, exMessage, innerException)
        {
        }
        public override ErrorType Type => ErrorType.PreconditionValidation;
    }
}