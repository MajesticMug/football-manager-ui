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

        public ImportLeagueCommandHandler(
            IFootballDataApiClient apiClient, 
            IMapper mapper,
            ICompetitionRepository competitionRepository)
        {
            _apiClient = apiClient;
            _mapper = mapper;
            _competitionRepository = competitionRepository;
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

                if (competitionDto == null)
                {
                    throw new LeagueNotFoundException();
                }

                var teamDtos = await _apiClient.GetTeamsByCompetition(competitionDto.Id);

                competition = _mapper.Map<Competition>(competitionDto);

                foreach (var teamDto in teamDtos)
                {
                    try
                    {
                        teamDto.Squad = (await _apiClient.GetPlayersByTeamAsync(teamDto.Id))
                            .Where(squadMember =>
                                squadMember.Role.Equals("Player", StringComparison.OrdinalIgnoreCase)).ToArray();
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

                var teams = teamDtos.Select(teamDto => _mapper.Map<Team>(teamDto)).ToList();

                await _competitionRepository.SaveCompetitionAsync(competition, teams);

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
