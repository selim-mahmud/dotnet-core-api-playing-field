using DA.Digital.CRM.Exceptions.Attributes;

namespace DA.Digital.CRM.Exceptions.Enums
{
    public enum ErrorCodesReference
    {
        [ErrorCode("P00000", "None")]
        None,

        #region General
        [ErrorCode("P00002", "An Unexpected error has occured.")]
        GeneralUnexpected,
        [ErrorCode("P00003", "Access is Denied.")]
        GeneralAccessDenied,
        [ErrorCode("P00004", "Terms and Conditions Not Accepted.")]
        GeneralTermsAndConditionsNotAccepted,
        [ErrorCode("P00005", "This functionality has not been implemented or enabled")]
        GeneralNotImplemented,
        [ErrorCode("P00006", "Request timed out.")]
        GeneralTimeout,
        [ErrorCode("P00007", "Matching record not found.")]
        GeneralNotFound,
        [ErrorCode("P00008", "The system is temporarily unavailable.")]
        GeneralSystemUnavailable,
        [ErrorCode("P00009", "User is not authorised to perform this action.")]
        GeneralUnauthorised,
        [ErrorCode("P00010", "Service Error.")]
        GeneralServiceError,
        [ErrorCode("P00011", "Requested model is invalid.")]
        InvalidModelState,
        #endregion
    }
}