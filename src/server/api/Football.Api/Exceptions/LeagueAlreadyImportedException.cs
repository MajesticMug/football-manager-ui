using Football.Api.Exceptions.Base;

namespace Football.Api.Exceptions
{
    public class LeagueAlreadyImportedException : ConflictException
    {
        public LeagueAlreadyImportedException() : base("League already imported")
        {
        }
    }
}
