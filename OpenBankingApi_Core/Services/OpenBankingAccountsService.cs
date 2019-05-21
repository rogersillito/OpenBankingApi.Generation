using System.Collections.Generic;
using System.Threading.Tasks;
using OpenBankingApi.NSwagGenerated.v3_1_1;

namespace OpenBankingApi.Services
{
    public class OpenBankingAccountsService : IOpenBankingAccountsImplementor
    {
        public Task<OBReadAccount3> AccountsGetAsync(string x_fapi_financial_id, string authorization, string x_fapi_customer_last_logged_time = null,
            string x_fapi_customer_ip_address = null, string x_fapi_interaction_id = null, string x_customer_user_agent = null)
        {
            return Task.FromResult(new OBReadAccount3
            {
                Data = new Data
                {
                    Account = new List<OBAccount3>
                        {
                            new OBAccount3
                            {
                                AccountId = "1234",
                                Nickname = "Some Account"
                            }
                        }
                },
                Links = new Links(),
                Meta = new Meta()
            });
        }
        public Task<OBReadAccount3> AccountsGetAsync(string accountId, string x_fapi_financial_id, string authorization,
            string x_fapi_customer_last_logged_time = null, string x_fapi_customer_ip_address = null,
            string x_fapi_interaction_id = null, string x_customer_user_agent = null)
        {
            throw new System.NotImplementedException();
        }
    }
}