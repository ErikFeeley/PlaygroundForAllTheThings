using System.Collections.Generic;
using System.Reflection;
using FluentValidation.AspNetCore;
using MediatrEF6PoC3.API.Extensions;
using MediatrEF6PoC3.API.Filters;
using MediatrEF6PoC3.API.MyMiddleWare;
using MediatrEF6PoC3.EF6Handlers;
using MediatrEF6PoC3.MediatrPipeline;
using MediatrEF6PoC3.Messages.Query;
using MediatrEF6PoC3.Models;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StructureMap;

namespace MediatrEF6PoC3.API
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //https://github.com/aspnet/Announcements/issues/190
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Add framework services.
            services.AddMvc(options =>
                {
                    options.Filters.Add(new ModelStateValidationFilter());
                })
                .AddControllersAsServices()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<MyValue>());


            var listOfAssemblies = new List<Assembly> { typeof(Startup).GetTypeInfo().Assembly, typeof(GetMyValuesHandler).GetTypeInfo().Assembly, typeof(GetMyValueByIdQuery).GetTypeInfo().Assembly, typeof(Pipelines).GetTypeInfo().Assembly };

            services.AddMediatR(listOfAssemblies); 
        }

        /// <summary>
        /// This method gets called by the runtime. Use it to add services with structuremap specific apis.
        /// </summary>
        /// <param name="registry"></param>
        public void ConfigureContainer(Registry registry)
        {
            registry.Scan(scan =>
            {
                scan.ScanAllMyAssemblies();
                scan.LookForRegistries();
                scan.WithDefaultConventions();
            });

            registry.For(typeof(IPipelineBehavior<,>)).Add(typeof(RequestPreProcessorBehavior<,>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseNestedContainerScopeMiddleware();

            app.UseMvc();
        }
    }
}
