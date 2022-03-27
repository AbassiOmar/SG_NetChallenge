using SG_Net_Challenge.Domain.ViewModels.Inputs;
using SG_Net_Challenge.Domain.ViewModels.Outputs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SG_Net_Challenge.Domain.InterfaceCommand
{
    public interface IMarketDataContributionCommand
    {
        Task<MarketDataContributionResponse> ProcessMarketDataContribution(MarketDataContributionRequest request);
    }
}
