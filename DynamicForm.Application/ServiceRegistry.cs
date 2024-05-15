using DynamicForm.Application.Implementations;
using DynamicForm.Application.Interfaces;
using DynamicForm.Domain.Common.Models.Settings;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForm.Application
{
    public static class ServiceRegistry
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration conf)
        {
            //Add services here

            #region Other services

            ConfigureLogs(conf);

            services.AddSingleton((provider) =>
            {
                var endpointUri = conf["CosmosDbSettings:EndpointUri"];
                var primaryKey = conf["CosmosDbSettings:PrimaryKey"];
                var dbName = conf["CosmosDbSettings:DatabaseName"];

                var cosmosClientOptions = new CosmosClientOptions
                {
                    ApplicationName = dbName
                };

                var cosmosClient = new CosmosClient(endpointUri, primaryKey, cosmosClientOptions);
                cosmosClient.ClientOptions.ConnectionMode = ConnectionMode.Direct;

                return cosmosClient;
            });

            services.AddScoped<IProgramService, ProgramService>();




            #endregion

            #region Static Files
            services.Configure<CosmosDbSettings>(options => conf.GetSection("CosmosDbSettings").Bind(options));


            #endregion

            //services.Configure<ApiBehaviorOptions>(options =>
            //{
            //    options.SuppressModelStateInvalidFilter = true;
            //});

            void ConfigureLogs(IConfiguration configuration)
            {

                //Logger

                Log.Logger = new LoggerConfiguration()
                      .Enrich.FromLogContext()
                      .WriteTo.Console()
                      .CreateLogger();
            }

             return services;
        }
    }
}
