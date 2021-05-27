using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Degreed.DadJokes.Web.Utilities
{
    public static class WebServices
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            var webSettings = new WebSettings();

            configuration.GetSection("DegreedDadJokesWebSettings").Bind(webSettings);

            services.AddSingleton(webSettings);

            services.AddHttpClient<IDadJokesHttpClient, DadJokesHttpClient>(client =>
            {
                client.BaseAddress = new Uri(webSettings.ApiUri);
            });

            return services;
        }
    }
}
