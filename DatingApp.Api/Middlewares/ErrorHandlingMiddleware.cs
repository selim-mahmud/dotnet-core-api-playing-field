using DA.Digital.CRM.Exceptions;
using DA.Digital.CRM.Exceptions.Attributes;
using DA.Digital.CRM.Exceptions.Enums;
using DatingApp.Common.Exceptions;
using DatingApp.Common.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace DatingApp.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            this._next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Handle exception and build reponse body
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //defaults
            var httpStatusCode = HttpStatusCode.InternalServerError;
            var errorRefCode = ErrorCodesReference.GeneralUnexpected;
            object errorCode = errorRefCode.GetAttribute<ErrorCodeAttribute>().Code;
            object errorMessage = errorRefCode.GetAttribute<ErrorCodeAttribute>().Message;
            object errorType = ErrorType.General.ToString();

            //check exception types
            if (exception is UnauthorisedException)
            {
                //crm api base exception
                var ex = exception as ApiException;
                errorCode = ex.ErrorCodes.GetAttribute<ErrorCodeAttribute>().Code;
                errorMessage = ex.ErrorCodes.GetAttribute<ErrorCodeAttribute>().Message;
                errorType = ex.Type.ToString();
                if (!String.IsNullOrEmpty(ex.Message))
                {
                    errorMessage = ex.Message;
                }
                httpStatusCode = HttpStatusCode.Unauthorized;
            }
            else if (exception is ApiException)
            {
                //crm api base exception
                var ex = exception as ApiException;
                errorCode = ex.ErrorCodes.GetAttribute<ErrorCodeAttribute>().Code;
                errorMessage = ex.ErrorCodes.GetAttribute<ErrorCodeAttribute>().Message;
                if (!String.IsNullOrEmpty(ex.Message))
                {
                    errorMessage = ex.Message;
                }
                errorType = ex.Type.ToString();
                httpStatusCode = HttpStatusCode.BadRequest;
            }
            else if (exception is HttpErrorWrapperException)
            {
                //wrapped http requests
                var ex = exception as HttpErrorWrapperException;
                httpStatusCode = HttpStatusCode.BadRequest;
                var httpError = ex.HttpError;
                if (httpError != null)
                {
                    httpError.TryGetValue("Code", out errorCode);
                    httpError.TryGetValue("ErrorType", out errorType);
                    httpError.TryGetValue("Message", out errorMessage);
                }
            }

            var responseBody = JsonConvert.SerializeObject(new
            {
                code = errorCode,
                message = errorMessage,
                errorType = errorType
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpStatusCode;
            return context.Response.WriteAsync(responseBody);
        }
    }
}
