using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ToDoThing.Extensions
{
    public static class Extensions
    {
        public static ILogger<Startup> AddCreateCustomLogger(this ILoggerFactory loggerFactory, IConfigurationRoot configuration)
        {
            return loggerFactory.AddConsole(configuration.GetSection("Logging")).AddDebug().CreateLogger<Startup>();
        }
    }
}
