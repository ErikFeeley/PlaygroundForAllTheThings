using System;
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
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
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
        public IServiceProvider ConfigureServices(IServiceCollection services)
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

            var apiAssembly = typeof(Startup).GetTypeInfo().Assembly;
            var handlerAssembly = typeof(GetMyValuesHandler).GetTypeInfo().Assembly;
            var messagesAssembly = typeof(GetMyValueByIdQuery).GetTypeInfo().Assembly;

            var listOfAssemblies = new List<Assembly>();
            listOfAssemblies.Add(apiAssembly);
            listOfAssemblies.Add(handlerAssembly);
            listOfAssemblies.Add(messagesAssembly);

            services.AddMediatR(listOfAssemblies); 

            return ConfigureIoC(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseNestedContainerScopeMiddleware();

            app.UseMvc();
        }

        private IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            var container = new Container();

            container.Configure(config =>
            {
                config.Scan(scan =>
                {
                    scan.ScanAllMyAssemblies();

                    scan.LookForRegistries();

                    // Mediatr specific DI implementation actually dont need to add these becuase we are just scanning all the assemblies
                    //scan.AddAllTypesOf(typeof(IRequestHandler<,>));
                    //scan.AddAllTypesOf(typeof(IAsyncRequestHandler<,>));

                    scan.GlueTogetherMediatrInterfaces(); // extension methods are the awesome!!!

                    scan.WithDefaultConventions();
                });

                MediatrSpecifConfigurations(config);

                config.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }

        private static void MediatrSpecifConfigurations(ConfigurationExpression config)
        {
            config.For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
            config.For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));
            config.For<IMediator>().Use<Mediator>();
            config.For(typeof(IAsyncRequestHandler<,>)).DecorateAllWith(typeof(ValidationHandler<,>));
            config.For(typeof(IAsyncRequestHandler<,>)).DecorateAllWith(typeof(MediatrPipeline<,>));
        }
    }
}
