using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
                    options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
