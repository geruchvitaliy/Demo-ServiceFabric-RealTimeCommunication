using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SignalR.Mvc
{
    internal static class ConfigureExtensions
    {
        public static void AddMvcServices(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("SignalR-Access-Control-Allow-Origin", builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
        }

        public static void AddMvcConfiguration(this IApplicationBuilder app)
        {
            app.UseCors("SignalR-Access-Control-Allow-Origin");
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}