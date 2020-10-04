using System;
using System.Net;

namespace Football.Api.Exceptions.Base
{
    /// <summary>
    /// Represents a generic API Exception that results in an HTTP Response with a message inside its body
    /// </summary>
    public abstract class ApiException : Exception
    {
        protected ApiException(string message) : base(message)
        {
        }

        public abstract HttpStatusCode GetStatusCode();
    }
}
