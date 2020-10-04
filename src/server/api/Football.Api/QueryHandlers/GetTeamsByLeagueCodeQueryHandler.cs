using System.Threading;
using System.Threading.Tasks;
using Football.Api.Exceptions;
using Football.Api.Models;
using Football.Api.Queries;
using Football.Api.Repositories.Interfaces;
using MediatR;

namespace Football.Api.QueryHandlers
{
    public class GetTeamsByLeagueCodeQueryHandler : IRequestHandler<GetTeamsByLeagueCodeQuery, Team[]>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ICompetitionRepository _competitionRepository;

        public GetTeamsByLeagueCodeQueryHandler(ITeamRepository teamRepository, ICompetitionRepository competitionRepository)
        {
            _teamRepository = teamRepository;
            _competitionRepository = competitionRepository;
        }

        public async Task<Team[]> Handle(GetTeamsByLeagueCodeQuery request, CancellationToken cancellationToken)
        {
            var competition = await _competitionRepository.GetCompetitionByCodeAsync(request.LeagueCode);

            if (competition == null)
            {
                throw new LeagueNotFoundException();
            }

            return (await _teamRepository.GetTeamsByCompetitionIdAsync(competition.Id)).ToArray();
        }
    }
}
