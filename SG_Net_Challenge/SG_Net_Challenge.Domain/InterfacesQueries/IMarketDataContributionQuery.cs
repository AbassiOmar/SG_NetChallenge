using SG_Net_Challenge.Domain.ViewModels.Outputs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SG_Net_Challenge.Domain.InterfacesQueries
{
    public interface IMarketDataContributionQuery
    {
        Task<MarketDataContributionResponse> GetMarketDataContribution(string identifier);
    }
}
