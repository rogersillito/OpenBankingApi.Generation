using System.Net.Http;
using System.Threading.Tasks;

namespace OpenBankingApi.Client.Configuration
{
    public abstract class ClientConfiguratorBase : IConfigureAnApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        protected ClientConfiguratorBase(IHttpClientFactory httpClientFactory)
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