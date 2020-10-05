using System.Collections.Generic;
using System.Threading.Tasks;
using Football.Api.Models;

namespace Football.Api.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        Task<Team> GetTeamByCodeAsync(string teamCode);
        Task<List<Team>> GetTeamsByCompetitionIdAsync(int competitionId);
    }
}
