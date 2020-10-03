using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Football.Api.ServiceClient.Exceptions;
using Newtonsoft.Json;

namespace Football.Api.ServiceClient
{
    public class ServiceClient : IServiceClient
    {
        private readonly HttpClient _httpClient;

        public ServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TRoot> GetRootAsync<TRoot>(string uri)
        {
            var response = await _httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TRoot>(json);
            }

            if (response.StatusCode == (HttpStatusCode) 429)
            {
                // requests-per-minute limit exceeded
                throw new RequestNumberLimitExceededException("Too many request were made");
            }

            throw new ServiceClientUnknownErrorException($"Could not get root object for uri: {uri}. HttpStatus code: {response.StatusCode}");
        }
    }
}
