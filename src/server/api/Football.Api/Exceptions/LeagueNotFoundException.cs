using Football.Api.Exceptions.Base;

namespace Football.Api.Exceptions
{
    public class LeagueNotFoundException : NotFoundException
    {
        public LeagueNotFoundException() : base("Not found")
        {
        }
    }
}
