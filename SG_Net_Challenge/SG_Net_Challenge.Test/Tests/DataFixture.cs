using SG_Net_Challenge.Domain.Models;
using SG_Net_Challenge.Domain.ViewModels.Inputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SG_Net_Challenge.Test.Tests
{
    public class DataFixture : IDisposable, ICloneable
    {
        public MarketDataContributionRequest marketDataEmptyMarketDataType;
        private readonly ConstantData database = new ConstantData();
      

      
        public DataFixture()
        {
            this.database.InitData();
            this.marketDataEmptyMarketDataType = this.database.marketDataEmptyMarketDataType;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void Dispose()
        {
        }
    }
}
