using Football.Api.Exceptions.Base;

namespace Football.Api.Exceptions
{
    public class ConnectivityException : ServerErrorException
    {
        public ConnectivityException() : base("Server Error")
        {
        }
    }
}
