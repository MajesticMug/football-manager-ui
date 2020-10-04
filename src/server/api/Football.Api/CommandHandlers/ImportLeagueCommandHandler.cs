using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Football.Api.Commands;
using Football.Api.Exceptions;
using Football.Api.Models;
using Football.Api.Repositories.Interfaces;
using Football.Api.ServiceClient;
using Football.Api.ServiceClient.Exceptions;
using MediatR;

namespace Football.Api.CommandHandlers
{
    public class ImportLeagueCommandHandler : IRequestHandler<ImportLeagueCommand>
    {
        private readonly IFootballDataApiClient _apiClient;
        private readonly IMapper _mapper;
        private readonly ICompetitionRepository _competitionRepository;
        private readonly ITeamRepository _teamRepository;

        public ImportLeagueCommandHandler(
            IFootballDataApiClient apiClient, 
            IMapper mapper,
            ICompetitionRepository competitionRepository, 
            ITeamRepository teamRepository)
        {
            _apiClient = apiClient;
            _mapper = mapper;
            _competitionRepository = competitionRepository;
            _teamRepository = teamRepository;
        }

        public async Task<Unit> Handle(ImportLeagueCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var competition = await _competitionRepository.GetCompetitionByCodeAsync(request.LeagueCode);

                if (competition != null)
                {
                    throw new LeagueAlreadyImportedException();
                }

                var competitionDto = await _apiClient.GetCompetitionByLeagueCodeAsync(request.LeagueCode);

                var teamDtos = await _apiClient.GetTeamsByCompetition(competitionDto.Id);

                competition = _mapper.Map<Competition>(competitionDto);

                var teams = teamDtos.Select(teamDto => _mapper.Map<Team>(teamDto)).ToList();

                await _competitionRepository.SaveCompetitionAsync(competition, teams);

                foreach (var teamDto in teamDtos)
                {
                    try
                    {
                        var team = _mapper.Map<Team>(teamDto);

                        var players = (await _apiClient.GetPlayersByTeamAsync(teamDto.Id))
                            .Where(squadMember =>
                                squadMember.Role.Equals("Player", StringComparison.OrdinalIgnoreCase))
                            .Select(dto => _mapper.Map<Player>(dto)).ToList();

                        await _teamRepository.SaveTeamAsync(team.Code, players);
                    }
                    catch (RequestNumberLimitExceededException)
                    {
                        // The API doesn't have a way to get all Teams with Players included
                        // By competitionId so we have to go through each one and fetch the Players
                        // So we just stop once we exceed the limit of request
                        // This can be solved either by using a credit card or enqueuing the pending items
                        // And processing them with a retry mechanism
                        break;
                    }
                }

                // Unit represents a void return type in MeadiatR
                return Unit.Value;
            }
            catch (Exception e)
            {
                if (e is RequestNumberLimitExceededException || e is ServiceClientUnknownErrorException)
                {
                    throw new ConnectivityException();
                }

                throw;
            }
        }
    }
}
