using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OpenBankingApi.NSwagGenerated.v3_1_1;

namespace OpenBankingApi.Services
{
    public class OpenBankingAccountsService : IOpenBankingAccountsImplementor
    {
        public async Task<OBReadAccount3> AccountsGetAsync(string x_fapi_financial_id, string authorization, string x_fapi_customer_last_logged_time = null,
            string x_fapi_customer_ip_address = null, string x_fapi_interaction_id = null, string x_customer_user_agent = null)
        {
            var accounts = new OBReadAccount3
            {
                Data = new Data
                {
                    Account = new List<OBAccount3>
                    {
                        new OBAccount3
                        {
                            AccountId = "1234",
                            Currency = "GBP",
                            Nickname = "Some Account"
                        }
                    }
                },
                Links = new Links
                {
                    Self = new Uri("http://wrong.com"),
                    Prev = null,
                    Next = null,
                    First = null,
                    Last = null
                },
                Meta = new Meta
                {
                    TotalPages = 1
                }
            };
            return await Task.FromResult(accounts);
        }
        public Task<OBReadAccount3> AccountsGetAsync(string accountId, string x_fapi_financial_id, string authorization,
            string x_fapi_customer_last_logged_time = null, string x_fapi_customer_ip_address = null,
            string x_fapi_interaction_id = null, string x_customer_user_agent = null)
        {
            throw new System.NotImplementedException();
        }
    }
}