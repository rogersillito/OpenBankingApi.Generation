using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using OpenBankingApi.Client.Configuration;

namespace OpenBankingApi.Client
{
    public abstract class ApiClient
    {
        private readonly IConfigureAnApiClient _configurator;

        protected ApiClient(IConfigureAnApiClient configurator)
        {
            _configurator = configurator;
        }

        protected Task<HttpClient> CreateHttpClientAsync(CancellationToken cancellationToken)
        {
            return _configurator.CreateHttpClientAsync();
        }
    }
}