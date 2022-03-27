using SG_Net_Challenge.Domain.Enums;
using SG_Net_Challenge.Domain.InterfaceCommand;
using SG_Net_Challenge.Domain.InterfaceService;
using SG_Net_Challenge.Domain.ViewModels.Inputs;
using SG_Net_Challenge.Domain.ViewModels.Outputs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SG_Net_Challenge.Service.Services
{
    public class MarketDataContributionService : IMarketDataContributionService
    {
        private readonly IMarketDataContributionCommand marketDataContributionCommand;
        private readonly IValidationMarketDataValidator validationMarketDataService;
        public MarketDataContributionService(IMarketDataContributionCommand marketDataContributionCommand,
            IValidationMarketDataValidator validationMarketDataService)
        {
            this.marketDataContributionCommand = marketDataContributionCommand;
            this.validationMarketDataService = validationMarketDataService;
        }
        public async Task<MarketDataContributionResponse> ProcessMarketDataContribution(MarketDataContributionRequest request)
        {
            MarketDataContributionResponse responseProcess = new MarketDataContributionResponse();
            var responseValidationDataMarket = await this.validationMarketDataService.ValidateDataMarket(request);
            if (responseValidationDataMarket.Status == StatusEnum.FAILED)
            {
                responseProcess.Identifier = responseValidationDataMarket.Identier;
                responseProcess.Status = responseValidationDataMarket.Status;

                return responseProcess;
            }
            else
            {
                return await this.marketDataContributionCommand.ProcessMarketDataContribution(request);
            }
        }
    }
}
