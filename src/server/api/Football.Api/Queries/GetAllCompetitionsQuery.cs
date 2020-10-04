using Football.Api.Models;
using MediatR;

namespace Football.Api.Queries
{
    public class GetAllCompetitionsQuery : IRequest<Competition[]>
    {
        
    }
}
