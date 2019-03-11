namespace OpenBankingApi.Controllers
{
    public partial class OpenBankingApiController : System.Web.Http.ApiController
    {
        public OpenBankingApiController() : this(new OpenBankingApiControllerImpl())
        {
        }

        // http://localhost:12345/open-banking/v3.1/aisp/accounts/123456789/transactions?x_fapi_financial_id=OB%2F2017%2F001&Authorization=Bearer%20Az90SAOJklae
    }
}