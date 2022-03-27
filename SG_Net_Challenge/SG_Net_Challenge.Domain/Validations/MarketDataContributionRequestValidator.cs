using FluentValidation;
using SG_Net_Challenge.Domain.ViewModels.Inputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SG_Net_Challenge.Domain.Validations
{
    class MarketDataContributionRequestValidator :AbstractValidator<MarketDataContributionRequest>
    {
        public MarketDataContributionRequestValidator()
        {

        }
    }
}
