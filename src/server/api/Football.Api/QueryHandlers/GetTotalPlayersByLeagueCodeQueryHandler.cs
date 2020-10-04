using System.Threading;
using System.Threading.Tasks;
using Football.Api.Queries;
using MediatR;

namespace Football.Api.QueryHandlers
{
    public class GetTotalPlayersByLeagueCodeQueryHandler : IRequestHandler<GetTotalPlayersByLeagueCodeQuery, int>
    {
        public Task<int> Handle(GetTotalPlayersByLeagueCodeQuery request, CancellationToken cancellationToken)
        {
            // TODO
            return Task.FromResult(100);
        }
    }
}
