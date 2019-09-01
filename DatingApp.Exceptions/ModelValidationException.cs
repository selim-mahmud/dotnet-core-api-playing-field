using System;
using DA.Digital.CRM.Exceptions.Enums;

namespace DA.Digital.CRM.Exceptions
{
    public class ModelValidationException : ApiException
    {
        public ModelValidationException(ErrorCodesReference errorCodes, string exMessage, Exception innerException = null) : base(errorCodes, exMessage, innerException)
        {
            
        }

        public override ErrorType Type => ErrorType.Model;
    
    }
}
