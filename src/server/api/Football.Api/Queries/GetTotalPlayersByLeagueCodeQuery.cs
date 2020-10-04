using System.Threading.Tasks;
using Football.Api.ResponseModels;
using MediatR;

namespace Football.Api.Queries
{
    public class GetTotalPlayersByLeagueCodeQuery : IRequest<TotalPlayersResponse>
    {
        public string LeagueCode { get; set; }
    }
}
