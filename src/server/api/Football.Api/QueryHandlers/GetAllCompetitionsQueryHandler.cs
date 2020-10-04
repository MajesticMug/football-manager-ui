using System.Threading;
using System.Threading.Tasks;
using Football.Api.Models;
using Football.Api.Queries;
using Football.Api.Repositories.Interfaces;
using MediatR;

namespace Football.Api.QueryHandlers
{
    public class GetAllCompetitionsQueryHandler : IRequestHandler<GetAllCompetitionsQuery, Competition[]>
    {
        private readonly ICompetitionRepository _competitionRepository;

        public GetAllCompetitionsQueryHandler(ICompetitionRepository competitionRepository)
        {
            _competitionRepository = competitionRepository;
        }

        public async Task<Competition[]> Handle(GetAllCompetitionsQuery request, CancellationToken cancellationToken)
        {
            return (await _competitionRepository.GetAllCompetitionsAsync()).ToArray();
        }
    }
}
