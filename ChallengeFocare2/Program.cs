using ChallengeFocare2.Application.Services;
using ChallengeFocare2.Domain.Interfaces;
using ChallengeFocare2.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ChallengeFocare2.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();

            services.AddTransient<ISearchService, GoogleSearchService>();

            services.AddTransient<SearchAppService>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            SearchAppService appService = serviceProvider.GetRequiredService<SearchAppService>();
            appService.Run(2);

            Console.WriteLine("Pressione ENTER para encerrar...");
            Console.ReadLine();

            if (serviceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}