﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs
{
    public class FacebookUserInfoValidationResult
    {
        [JsonPropertyName("is_valid")]
        public bool IsValid { get; set; }


        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }
}
