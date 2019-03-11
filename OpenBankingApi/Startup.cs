using Owin;
using System.Web.Http;

namespace OpenBankingApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //var container = new UnityContainer();
            //ConfigureContainer(container);

            var config = new HttpConfiguration
            {
                //DependencyResolver = new UnityDependencyResolver(container)
            };

            //config.Services.Replace(typeof(IHttpControllerSelector), new MyControllerSelector(config));
            //config.Services.Replace(typeof(IHttpActionSelector), new MyActionSelector());
            //config.Services.Replace(typeof(IExceptionLogger), new MyExceptionLogger());
            ConfigureRouting(config);
            app.UseWebApi(config);
        }

        private void ConfigureRouting(HttpConfiguration config)
        {
            // OpenBanking API routes generated with attribute mapping
            config.MapHttpAttributeRoutes();
        }

//        private static void ConfigureContainer(IUnityContainer container)
//        {
//            container.RegisterType<IOpenBankingApiController, OpenBankingApiControllerImpl>();
//        }
//    }

        //public class MyActionSelector : ApiControllerActionSelector
        //{
        //    public override ILookup<string, HttpActionDescriptor> GetActionMapping(
        //        HttpControllerDescriptor controllerDescriptor)
        //    {
        //        var actionMapping = base.GetActionMapping(controllerDescriptor);
        //        return actionMapping;
        //    }

        //    public override HttpActionDescriptor SelectAction(HttpControllerContext controllerContext)
        //    {
        //        var a = base.SelectAction(controllerContext);
        //        return a;
        //    }

        //}

        //public class MyControllerSelector : DefaultHttpControllerSelector
        //{
        //    public MyControllerSelector(HttpConfiguration configuration) : base(configuration)
        //    {
        //    }

        //    public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        //    {
        //        var httpControllerDescriptor = base.SelectController(request);
        //        return httpControllerDescriptor;
        //    }
        //}
    }
}