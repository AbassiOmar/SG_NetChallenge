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
        public async Task<MarketDataContributionResponse> ProcessMarketDataContribution(MarketDataContributionRequest request)
        {
            return new MarketDataContributionResponse() {
                Identifier = Guid.NewGuid().ToString(),
                Status = StatusEnum.SUCESS
        };
        }
    }
}
