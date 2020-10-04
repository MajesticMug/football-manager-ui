using System.Net;

namespace Football.Api.Exceptions.Base
{
    public abstract class ConflictException : ApiException
    {
        protected ConflictException(string message) : base(message)
        {
        }

        public override HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.Conflict;
        }
    }
}
