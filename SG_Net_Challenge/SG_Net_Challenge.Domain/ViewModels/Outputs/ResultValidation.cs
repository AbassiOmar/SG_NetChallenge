using System;
using System.Collections.Generic;
using System.Text;

namespace SG_Net_Challenge.Domain.ViewModels.Outputs
{
    public class ResultValidation
    {
        public ResultValidation()
        {
            this.Messages = new List<ResponseErrorDto>(0);
        }
        public List<ResponseErrorDto> Messages { get; set; }
        public bool IsValid { get; set; }

    }
}
