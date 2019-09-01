using System;
using System.Net;
using System.Web.Http;

namespace DatingApp.Common.Exceptions
{
    public class HttpErrorWrapperException : Exception
    {
        public HttpErrorWrapperException(HttpError error, HttpStatusCode statusCode)
        {
            HttpError = error;
            StatusCode = statusCode;
        }

        public HttpError HttpError { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
