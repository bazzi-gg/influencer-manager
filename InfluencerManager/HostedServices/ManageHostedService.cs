using Bazzigg.Database.Context;
using Kartrider.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InfluencerManager.HostedServices
{
    internal class ManageHostedService : BackgroundService
    {
        private readonly ILogger<ManageHostedService> _logger;
        private readonly IKartriderApi _kartriderApi;
        private readonly IDbContextFactory<AppDbContext> _appDbContextFactory;

        public ManageHostedService(ILogger<ManageHostedService> logger,
            IKartriderApi kartriderApi
            , IDbContextFactory<AppDbContext> appDbContextFactory)
        {
            _logger = logger;
            _kartriderApi = kartriderApi;
            _appDbContextFactory = appDbContextFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // ... Use the service here ...
            while (!stoppingToken.IsCancellationRequested)
            {
                await using var appDbContext = _appDbContextFactory.CreateDbContext();
                foreach (var influencer in appDbContext.Influencer.ToList())
                {
                    var res = await _kartriderApi.User.GetUserByAccessIdAsync(influencer.AccessId);
                    if (res.Nickname == influencer.Nickname) continue;
                    _logger.LogInformation($"{influencer.Nickname} to {res.Nickname}");
                    influencer.Nickname = res.Nickname;
                    influencer.LastUpdated = DateTime.Now;
                    appDbContext.Influencer.Update(influencer);
                    await appDbContext.SaveChangesAsync(stoppingToken);
                }
            }
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting up");
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stopping");
            return base.StopAsync(cancellationToken);
        }
    }
}