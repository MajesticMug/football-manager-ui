using System;

namespace Football.Api.ServiceClient.Exceptions
{
    public class RequestNumberLimitExceededException : ServiceClientException
    {
        public RequestNumberLimitExceededException(string message) : base(message)
        {
        }
    }
}
