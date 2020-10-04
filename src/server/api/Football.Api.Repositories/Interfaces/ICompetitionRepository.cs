using System.Threading.Tasks;
using Football.Api.Models;

namespace Football.Api.Repositories.Interfaces
{
    public interface ICompetitionRepository
    {
        Task<Competition> GetCompetitionByIdAsync(int leagueId);
        Task SaveCompetitionAsync(Competition competition);
    }
}
