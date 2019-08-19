using System;

namespace DA.Digital.CRM.Exceptions.Attributes
{
    public class ErrorCodeAttribute : Attribute
    {

        public ErrorCodeAttribute(string code, string message)
        {
            Message = message;
            Code = code;
        }

        public string Code { get; set; }

        public string Message { get; set; }
    }
}
