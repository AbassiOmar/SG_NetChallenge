using FluentValidation;
using SG_Net_Challenge.Domain.ViewModels.Inputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SG_Net_Challenge.Domain.Validations
{
    public class MarketDataContributionRequestValidator :AbstractValidator<MarketDataContributionRequest>
    {
        public MarketDataContributionRequestValidator()
        {
            RuleFor(md => md.MarketDataType).NotEmpty().NotNull();
        }
    }
}
