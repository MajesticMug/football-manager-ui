using MediatR;

namespace Football.Api.Commands
{
    public class ImportLeagueCommand : IRequest
    {
        public string LeagueCode { get; set; }
    }
}
