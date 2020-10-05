using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Football.Api.Models;
using Football.Api.Queries;
using Football.Api.QueryHandlers;
using Football.Api.Repositories;
using Football.Api.Repositories.Implementations;
using Football.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Football.Api.Tests.QueryHandlers
{
    public class GetTotalPlayersQueryHandlerTests
    {
        private readonly FootballDbContext _dbContext;
        private readonly IPlayerRepository _playerRepository;

        public GetTotalPlayersQueryHandlerTests()
        {
            _dbContext = GetMemoryDbContext();

            _playerRepository = new EfPlayerRepository(_dbContext);
        }

        [Fact]
        public async Task TotalPlayersQueryShouldReturnCorrectCount()
        {
            await SetUpPlayerCountScenario();

            var queryHandler = new GetTotalPlayersByLeagueCodeQueryHandler(_playerRepository);

            var request = new GetTotalPlayersByLeagueCodeQuery
            {
                LeagueCode = "testCompetition"
            };

            var result = await queryHandler.Handle(request, CancellationToken.None);

            Assert.Equal(2, result.Total);
        }

        private async Task SetUpPlayerCountScenario()
        {
            var testCompetition = new Competition
            {
                Code = "testCompetition",
                Name = "Test Competition"
            };

            var testTeam = new Team
            {
                Code = "testTeam",
                Name = "Test Team",
                Players = new List<Player>
                {
                    new Player
                    {
                        Code = "p1",
                        Name = "Player 1"
                    },
                    new Player
                    {
                        Code = "p2",
                        Name = "Player 2"
                    }
                }
            };

            var competitionTeam = new CompetitionTeam
            {
                Competition = testCompetition,
                Team = testTeam
            };

            await _dbContext.Competitions.AddAsync(testCompetition);
            await _dbContext.Teams.AddAsync(testTeam);
            await _dbContext.CompetitionTeams.AddAsync(competitionTeam);

            await _dbContext.SaveChangesAsync();
        }

        private static FootballDbContext GetMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<FootballDbContext>()
                .UseInMemoryDatabase(databaseName: "FootballInMemory")
                .Options;

            return new FootballDbContext(options);
        }
    }
}
