using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Football.Api.Models;
using Football.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Football.Api.Repositories.Implementations
{
    public class EfPlayerRepository : IPlayerRepository
    {
        private readonly FootballDbContext _dbContext;

        public EfPlayerRepository(FootballDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> GetTotalPlayersByCompetitionCodeAsync(string competitionCode)
        {
            return await _dbContext.Competitions.Where(competition => competition.Code.Equals(competitionCode))
                .SelectMany(competition => competition.CompetitionTeams)
                .SelectMany(competitionTeam => competitionTeam.Team.Players)
                .CountAsync();
        }

        public async Task<List<Player>> GetPlayersByTeamIdAsync(int teamId)
        {
            return await _dbContext.Players.AsNoTracking().Where(player => player.TeamId == teamId).ToListAsync();
        }
    }
}
