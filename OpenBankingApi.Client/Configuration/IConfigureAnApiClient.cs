using System.Net.Http;
using System.Threading.Tasks;

namespace OpenBankingApi.Client.Configuration
{
    public interface IConfigureAnApiClient
    {
        Task<HttpClient> CreateHttpClientAsync();
    }
}