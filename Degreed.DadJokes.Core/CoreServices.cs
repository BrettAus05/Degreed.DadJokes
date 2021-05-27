using Degreed.DadJokes.Core.ICanHazDadJoke;
using Degreed.DadJokes.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Degreed.DadJokes.Core
{
    public static class CoreServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            var iCanHazDadJokeSettings = new ICanHazDadJokeSettings();

            configuration.GetSection("ICanHazDadJokeSettings").Bind(iCanHazDadJokeSettings);

            services.AddSingleton(iCanHazDadJokeSettings);

            services.AddSingleton<IJokesService, JokesService>();

            services.AddHttpClient<IICanHazDadJokeHttpClient, ICanHazDadJokeHttpClient>(client =>
            {
                client.BaseAddress = new Uri(iCanHazDadJokeSettings.Uri);
            });

            return services;
        }
    }
}
