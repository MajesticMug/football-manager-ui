namespace Football.Api.ServiceClient.Exceptions
{
    public class ServiceClientUnknownErrorException : ServiceClientException
    {
        public ServiceClientUnknownErrorException(string message) : base(message)
        {
        }
    }
}
