using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SG_Net_Challenge.Command.Commands;
using SG_Net_Challenge.Domain.Configurations;
using SG_Net_Challenge.Domain.InterfaceCommand;
using SG_Net_Challenge.Domain.InterfaceService;
using SG_Net_Challenge.Domain.InterfacesQueries;
using SG_Net_Challenge.Query.Queries;
using SG_Net_Challenge.Service.Services;
using SG_NET_Challenge.Validation.Validations;

namespace SG_Net_Challenge.Extensions
{
    public static class IOCExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppsettingConfiguration>(configuration.GetSection("AppsettingConfiguration"));
            services.AddTransient<IMarketDataContributionService, MarketDataContributionService>();
            services.AddTransient<IMarketDataContributionService, MarketDataContributionService>();
            services.AddTransient<IValidationMarketDataValidator, ValidationMarketDataValidator>();
            services.AddTransient<IMarketDataContributionCommand, MarketDataContributionCommand>();
            services.AddTransient<IMarketDataContributionQuery, MarketDataContributionQuery>(); 
            return services;
        }
    }
}
