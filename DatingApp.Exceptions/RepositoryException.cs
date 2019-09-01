using System;
using DA.Digital.CRM.Exceptions.Enums;

namespace DA.Digital.CRM.Exceptions
{
    public class RepositoryException : ApiException
    {
        public RepositoryException(ErrorCodesReference errorCodes, string exMessage, Exception innerException = null) : base(errorCodes, exMessage, innerException)
        {
        }
        public override ErrorType Type => ErrorType.Repository;
    }
}