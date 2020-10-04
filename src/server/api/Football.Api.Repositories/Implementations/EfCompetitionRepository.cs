using System;
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
    public class EfCompetitionRepository : ICompetitionRepository
    {
        private readonly FootballDbContext _dbContext;

        public EfCompetitionRepository(FootballDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Competition> GetCompetitionByCodeAsync(string code)
        {
            return await _dbContext.Competitions.FirstOrDefaultAsync(competition => competition.Code.Equals(code));
        }

        public async Task SaveCompetitionAsync(Competition competition, List<Team> teams)
        {
            var code = new SqlParameter("Code", SqlDbType.VarChar) {Value = competition.Code};
            var name = new SqlParameter("Name", SqlDbType.VarChar) { Value = competition.Name };
            var areaName = new SqlParameter("AreaName", SqlDbType.VarChar) { Value = (object) competition.AreaName ?? DBNull.Value };

            var teamsParam = new SqlParameter("Teams", SqlDbType.Structured)
            {
                Value = teams.ToDataTable(),
                TypeName = "dbo.TeamType"
            };

            var playersParam = new SqlParameter("Players", SqlDbType.Structured)
            {
                Value = GetTeamPlayers(teams).ToDataTable(),
                TypeName = "dbo.PlayerType"
            };

            var competitionId = new SqlParameter("CompetitionId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            await _dbContext.Database.ExecuteSqlRawAsync("dbo.SaveCompetition @Code, @Name, @Teams, @Players, @AreaName, @CompetitionId OUT",
                code, name, teamsParam, playersParam, areaName, competitionId);

            competition.Id = Convert.ToInt32(competitionId.Value);
        }

        public async Task<List<Competition>> GetAllCompetitionsAsync()
        {
            return await _dbContext.Competitions.ToListAsync();
        }

        private List<Player> GetTeamPlayers(List<Team> teams)
        {
            foreach (var team in teams)
            {
                // Assign TeamCode to each Player needed for the database Type
                foreach (var player in team.Players)
                {
                    player.TeamCode = team.Code;
                }
            }

            return teams.SelectMany(team => team.Players).ToList();
        }
    }
}
