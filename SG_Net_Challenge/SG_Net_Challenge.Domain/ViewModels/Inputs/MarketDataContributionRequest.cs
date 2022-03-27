using SG_Net_Challenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SG_Net_Challenge.Domain.ViewModels.Inputs
{
    public class MarketDataContributionRequest
    {
        public string MarketDataType { get; set; }

        public MarketData MarketData { get; set; }
    }
}
