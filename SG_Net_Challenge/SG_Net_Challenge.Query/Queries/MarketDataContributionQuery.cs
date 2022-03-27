using SG_Net_Challenge.Domain.Enums;
using SG_Net_Challenge.Domain.InterfacesQueries;
using SG_Net_Challenge.Domain.ViewModels.Outputs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SG_Net_Challenge.Query.Queries
{
    public class MarketDataContributionQuery : IMarketDataContributionQuery
    {
        public async Task<MarketDataContributionResponse> GetMarketDataContribution(string identifier)
        {
            return new MarketDataContributionResponse()
            {
                Identifier = Guid.NewGuid().ToString(),
                Status = StatusEnum.SUCESS
            };
        }
    }
}
