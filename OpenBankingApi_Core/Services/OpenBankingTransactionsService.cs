using System;
using System.Threading.Tasks;
using OpenBankingApi.NSwagGenerated.v3_1_1;

namespace OpenBankingApi.Services
{
    public class OpenBankingTransactionsService: IOpenBankingTransactionsImplementor
    {
        public Task<OBReadTransaction5> TransactionsAsync(string accountId, string x_fapi_financial_id, string authorization,
            string x_fapi_customer_last_logged_time = null, string x_fapi_customer_ip_address = null,
            string x_fapi_interaction_id = null, DateTimeOffset? fromBookingDateTime = null,
            DateTimeOffset? toBookingDateTime = null, string x_customer_user_agent = null)
        {
            var task = new Task<OBReadTransaction5>(() =>
            {
                return new OBReadTransaction5();
            });
            task.Start();
            return task;
        }
    }
}