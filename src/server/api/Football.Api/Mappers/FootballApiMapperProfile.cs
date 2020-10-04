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

            CreateMap<TeamDto, Team>()
                .ForMember(team => team.Id, expression => expression.Ignore());

            // Transform SquadMemberDto.Id into Player.Code to keep a unique identifier for Players
            CreateMap<SquadMemberDto, Player>()
                .ForMember(player => player.Id, expression => expression.Ignore())
                .ForMember(player => player.Code, expression => expression.MapFrom(dto => dto.Id.ToString()));
        }
    }
}
