using Football.Api.Models;
using MediatR;

namespace Football.Api.Queries
{
    public class GetPlayersByTeamCodeQuery : IRequest<Player[]>
    {
        public string TeamCode { get; set; }
    }
}
