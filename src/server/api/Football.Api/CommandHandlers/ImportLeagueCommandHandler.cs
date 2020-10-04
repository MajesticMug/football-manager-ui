using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Football.Api.Commands;
using Football.Api.Models;
using Football.Api.ServiceClient;
using MediatR;

namespace Football.Api.CommandHandlers
{
    public class ImportLeagueCommandHandler : IRequestHandler<ImportLeagueCommand>
    {
        private readonly IFootballDataApiClient _apiClient;
        private readonly IMapper _mapper;

        public ImportLeagueCommandHandler(IFootballDataApiClient apiClient, Mapper mapper)
        {
            _apiClient = apiClient;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(ImportLeagueCommand request, CancellationToken cancellationToken)
        {
            // TODO
            var competition = _mapper.Map<Competition>(await _apiClient.GetCompetitionByLeagueCodeAsync(request.LeagueCode));

            // Unit represents a void return type in MeadiatR
            return Unit.Value;
        }
    }
}
