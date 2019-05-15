using System.Threading.Tasks;

namespace OpenBankingApi_core.Controllers
{
    public class OpenBankingProductsService: IOpenBankingProductsImplementor
    {
        public Task<OBReadProduct2> ProductAsync(string accountId, string x_fapi_financial_id, string authorization,
            string x_fapi_customer_last_logged_time = null, string x_fapi_customer_ip_address = null,
            string x_fapi_interaction_id = null, string x_customer_user_agent = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<OBReadProduct2> ProductsAsync(string x_fapi_financial_id, string authorization, string x_fapi_customer_last_logged_time = null,
            string x_fapi_customer_ip_address = null, string x_fapi_interaction_id = null, string x_customer_user_agent = null)
        {
            throw new System.NotImplementedException();
        }
    }
}