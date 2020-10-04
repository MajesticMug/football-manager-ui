using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Football.Api.Models;
using Football.Api.Repositories.Extensions;
using Football.Api.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Football.Api.Repositories.Implementations
{
    public class TeamRepository : ITeamRepository
    {
        private readonly FootballDbContext _dbContext;

        public TeamRepository(FootballDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveTeamAsync(string teamCode, List<Player> players)
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
    }
}
