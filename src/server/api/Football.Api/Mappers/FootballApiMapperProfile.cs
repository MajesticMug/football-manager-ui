using AutoMapper;
using Football.Api.Models;
using Football.Api.ServiceClient.Dtos;

namespace Football.Api.Mappers
{
    internal class FootballApiMapperProfile : Profile
    {
        public FootballApiMapperProfile()
        {
            CreateMap<CompetitionDto, Competition>()
                .ForMember(competition => competition.Id, expression => expression.Ignore());

            // Transform external Ids into Codes
            CreateMap<TeamDto, Team>()
                .ForMember(team => team.Id, expression => expression.Ignore())
                .ForMember(team => team.Code, expression => expression.MapFrom(dto => dto.Id.ToString()));

            CreateMap<SquadMemberDto, Player>()
                .ForMember(player => player.Id, expression => expression.Ignore())
                .ForMember(player => player.Code, expression => expression.MapFrom(dto => dto.Id.ToString()));
        }
    }
}
