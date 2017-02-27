using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ToDoThing.Extensions
{
    public static class Extensions
    {
        public static ILogger<Startup> AddCreateCustomLogger(this ILoggerFactory loggerFactory, IConfigurationRoot configuration, IHostingEnvironment env)
        {
            // basically log all the things.
            if (env.IsDevelopment())
            {
                return loggerFactory.AddConsole(configuration.GetSection("Logging")).AddDebug().CreateLogger<Startup>();
            }

            // in prod env turn down logging a bit to only grab the most important bits.
            return loggerFactory.AddConsole(configuration.GetSection("Logging")).CreateLogger<Startup>();
        }
    }
}
