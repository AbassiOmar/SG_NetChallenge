using Moq;
using SG_Net_Challenge.Domain.Models;
using SG_Net_Challenge.Domain.Validations;
using SG_Net_Challenge.Domain.ViewModels.Inputs;
using SG_NET_Challenge.Validation.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SG_Net_Challenge.Test.Tests
{
    public class ServiceTests: IClassFixture<DataFixture>
    {
        private readonly DataFixture dataFixture;
        private readonly Mock<MarketDataContributionRequestValidator> mockedMarketDataServiceValidator;
        private readonly UnitTestExecutor<MarketDataContributionRequest> unitTestExecutor;
        public ServiceTests(DataFixture dataFixture)
        {
            this.dataFixture = dataFixture;
            this.mockedMarketDataServiceValidator = new Mock<MarketDataContributionRequestValidator>() { CallBase = true };
            this.unitTestExecutor = new UnitTestExecutor<MarketDataContributionRequest>(this.mockedMarketDataServiceValidator.Object);
        }


        [Fact]
        public void Identifier_Empty_Test_KO()
        {
            this.unitTestExecutor.Execute(this.dataFixture.marketDataEmptyMarketDataType, false);
        }
    }
}
