using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace otus_order_service;

public class Order
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [JsonProperty("OrderID")]
    public string OrderID {get; set;}
    [JsonProperty("UserID")]
    public string UserID { get; set; }
    [JsonProperty("OrderDateTime")]
    public DateTime Date { get; set; }
    [JsonProperty("Goods")]
    public Good[] Goods { get; set; }
    [JsonProperty("CustomerComment")]
    public string CustomerComment { get; set; }
    [JsonProperty("Status")]
    public string Status { get; set; }
}

public class Good
{
    [JsonProperty("ID")]
    public string ID { get; set; }
    [JsonProperty("Count")]
    public string Count { get; set; }
}


