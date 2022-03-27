using Microsoft.Extensions.Logging;
using SG_Net_Challenge.Domain.Enums;
using SG_Net_Challenge.Domain.InterfaceCommand;
using SG_Net_Challenge.Domain.InterfaceService;
using SG_Net_Challenge.Domain.InterfacesQueries;
using SG_Net_Challenge.Domain.Validations;
using SG_Net_Challenge.Domain.ViewModels.Inputs;
using SG_Net_Challenge.Domain.ViewModels.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_Net_Challenge.Service.Services
{
    public class MarketDataContributionService : IMarketDataContributionService
    {
        private readonly IMarketDataContributionCommand marketDataContributionCommand;
        private readonly IValidationMarketDataValidator validationMarketDataService;
        private readonly IMarketDataContributionQuery marketDataContributionQuery;
        private readonly ILogger<MarketDataContributionService> logger;
        public MarketDataContributionService(IMarketDataContributionCommand marketDataContributionCommand,
            IValidationMarketDataValidator validationMarketDataService,
            IMarketDataContributionQuery marketDataContributionQuery,
             ILogger<MarketDataContributionService> logger)
        {
            this.marketDataContributionCommand = marketDataContributionCommand;
            this.validationMarketDataService = validationMarketDataService;
            this.marketDataContributionQuery = marketDataContributionQuery;
            this.logger = logger;
        }

        public async Task<MarketDataContributionResponse> GetMarketDataContribution(string identifier)
        {
            return await this.marketDataContributionQuery.GetMarketDataContribution(identifier);
        }

        public async Task<MarketDataContributionResponse> ProcessMarketDataContribution(MarketDataContributionRequest request)
        {
            MarketDataContributionResponse responseProcess = new MarketDataContributionResponse();
            MarketDataContributionRequestValidator validator = new MarketDataContributionRequestValidator();
            var resultValidation = validator.Validate(request);
            if (!resultValidation.IsValid)
            {
                this.logger.LogWarning(" Process Market Data contribution reques not valid");

                responseProcess.ResultValidation.Messages.AddRange(
                    resultValidation.Errors.Select(er => ResponseErrorDto.CreateMessageError(er.ErrorCode, er.ErrorMessage)).ToList());
                return responseProcess;

            }
            else
            {
                responseProcess.ResultValidation.IsValid = true;
                this.logger.LogInformation("Begin Process Market Data contribution");
                var responseValidationDataMarket = await this.validationMarketDataService.ValidateDataMarket(request);
                if (responseValidationDataMarket.Status == StatusEnum.FAILED)
                {
                    responseProcess.Identifier = responseValidationDataMarket.Identier;
                    responseProcess.Status = responseValidationDataMarket.Status;
                    this.logger.LogInformation("Process Market Data contribution Failed");
                    return responseProcess;
                }
                else
                {
                    this.logger.LogInformation("Process Market Data contribution Succes");
                    return await this.marketDataContributionCommand.ProcessMarketDataContribution(request);
                }
            }
        }
    }
}
