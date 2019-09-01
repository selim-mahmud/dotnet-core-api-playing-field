using DA.Digital.CRM.Exceptions;
using DA.Digital.CRM.Exceptions.Enums;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatingApp.Api.Filters
{
    public class ValidateModelAttribute: ActionFilterAttribute
    {
        private ILogger<ValidateModelAttribute> _logger;

        public ValidateModelAttribute(ILogger<ValidateModelAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errorMessages = GetErrorMessages(context.ModelState);
                throw new ModelValidationException(ErrorCodesReference.InvalidModelState, errorMessages.FirstOrDefault(), null);
            }
        }

        private List<string> GetErrorMessages(ModelStateDictionary modelState)
        {
            var errorMessages = new List<string>();
            if (modelState == null) return errorMessages;
            try
            {
                foreach (var value in modelState.Values)
                {
                    foreach (var valueError in value.Errors)
                    {
                        errorMessages.Add(valueError.ErrorMessage);
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to retrieve error messages from ModelState");
            }

            return errorMessages;
        }
    }
}
