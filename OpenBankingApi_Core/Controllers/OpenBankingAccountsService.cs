using System.Threading.Tasks;

namespace OpenBankingApi_core.Controllers
{
    public class OpenBankingAccountsService: IOpenBankingAccountsImplementor
    {
        public Task<OBReadAccount3> AccountsGetAsync(string x_fapi_financial_id, string authorization, string x_fapi_customer_last_logged_time = null,
            string x_fapi_customer_ip_address = null, string x_fapi_interaction_id = null, string x_customer_user_agent = null)
        {
            var task = new Task<OBReadAccount3>(() =>
            {
                return new OBReadAccount3();
            });
            task.Start();
            return task;
        }
        public Task<OBReadAccount3> AccountsGetAsync(string accountId, string x_fapi_financial_id, string authorization,
            string x_fapi_customer_last_logged_time = null, string x_fapi_customer_ip_address = null,
            string x_fapi_interaction_id = null, string x_customer_user_agent = null)
        {
            throw new System.NotImplementedException();
        }
    }   
}