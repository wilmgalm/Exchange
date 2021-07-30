using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DolarExchange.Business.IManager;
using DolarExchange.Business.Manager;
using DolarExchange.DataAccess.TransactionHistory;
using DolarExchange.Model.ConfigurationModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DolarExchange.Rest
{
    public class Startup
    {
        private readonly string _policyName = "CorsPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(opt =>
            {
                opt.AddPolicy(name: _policyName, builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            services.Configure<ConnectionStrings>(Configuration.GetSection(nameof(ConnectionStrings)));
            services.AddSingleton<IConnectionStrings>(sp => sp.GetRequiredService<IOptions<ConnectionStrings>>().Value);
            services = IoC(services);
            services.AddControllers()
                .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);
           // services.AddMvc();
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        private IServiceCollection IoC(IServiceCollection services)
        {
            //Crud
            services.AddSingleton<ICrudTransactions, CrudTransactions>();
            //Managers
            services.AddSingleton<ITransactionManager, TransactionManager>();
            services.AddSingleton<IExternalServicesManager, ExternalServicesManager>();
            return services;
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(_policyName);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
