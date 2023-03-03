using System;
using Newtonsoft.Json;

namespace otus_order_service
{
    public class Response
    {
        [JsonProperty("data")]
        public object Data { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}

