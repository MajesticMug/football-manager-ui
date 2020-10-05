using System.Collections.Generic;
using System.Threading.Tasks;
using Football.Api.Models;

namespace Football.Api.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        Task<int> GetTotalPlayersByCompetitionCodeAsync(string competitionCode);
        Task<List<Player>> GetPlayersByTeamIdAsync(int teamId);
    }
}
