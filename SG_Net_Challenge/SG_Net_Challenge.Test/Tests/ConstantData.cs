using SG_Net_Challenge.Domain.Models;
using SG_Net_Challenge.Domain.ViewModels.Inputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SG_Net_Challenge.Test.Tests
{
    public class ConstantData
    {
        public MarketDataContributionRequest marketDataEmptyMarketDataType;
        public void InitMarketdataWithEmptyIdentifier()
        {
            this.marketDataEmptyMarketDataType = new MarketDataContributionRequest()
            {
                MarketDataType = string.Empty,
                MarketData = new MarketData()
                {
                    Currency = "EUR/USD",
                    Ask = 12,
                    Bid = 13,
                    Description = "description",
                    Id = 12345678
                }
            };
        }
        internal void InitData()
        {
            InitMarketdataWithEmptyIdentifier();
        }
    }
}
