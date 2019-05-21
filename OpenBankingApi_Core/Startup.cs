using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using OpenBankingApi.NSwagGenerated.v3_1_1;
using OpenBankingApi.Services;

#region snippet_ApiControllerAttributeOnAssembly
[assembly: ApiController]
namespace OpenBankingApi_core
{
    public class Startup
    {
        #endregion snippet_ApiControllerAttributeOnAssembly
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IOpenBankingAccountsImplementor, OpenBankingAccountsService>();
            services.AddScoped<IOpenBankingBalancesImplementor, OpenBankingBalancesService>();
            services.AddScoped<IOpenBankingProductsImplementor, OpenBankingProductsService>();
            services.AddScoped<IOpenBankingTransactionsImplementor, OpenBankingTransactionsService>();

            #region snippet_ConfigureApiBehaviorOptions
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressConsumesConstraintForFormFileParameters = true;
                    options.SuppressInferBindingSourcesForParameters = true;
                    options.SuppressModelStateInvalidFilter = true;
                    options.SuppressMapClientErrors = true;
                    options.ClientErrorMapping[404].Link =
                        "https://httpstatuses.com/404";
                })
                .AddJsonOptions(
                    options =>
                    {
                        options.SerializerSettings.Error = (sender, args) =>
                        {
                            Debug.WriteLine(args.ErrorContext.Error.Message);
                            Debug.WriteLine(args.ErrorContext.Error.StackTrace);
                            //throw new Exception(args.ToString());
                        };
                        options.SerializerSettings.ReferenceLoopHandling =
                            Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    });
            #endregion
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMiddleware<DeChunkingMiddleware>();
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new JsonExceptionMiddleware().Invoke
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }

    public class DeChunkingMiddleware
    {
        private readonly RequestDelegate _next;

        public DeChunkingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;
            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;
                long length = 0;
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers.ContentLength = length;
                    return Task.CompletedTask;
                });
                await _next(context);
                //if you want to read the body, uncomment these lines.
                //context.Response.Body.Seek(0, SeekOrigin.Begin);
                //var body = await new StreamReader(context.Response.Body).ReadToEndAsync();
                length = context.Response.Body.Length;
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }
    }

    public class JsonExceptionMiddleware
    {
        public async Task Invoke(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (ex == null) return;

            var error = new
            {
                message = ex.Message
            };

            context.Response.ContentType = "application/json";

            using (var writer = new StreamWriter(context.Response.Body))
            {
                new JsonSerializer().Serialize(writer, error);
                await writer.FlushAsync().ConfigureAwait(false);
            }
        }
    }
}
