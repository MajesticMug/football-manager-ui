using System.Threading.Tasks;

namespace Football.Api.ServiceClient
{
    public interface IServiceClient
    {
        Task<TRoot> GetRootAsync<TRoot>(string uri);
    }
}
