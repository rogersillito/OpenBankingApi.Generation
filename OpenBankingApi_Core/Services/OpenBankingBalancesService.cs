﻿using System.Threading.Tasks;
using OpenBankingApi.NSwagGenerated.v3_1_1;

namespace OpenBankingApi.Services
{
    public class OpenBankingBalancesService: IOpenBankingBalancesImplementor
    {
        public Task<OBReadBalance1> BalancesGetAsync(string accountId, string x_fapi_financial_id, string authorization,
            string x_fapi_customer_last_logged_time = null, string x_fapi_customer_ip_address = null,
            string x_fapi_interaction_id = null, string x_customer_user_agent = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<OBReadBalance1> BalancesGetAsync(string x_fapi_financial_id, string authorization, string x_fapi_customer_last_logged_time = null,
            string x_fapi_customer_ip_address = null, string x_fapi_interaction_id = null, string x_customer_user_agent = null)
        {
            throw new System.NotImplementedException();
        }
    }
}