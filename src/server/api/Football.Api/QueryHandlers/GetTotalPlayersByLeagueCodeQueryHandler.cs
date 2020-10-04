using System.Threading;
using System.Threading.Tasks;
using Football.Api.Queries;
using Football.Api.Repositories.Interfaces;
using Football.Api.ResponseModels;
using MediatR;

namespace Football.Api.QueryHandlers
{
    public class GetTotalPlayersByLeagueCodeQueryHandler : IRequestHandler<GetTotalPlayersByLeagueCodeQuery, TotalPlayersResponse>
    {
        private readonly IPlayerRepository _playerRepository;

        public GetTotalPlayersByLeagueCodeQueryHandler(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<TotalPlayersResponse> Handle(GetTotalPlayersByLeagueCodeQuery request, CancellationToken cancellationToken)
        {
            return new TotalPlayersResponse
            {
                Total = await _playerRepository.GetTotalPlayersByCompetitionCodeAsync(request.LeagueCode)
            };
        }
    }
}
