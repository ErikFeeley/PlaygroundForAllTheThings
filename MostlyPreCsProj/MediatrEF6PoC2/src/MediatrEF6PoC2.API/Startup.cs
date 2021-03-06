﻿using System;
using System.IO;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StructureMap;

namespace MediatrEF6PoC2.API
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

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
            // Calling AddControllersAsServices() here to make sure that structuremap is going to be handling the DI for the controllers.
            services.AddMvc()
                .AddControllersAsServices();

            // This helper method does not seem to work if we are going to use something other than the default DI
            //services.AddMediatR(typeof(Startup));

            return ConfigureIoC(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }

        public IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            var container = new Container();

            container.Configure(config =>
             {
                 config.Scan(scan =>
                 {
                     //scan.AssembliesAndExecutablesFromPath(Path.GetDirectoryName(_env.ContentRootPath));
                     //scan.AssembliesAndExecutablesFromApplicationBaseDirectory();

                     // NEED TO SPECIFY THE ASSEMBLIES TO SCAN SPECIFICALLY AFTER MOVING THE EF6 PROJECT INTO THE SRC DIRECTORY.
                     // IF YOU ARE NOT SPECIFIC THE APP WILL BLOW UP WHEN YOU PUBLISH IT BECAUSE STRUCTUREMAP GOES CRAY CRAY.
                     scan.Assembly("MediatrEF6PoC2.API");
                     scan.Assembly("MediatrEF6PoC2.EF6");
                     scan.Assembly("MediatrEF6PoC2.EF6Handlers");
                     scan.Assembly("MediatrEF6PoC2.Messages");
                     scan.Assembly("MediatrEF6PoC2.Models");
                     scan.LookForRegistries();

                     // mediatr DI setup
                     scan.AddAllTypesOf(typeof(IRequestHandler<,>));
                     scan.AddAllTypesOf(typeof(IAsyncRequestHandler<,>));
                     scan.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                     scan.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<,>));
                     scan.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
                     scan.ConnectImplementationsToTypesClosing(typeof(IAsyncNotificationHandler<>));


                     scan.WithDefaultConventions();
                 });

                 // mediatr DI setup.
                 config.For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
                 config.For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));
                 config.For<IMediator>().Use<Mediator>();

                 // helper method from strucutremap dependency injection nuget package. this method will take the service collection from core and hand over DI
                 // responsiblity to structuremap.
                 config.Populate(services);
             });

            return container.GetInstance<IServiceProvider>();
        }
    }
}
