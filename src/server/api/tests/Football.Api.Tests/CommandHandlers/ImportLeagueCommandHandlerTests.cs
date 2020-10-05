using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Football.Api.CommandHandlers;
using Football.Api.Commands;
using Football.Api.Mappers;
using Football.Api.Models;
using Football.Api.Repositories.Interfaces;
using Football.Api.ServiceClient;
using Football.Api.ServiceClient.Dtos;
using Moq;
using Xunit;

namespace Football.Api.Tests.CommandHandlers
{
    public class ImportLeagueCommandHandlerTests
    {
        private readonly Mock<IFootballDataApiClient> _apiClientMock = new Mock<IFootballDataApiClient>();
        private readonly Mock<ICompetitionRepository> _competitionRepositoryMock = new Mock<ICompetitionRepository>();
        private readonly IMapper _mapper;

        public ImportLeagueCommandHandlerTests()
        {
            _mapper = GetAutoMapper();
        }

        [Fact]
        public async Task ImportCommandShouldShouldUseDependenciesWithCorrectParameters()
        {
            var competitionCode = "test";
            var competitionId = 1;

            _apiClientMock.Setup(client => client.GetCompetitionByLeagueCodeAsync(competitionCode))
                .Returns(() => Task.FromResult(new CompetitionDto
                {
                    Code = competitionCode,
                    Id = competitionId,
                    Name = "Test Competition",
                    NumberOfAvailableSeasons = 4
                }));

            _apiClientMock.Setup(client => client.GetTeamsByCompetition(competitionId)).Returns(() =>
                Task.FromResult(new[]
                {
                    new TeamDto
                    {
                        Id = 1,
                        Name = "Test Team",
                        ShortName = "TTeam",
                        Tla = "TT",
                        Email = "asd@asd.com",
                        Address = "Fake Street 123",
                    },
                }));

            _apiClientMock.Setup(client => client.GetPlayersByTeamAsync(1)).Returns(() => Task.FromResult(new[]
            {
                new SquadMemberDto
                {
                    Id = 1,
                    Name = "Test Player",
                    CountryOfBirth = "Test Country",
                    Nationality = "Test Country",
                    Position = "Forward",
                    Role = "PLAYER"
                },
            }));

            var footballClient = _apiClientMock.Object;

            _competitionRepositoryMock
                .Setup(repository => repository.SaveCompetitionAsync(It.IsAny<Competition>(), It.IsAny<List<Team>>()))
                .Returns(() => Task.CompletedTask);

            var commandHandler = new ImportLeagueCommandHandler(footballClient, _mapper, _competitionRepositoryMock.Object);

            await commandHandler.Handle(new ImportLeagueCommand {LeagueCode = competitionCode},
                new CancellationToken());


            _apiClientMock.Verify(client => client.GetCompetitionByLeagueCodeAsync(competitionCode), Times.Once);
            _apiClientMock.Verify(client => client.GetTeamsByCompetition(competitionId), Times.Once);
            _apiClientMock.Verify(client => client.GetPlayersByTeamAsync(1), Times.Once);

            _competitionRepositoryMock.Verify(repository => repository.SaveCompetitionAsync(It.IsAny<Competition>(), It.IsAny<List<Team>>()), Times.Once);
        }

        private static IMapper GetAutoMapper()
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new FootballApiMapperProfile()); });

            return mappingConfig.CreateMapper();
        }
    }
}
