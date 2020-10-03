using System;

namespace Football.Api.ServiceClient.Exceptions
{
    public abstract class ServiceClientException : Exception
    {
        protected ServiceClientException(string message) : base(message)
        {

        }
    }
}
