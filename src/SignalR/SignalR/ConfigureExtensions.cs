using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace SignalR
{
    internal static class ConfigureExtensions
    {
        public static void AddSignalRServices(this IServiceCollection services)
        {
            services.AddSingleton<Publisher>();
            services.AddTransient(x => CreateSignalRJsonSerializer());
            services.AddSignalR(options =>
            {
                options.Hubs.EnableDetailedErrors = true;
                options.Hubs.EnableJavaScriptProxies = true;
            });
        }

        public static void AddSignalRConfiguration(this IApplicationBuilder app)
        {
            app.UseSignalR("/signalr");
        }

        private static JsonSerializer CreateSignalRJsonSerializer()
        {
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new SignalRContractResolver();

            return JsonSerializer.Create(settings);
        }
    }
}