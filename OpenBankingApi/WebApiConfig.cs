using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using OpenBankingApi.Controllers;

namespace OpenBankingApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Services.Replace(typeof(IHttpControllerSelector), new MySelector(config));
            //config.DependencyResolver .Add(typeof(IController), new OpenBankingApiControllerImpl());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "OpenBankingApi",
                routeTemplate: "open-banking/v3.1/aisp",
                defaults: new { controller = "OpenBankingApi" }
            );
        }
    }

    public class MySelector : DefaultHttpControllerSelector
    {
        public MySelector(HttpConfiguration configuration) : base(configuration)
        {
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            return base.SelectController(request);
        }
    }
}
