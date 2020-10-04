using System.Threading.Tasks;
using Football.Api.ServiceClient.Dtos;

namespace Football.Api.ServiceClient
{
    public interface IFootballDataApiClient
    {
        Task<CompetitionDto> GetCompetitionByLeagueCodeAsync(string leagueCode);
        Task<TeamDto[]> GetTeamsByCompetition(int competitionId);
        Task<SquadMemberDto[]> GetPlayersByTeamAsync(int teamId);
    }
}
