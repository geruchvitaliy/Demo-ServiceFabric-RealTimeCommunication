using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Api.Logger
{
    internal static class ConfigureExtensions
    {
        public static void AddLoggerConfiguration(this ILoggerFactory loggerFactory, IConfigurationRoot configuration)
        {
            loggerFactory.AddConsole(configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
        }
    }
}