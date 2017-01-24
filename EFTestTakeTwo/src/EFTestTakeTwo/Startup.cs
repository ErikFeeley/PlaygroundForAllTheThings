using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StructureMap;

namespace EFTestTakeTwo
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
            // Add framework services.
            services.AddMvc()
                .AddControllersAsServices();

            return ConfigureIoC(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }

        private IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            var path = _env.ContentRootPath;
            var oneUp = Path.GetDirectoryName(path);
            var upAgain = Path.GetDirectoryName(oneUp);

            var container = new Container();

            container.Configure(config =>
            {
                config.Scan(scan =>
                {
                    //scan.AssembliesAndExecutablesFromPath(upAgain + "\\EFTestTakeTwo.Data.EF.Context\\bin\\debug");
                    //scan.AssembliesAndExecutablesFromPath(upAgain + "\\packages\\EntityFramework.6.1.3");
                    //scan.AssembliesAndExecutablesFromPath(upAgain + "\\packages\\StructureMap.4.4.2");

                    //scan.Assembly("EFTestTakeTwo");
                    //scan.Assembly("EFTestTakeTwo.Data.EF.Context");
                    //scan.Assembly("EFTestTakeTwo.Data.EF.Implementations");
                    //scan.Assembly("EFTestTakeTwo.Data.Interfaces");
                    //scan.Assembly("EFTestTakeTwo.Data.Models

                    // something odd going on... DI only working if using the line below, but it has to load some stuff from the GAC on the first api call making it slow ~4seconds
                    scan.AssembliesAndExecutablesFromPath(oneUp);


                    scan.LookForRegistries();
                    scan.WithDefaultConventions();
                });

                config.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }
    }
}
