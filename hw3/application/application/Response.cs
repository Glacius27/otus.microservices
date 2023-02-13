using System;
using Newtonsoft.Json;

namespace application
{
    public class Response
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
