using System.Collections.Generic;
using System.Threading.Tasks;
using Football.Api.Models;

namespace Football.Api.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        Task SaveTeamAsync(string teamCode, List<Player> players);
    }
}
