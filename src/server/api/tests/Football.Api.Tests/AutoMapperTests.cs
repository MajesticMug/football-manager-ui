using AutoMapper;
using Football.Api.Mappers;
using Xunit;

namespace Football.Api.Tests
{
    public class AutoMapperTests
    {
        [Fact]
        public void AutoMapperConfigTest()
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new FootballApiMapperProfile()); });

            mappingConfig.AssertConfigurationIsValid();
        }
    }
}
