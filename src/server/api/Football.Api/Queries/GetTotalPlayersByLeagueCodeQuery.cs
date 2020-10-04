using System.Threading.Tasks;
using MediatR;

namespace Football.Api.Queries
{
    public class GetTotalPlayersByLeagueCodeQuery : IRequest<int>
    {
        public string LeagueCode { get; set; }
    }
}
