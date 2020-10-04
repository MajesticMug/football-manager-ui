using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Football.Api.Models;
using Football.Api.Repositories.Extensions;
using Football.Api.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Football.Api.Repositories.Implementations
{
    public class EfTeamRepository : ITeamRepository
    {
        private readonly FootballDbContext _dbContext;

        public EfTeamRepository(FootballDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveTeamPlayersAsync(string teamCode, List<Player> players)
        {
            var competitionIdParameter = new SqlParameter("TeamCode", SqlDbType.Int) {Value = teamCode};

            var playersParameter = new SqlParameter("Players", SqlDbType.Structured)
            {
                Value = players.ToDataTable(), 
                TypeName = "dbo.PlayerType"
            };

            await _dbContext.Database.ExecuteSqlRawAsync(
                "dbo.SaveTeamPlayers @TeamCode, @Players",
                competitionIdParameter, playersParameter);
        }

        public async Task<List<Team>> GetTeamsByCompetitionIdAsync(int competitionId)
        {
            return await _dbContext.Competitions
                .Where(competition => competition.Id == competitionId)
                .SelectMany(competition => competition.CompetitionTeams)
                .Select(ct => ct.Team)
                .ToListAsync();
        }
    }
}
