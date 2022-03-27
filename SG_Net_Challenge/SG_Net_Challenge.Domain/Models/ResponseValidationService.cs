using SG_Net_Challenge.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SG_Net_Challenge.Domain.Models
{
    public class ResponseValidationService
    {
        public string Identier { get; set; }
        public StatusEnum Status { get; set; }
    }
}
