using System.Threading.Tasks;

namespace Football.Api.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        Task<int> GetTotalPlayersByCompetitionCodeAsync(string competitionCode);
    }
}
