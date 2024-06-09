using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;

namespace TaxiApp.Infrastructure.HostedServices
{
    public sealed class VerificationTokenDeletingService(
        ILogger<VerificationTokenDeletingService> logger,
        IConfiguration configuration,
        IServiceProvider serviceProvider) : BackgroundService
    {
        private const int MinuteInMilliseconds = 60000;
        private const string ClassName = nameof(VerificationTokenDeletingService);

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int delayMinutes = int.Parse(configuration["RefreshTokenDeletingService:MinutesDelay"]!);

            while (!stoppingToken.IsCancellationRequested)
            {
                logger.LogInformation($"{ClassName} running: {DateTimeOffset.Now}");

                using (IServiceScope scope = serviceProvider.CreateScope())
                {
                    var verificationTokenRepository = scope.ServiceProvider.GetRequiredService<IVerificationTokenRepository>();

                    List<VerificationToken> tokens = (await verificationTokenRepository.FindAll(
                        x => x.TokenExpiryTime < DateTime.UtcNow)).ToList();

                    if (tokens.Any())
                        await verificationTokenRepository.DeleteItemsRangeAsync(tokens);

                    tokens.ForEach(x => logger.LogInformation($"Deleting verufucatuib token with id: {x.Id}"));
                }

                await Task.Delay(MinuteInMilliseconds * delayMinutes, stoppingToken);
            }
        }
    }
}
