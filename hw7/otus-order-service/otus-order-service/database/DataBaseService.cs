using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using otus_order_service;

namespace application
{
    public class DataBaseService
    {
        private readonly IMongoCollection<Order> _order;
        

        public DataBaseService(IDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _order = database.GetCollection<Order>("Orders");

        }

        public Order Create(Order order)
        {
            _order.InsertOne(order);
            return order;
        }

        public IList<Order> Read() =>
            _order.Find(x => true).ToList();

        public Order Find(string orderID) =>
            _order.Find(x => x.OrderID == orderID).SingleOrDefault();

       

        public UpdateResult Update(string orderID, OrderRequest orderRequest)
        {
            var update = Builders<Order>.Update
                    .Set(x => x.UserID, orderRequest.UserID)
                    .Set(x => x.Date, DateTime.Now)
                    .Set(x => x.Goods, orderRequest.Goods)
                    .Set(x => x.Status, "Pending")
                    .Set(x => x.CustomerComment, orderRequest.CustomerComment);
            var result = _order.UpdateOne(x => x.OrderID == orderID, update);
            return result;
        }

        public UpdateResult Update(string orderID)
        {
            var update = Builders<Order>.Update
                    .Set(x => x.Status, "Canceled");
            var result = _order.UpdateOne(x => x.OrderID == orderID, update);
            return result;
        }

    }
}
