using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SG_Net_Challenge.Domain.InterfaceService;
using SG_Net_Challenge.Domain.ViewModels.Inputs;
using SG_Net_Challenge.Domain.ViewModels.Outputs;

namespace SG_Net_Challenge.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class MarketDatacontributionController : ControllerBase
    {
        private readonly IMarketDataContributionService marketDatacontributionService;
        public MarketDatacontributionController(IMarketDataContributionService marketDatacontributionService)
        {
            this.marketDatacontributionService = marketDatacontributionService;
        }

        [HttpPost()]
        [ProducesResponseType(typeof(MarketDataContributionResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> ProcessMarketDataContribution([FromBody] MarketDataContributionRequest requestModel)
        {
            var result = await this.marketDatacontributionService.ProcessMarketDataContribution(requestModel);
            return Ok(result);
        }

        [HttpGet()]
        [ProducesResponseType(typeof(MarketDataContributionResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetMarketDataContribution([FromQuery] string identifier)
        {
            var result = await this.marketDatacontributionService.GetMarketDataContribution(identifier);
            return Ok(result);
        }
    }
}
