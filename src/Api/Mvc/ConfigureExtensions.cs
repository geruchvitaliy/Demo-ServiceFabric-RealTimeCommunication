using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace Api.Mvc
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
            services.AddMvc()
                    .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    });
        }

        public static void AddMvcConfiguration(this IApplicationBuilder app)
        {
            app.UseCors("SignalR-Access-Control-Allow-Origin");
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseMvc();
        }
    }
}