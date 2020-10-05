using Football.Api.Exceptions.Base;

namespace Football.Api.Exceptions
{
    public class EntityNotFoundException : NotFoundException
    {
        public EntityNotFoundException() : base("Not found")
        {
        }
    }
}
