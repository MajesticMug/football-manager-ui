using System;
using System.Linq;
using System.Threading.Tasks;
using Football.Api.ServiceClient.Dtos;
using Football.Api.ServiceClient.Dtos.RootObjects;

namespace Football.Api.ServiceClient
{
    public class FootballDataApiClient : IFootballDataApiClient
    {
        private readonly IServiceClient _serviceClient;

        public FootballDataApiClient(IServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        public async Task<CompetitionDto> GetCompetitionByLeagueCodeAsync(string leagueCode)
        {
            var root = await _serviceClient.GetRootAsync<CompetitionsRootObject>("competitions");

            return root
                .Competitions
                .SingleOrDefault(c =>
                    leagueCode.Equals(c.Code, StringComparison.InvariantCultureIgnoreCase));
        }

        public async Task<TeamDto[]> GetTeamsByCompetition(int competitionId)
        {
            var root = await _serviceClient.GetRootAsync<TeamsRootObject>($"competitions/{competitionId}/teams");

            return root.Teams ?? Array.Empty<TeamDto>();
        }

        public async Task<SquadMemberDto[]> GetPlayersByTeamAsync(int teamId)
        {
            return (await _serviceClient.GetRootAsync<TeamDto>($"teams/{teamId}"))
                .Squad ?? Array.Empty<SquadMemberDto>();
        }
    }
}
