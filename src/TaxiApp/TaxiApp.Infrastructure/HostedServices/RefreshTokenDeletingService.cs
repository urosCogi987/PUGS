using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;

namespace TaxiApp.Infrastructure.HostedServices
{
    public sealed class RefreshTokenDeletingService(
        ILogger<RefreshTokenDeletingService> logger,
        IConfiguration configuration,
        IServiceProvider serviceProvider) : BackgroundService
    {
        private const int MinuteInMilliseconds = 60000;
        private const string ClassName = nameof(RefreshTokenDeletingService);

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int delayMinutes = int.Parse(configuration["RefreshTokenDeletingService:MinutesDelay"]!);

            while (!stoppingToken.IsCancellationRequested)
            {
                logger.LogInformation($"{ClassName} running: {DateTimeOffset.Now}");

                using (IServiceScope scope = serviceProvider.CreateScope())
                {
                    var refreshTokenRepository = scope.ServiceProvider.GetRequiredService<IRefreshTokenRepository>();

                    List<RefreshToken> tokens = (await refreshTokenRepository.FindAll(
                        x => x.TokenExpiryTime > DateTime.UtcNow || x.IsUsed == true)).ToList();

                    if (tokens.Any())
                        await refreshTokenRepository.DeleteItemsRangeAsync(tokens);

                    tokens.ForEach(x => logger.LogInformation($"Deleting refresh token with id: {x.Id}"));
                }

                await Task.Delay(MinuteInMilliseconds * delayMinutes, stoppingToken);
            }

            throw new NotImplementedException();
        }
    }
}