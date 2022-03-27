using SG_Net_Challenge.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SG_Net_Challenge.Domain.ViewModels.Outputs
{
   public class MarketDataContributionResponse
    {
        public string Identifier { get; set; }
        public StatusEnum Status { get; set; }

    }
}
