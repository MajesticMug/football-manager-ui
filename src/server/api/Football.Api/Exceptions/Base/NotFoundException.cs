using System.Net;

namespace Football.Api.Exceptions.Base
{
    public abstract class NotFoundException : ApiException
    {
        protected NotFoundException(string message) : base(message)
        {
        }

        public override HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.NotFound;
        }
    }
}
