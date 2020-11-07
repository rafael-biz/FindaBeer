using FindaBeer.Services.Services.Beers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FindaBeer.Staging
{
    /// <summary>
    /// Serviço que permite inicializar o serviço que popula o banco de dados de desenvolvimento.
    /// </summary>
    public sealed class StagingServiceInitializer : IHostedService
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        public StagingServiceInitializer(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<StagingService>();

                await context.AddStagingData();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
