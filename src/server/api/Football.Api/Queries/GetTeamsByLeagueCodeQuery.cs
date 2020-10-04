using Football.Api.Models;
using MediatR;

namespace Football.Api.Queries
{
    public class GetTeamsByLeagueCodeQuery : IRequest<Team[]>
    {
        public string LeagueCode { get; set; }
    }
}
