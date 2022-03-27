using SG_Net_Challenge.Domain.Models;
using SG_Net_Challenge.Domain.ViewModels.Inputs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SG_Net_Challenge.Domain.InterfaceService
{
    public interface IValidationMarketDataService
    {
        Task<ResponseValidationService> ValidateDataMarket(MarketDataContributionRequest request);

    }
}
