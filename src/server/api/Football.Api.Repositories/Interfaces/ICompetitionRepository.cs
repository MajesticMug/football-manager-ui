using System.Collections.Generic;
using System.Threading.Tasks;
using Football.Api.Models;

namespace Football.Api.Repositories.Interfaces
{
    public interface ICompetitionRepository
    {
        Task<Competition> GetCompetitionByCodeAsync(string code);
        Task SaveCompetitionAsync(Competition competition, List<Team> teams);
        Task<List<Competition>> GetAllCompetitionsAsync();
    }
}

