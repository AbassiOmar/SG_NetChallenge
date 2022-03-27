using SG_Net_Challenge.Domain.Enums;
using SG_Net_Challenge.Domain.InterfaceService;
using SG_Net_Challenge.Domain.Models;
using SG_Net_Challenge.Domain.ViewModels.Inputs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SG_NET_Challenge.Validation.Validations
{
    public class ValidationMarketDataService : IValidationMarketDataService
    {
        public async Task<ResponseValidationService> ValidateDataMarket(MarketDataContributionRequest request)
        {
            var rnd = new Random();
            var a = (StatusEnum)rnd.Next(Enum.GetNames(typeof(StatusEnum)).Length);
            ResponseValidationService response = new ResponseValidationService();
            response.Identier= Guid.NewGuid().ToString();
            response.Status = a;
            return response;
        }


    }
}
