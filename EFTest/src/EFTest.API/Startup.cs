using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StructureMap;

namespace EFTest.API
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
            var container = new Container();

            container.Configure(config =>
            {
                config.Scan(scan =>
                {
                    scan.AssembliesAndExecutablesFromApplicationBaseDirectory(); // just scan everything damnit
                    scan.Assembly("EFTest.Data.EF6Implementation");
                    scan.Assembly("EFTest.Data.EF6Context");
                    scan.TheCallingAssembly();
                    scan.LookForRegistries(); // might not need to do this bit.
                    scan.WithDefaultConventions();
                    // the scanning is only finding the assemblies that are referenced by this project... do i need a new project outside of everything for IoC?.
                    // would that even work??... 
                });

                config.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }
    }
}
