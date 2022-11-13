using System;
using Newtonsoft.Json;
using SmarthThingsSDK.Net.Interfaces;

namespace SmarthThingsSDK.Net.Models
{
    public class Error
    {
        public partial class ErrorResponse : IEntity
        {
            [JsonProperty("requestId")]
            public string RequestId { get; set; }
            [JsonProperty("error")]
            public ErrorObject Error { get; set; }

            
        }
        public partial class ErrorObject
        {
            [JsonProperty("code")]
            public string Code { get; set; }
            [JsonProperty("message")]
            public string Message { get; set; }
            [JsonProperty("target")]
            public string Target { get; set; }
            [JsonProperty("details")]
            public ErrorObject[] ErrorDetails { get; set; } //how come man?
        }
    }
}

