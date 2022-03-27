using Microsoft.Extensions.Logging;
using SG_Net_Challenge.Domain.Enums;
using SG_Net_Challenge.Domain.InterfaceCommand;
using SG_Net_Challenge.Domain.ViewModels.Inputs;
using SG_Net_Challenge.Domain.ViewModels.Outputs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SG_Net_Challenge.Command.Commands
{
    public class MarketDataContributionCommand : IMarketDataContributionCommand
    {
        private readonly ILogger<MarketDataContributionCommand> logger;
        public MarketDataContributionCommand(ILogger<MarketDataContributionCommand> logger)
        {
            this.logger = logger;

        }
        public async Task<MarketDataContributionResponse> ProcessMarketDataContribution(MarketDataContributionRequest request)
        {
            try
            {
                this.logger.LogInformation("Begin command");
                return new MarketDataContributionResponse() {
                Identifier = Guid.NewGuid().ToString(),
                Status = StatusEnum.SUCESS
            };
        }catch(Exception ex)
            {
                this.logger.LogError("failed query MDC", ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
