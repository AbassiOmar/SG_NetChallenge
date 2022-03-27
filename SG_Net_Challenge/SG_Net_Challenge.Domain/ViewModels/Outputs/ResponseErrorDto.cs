using System;
using System.Collections.Generic;
using System.Text;

namespace SG_Net_Challenge.Domain.ViewModels.Outputs
{
    public class ResponseErrorDto
    {
        public string code { get; set; }
        public string message { get; set; }
        public ResponseErrorDto(string code, string message)
        {
            this.code = code;
            this.message = message;
        }

        public static ResponseErrorDto CreateMessageError(string code, string message)
        {
            return new ResponseErrorDto(code, message);
        }

    }
}
