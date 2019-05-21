using System.Net.Http;
using System.Threading.Tasks;

namespace OpenBankingApi.Client.Configuration
{
    public abstract class ClientConfigurator : IConfigureAnApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        protected ClientConfigurator(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        protected abstract string HttpClientName { get; }

        public Task<HttpClient> CreateHttpClientAsync()
        {
            var client = _httpClientFactory.CreateClient(this.HttpClientName);
            var task = new Task<HttpClient>(() => client);
            task.Start();
            return task;
        }
    }
}