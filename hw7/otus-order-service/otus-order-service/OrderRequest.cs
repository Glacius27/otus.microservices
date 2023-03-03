using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace otus_order_service
{
	public class OrderRequest
	{
        [JsonProperty("UserID")]
        public string UserID { get; set; }
        [JsonProperty("Goods")]
        public Good[] Goods { get; set; }
        [JsonProperty("CustomerComment")]
        public string CustomerComment { get; set; }
    }
}

