using System;
using OpenBankingApi.Controllers;
using Owin;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Hosting;
using System.Web.Http.ModelBinding;
using System.Web.Http.Tracing;
using Microsoft.Owin;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.WebApi;

namespace OpenBankingApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.Use<GlobalExceptionMiddleware>();

            var container = new UnityContainer();
            ConfigureContainer(container);

            var config = new HttpConfiguration
            {
                DependencyResolver = new UnityDependencyResolver(container)
            };

            //config.
            config.Services.Replace(typeof(IHttpControllerSelector), new MyControllerSelector(config));
            config.Services.Replace(typeof(IHttpActionSelector), new MyActionSelector());
            //config.Services.Replace(typeof(IExceptionLogger), new MyExceptionLogger());
            ConfigureRouting(config);
            app.UseWebApi(config);

        }

        private void ConfigureRouting(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "OpenBankingApi",
            //    routeTemplate: "open-banking/v3.1/aisp",
            //    defaults: new { controller = "OpenBankingApi" }
            //);
        }

        private static void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterType<IOpenBankingApiController, OpenBankingApiControllerImpl>();

////container.RegisterType<IHostBufferPolicySelector, WebHostBufferPolicySelector>(new HierarchicalLifetimeManager());
////container.RegisterType<IExceptionHandler, DefaultExceptionHandler>(new HierarchicalLifetimeManager());
////container.RegisterType<ModelMetadataProvider, EmptyModelMetadataProvider>(new HierarchicalLifetimeManager());
////container.RegisterType<ITraceManager, TraceManager>(new HierarchicalLifetimeManager());
////container.RegisterType<System.Web.Http.Tracing.ITraceWriter, SimpleTracer>(new HierarchicalLifetimeManager());
//container.RegisterType<IHttpControllerSelector, DefaultHttpControllerSelector>(new HierarchicalLifetimeManager(), new InjectionConstructor(config));
//container.RegisterType<IAssembliesResolver, DefaultAssembliesResolver>(new HierarchicalLifetimeManager());
////container.RegisterType<IHttpControllerTypeResolver, /*Default*/HttpControllerTypeResolver>(new HierarchicalLifetimeManager());
//container.RegisterType<IHttpActionSelector, ApiControllerActionSelector>(new HierarchicalLifetimeManager());
//container.RegisterType<IActionValueBinder, DefaultActionValueBinder>(new HierarchicalLifetimeManager());
//container.RegisterType<IContentNegotiator, DefaultContentNegotiator>(new HierarchicalLifetimeManager(), new InjectionConstructor(true));
//container.RegisterType<IHttpControllerActivator, DefaultHttpControllerActivator>(new HierarchicalLifetimeManager());
        }
    }

    //public class GlobalExceptionMiddleware : OwinMiddleware
    //{
    //    public GlobalExceptionMiddleware(OwinMiddleware next) : base(next)
    //    { }

    //    public override async Task Invoke(IOwinContext context)
    //    {
    //        try
    //        {
    //            await Next.Invoke(context);
    //        }
    //        catch (Exception ex)
    //        {
    //            // your handling logic
    //        }
    //    }
    //}

    public class MyExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            base.Log(context);
        }

        public override Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
            return base.LogAsync(context, cancellationToken);
        }
    }

    public class MyActionSelector : ApiControllerActionSelector
    {
        public override ILookup<string, HttpActionDescriptor> GetActionMapping(HttpControllerDescriptor controllerDescriptor)
        {
            var actionMapping = base.GetActionMapping(controllerDescriptor);
            return actionMapping;
        }

        public override HttpActionDescriptor SelectAction(HttpControllerContext controllerContext)
        {
            var a = base.SelectAction(controllerContext);
            return a;
        }

    }

    public class MyControllerSelector : DefaultHttpControllerSelector
    {
        public MyControllerSelector(HttpConfiguration configuration) : base(configuration)
        {
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var httpControllerDescriptor = base.SelectController(request);
            return httpControllerDescriptor;
        }
    }
}