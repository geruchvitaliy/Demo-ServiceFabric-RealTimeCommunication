using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SignalR.Mvc;
using System;

namespace SignalR
{
    public class Startup
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public static Publisher Publisher => ServiceProvider.GetService<Publisher>();

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcServices();
            services.AddSignalRServices();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;

            app.AddMvcConfiguration();
            app.AddSignalRConfiguration();
        }
    }
}