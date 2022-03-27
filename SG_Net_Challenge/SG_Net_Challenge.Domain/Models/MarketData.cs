using System;
using System.Collections.Generic;
using System.Text;

namespace SG_Net_Challenge.Domain.Models
{
    public class MarketData
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public string Currency { get; set; }

        public decimal Bid { get; set; }
        public decimal Ask { get; set; }
    }
}
