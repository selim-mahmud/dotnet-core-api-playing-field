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
        [ErrorCode("P00004", "Access is Denied.")]
        GeneralAccessDenied,
        [ErrorCode("P00006", "Terms and Conditions Not Accepted.")]
        GeneralTermsAndConditionsNotAccepted,
        [ErrorCode("P00008", "This functionality has not been implemented or enabled")]
        GeneralNotImplemented,
        [ErrorCode("P00009", "Request timed out.")]
        GeneralTimeout,
        [ErrorCode("P00010", "Matching record not found.")]
        GeneralNotFound,
        [ErrorCode("P00011", "The system is temporarily unavailable.")]
        GeneralSystemUnavailable,
        [ErrorCode("P00012", "User is not authorised to perform this action.")]
        GeneralUnauthorised,
        [ErrorCode("P00013", "Service Error.")]
        GeneralServiceError,
        #endregion
    }
}