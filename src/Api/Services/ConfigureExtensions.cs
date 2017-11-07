using Common.IRepositories;
using Common.IServices;
using Common.ServiceFabric.Actors;
using Common.ServiceFabric.Repositories;
using Common.ServiceFabric.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Services
{
    internal static class ConfigureExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup), typeof(Common.Assembly), typeof(Common.ServiceFabric.Assembly));
            services.AddTransient<IActorProvider, ActorProvider>();

            services.AddRepositories();

            services.AddServices();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            GetServicesWithImplementations<IBaseRepository, BaseRepository>()
                .ToList()
                .ForEach(x => services.AddTransient(x.Item1, x.Item2));
        }

        private static void AddServices(this IServiceCollection services)
        {
            GetServicesWithImplementations<IBaseService, BaseService>()
                .ToList()
                .ForEach(x => services.AddTransient(x.Item1, x.Item2));
        }

        private static IEnumerable<Tuple<Type, Type>> GetServicesWithImplementations<TService, TImplementation>()
        {
            return typeof(Common.ServiceFabric.Assembly)
                .Assembly
                .GetExportedTypes()
                .Where(x => !x.IsAbstract && x.IsSubclassOf(typeof(TImplementation)))
                .Where(x => x.GetInterfaces().Any())
                .Select(x =>
                {
                    var service = x.GetInterfaces().Single(i => i.GetInterfaces()?.Any(ci => ci.IsAssignableFrom(typeof(TService))) == true);
                    var implementation = x;

                    return new Tuple<Type, Type>(service, implementation);
                });
        }
    }
}