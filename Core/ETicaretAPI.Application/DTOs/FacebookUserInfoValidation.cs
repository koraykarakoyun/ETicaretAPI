using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs
{
    public class FacebookUserInfoValidation
    {
        [JsonPropertyName("data")]
        public FacebookUserInfoValidationResult Data { get; set; }
    }




}
