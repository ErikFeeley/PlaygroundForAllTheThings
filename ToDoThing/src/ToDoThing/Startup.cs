using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ToDoThing.Data;
using ToDoThing.Extensions;
using ToDoThing.Models;
using ToDoThing.Services;

namespace ToDoThing
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        private readonly ILogger<Startup> _logger;


        public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //Configuration = SetupConfigurationBuilder(configurationBuilder, env); it looks like the default provider does not have a IConfiguartionBuilder registered on app init
            Configuration = SetupConfigurationBuilder(new ConfigurationBuilder(), env);

            _logger = loggerFactory.AddCreateCustomLogger(Configuration, env);
            _logger.LogInformation("Created and added custom logger");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _logger.LogInformation("Configuring services.");
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            _logger.LogInformation("Configuring Http request pipeline.");
            _logger.LogInformation($"App running in {env.EnvironmentName} mode.");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();

                // Browser Link is not compatible with Kestrel 1.1.0
                // For details on enabling Browser Link, see https://go.microsoft.com/fwlink/?linkid=840936
                // app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static IConfigurationRoot SetupConfigurationBuilder(IConfigurationBuilder configurationBuilder, IHostingEnvironment env)
        {
            configurationBuilder.SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                configurationBuilder.AddUserSecrets<Startup>();
            }

            configurationBuilder.AddEnvironmentVariables();

            return configurationBuilder.Build();
        }
    }
}
