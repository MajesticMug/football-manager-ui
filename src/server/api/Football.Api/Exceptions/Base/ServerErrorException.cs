using System.Net;

namespace Football.Api.Exceptions.Base
{
    public class ServerErrorException : ApiException
    {
        public ServerErrorException(string message) : base(message)
        {
        }

        public override HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.GatewayTimeout;
        }
    }
}
