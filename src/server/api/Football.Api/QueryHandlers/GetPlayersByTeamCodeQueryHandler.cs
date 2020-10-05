using System.Threading;
using System.Threading.Tasks;
using Football.Api.Exceptions;
using Football.Api.Models;
using Football.Api.Queries;
using Football.Api.Repositories.Interfaces;
using MediatR;

namespace Football.Api.QueryHandlers
{
    public class GetPlayersByTeamCodeQueryHandler : IRequestHandler<GetPlayersByTeamCodeQuery, Player[]>
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ITeamRepository _teamRepository;

        public GetPlayersByTeamCodeQueryHandler(IPlayerRepository playerRepository, ITeamRepository teamRepository)
        {
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
        }

        public async Task<Player[]> Handle(GetPlayersByTeamCodeQuery request, CancellationToken cancellationToken)
        {
            var team = await _teamRepository.GetTeamByCodeAsync(request.TeamCode);

            if (team == null)
            {
                throw new EntityNotFoundException();
            }

            return (await _playerRepository.GetPlayersByTeamIdAsync(team.Id)).ToArray();
        }
    }
}
