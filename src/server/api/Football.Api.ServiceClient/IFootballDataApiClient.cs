using System.Threading.Tasks;
using Football.Api.ServiceClient.Dtos;

namespace Football.Api.ServiceClient
{
    public interface IFootballDataApiClient
    {
        Task<CompetitionDto> GetCompetitionByLeagueCodeAsync(string leagueCode);
        Task<TeamDto[]> GetTeamsByCompetition(string competitionId);
        Task<SquadMemberDto[]> GetPlayersByTeamAsync(string teamId);
    }
}
