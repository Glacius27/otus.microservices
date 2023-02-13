﻿using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace application
{
    public class DataBaseService
    {
        private readonly IMongoCollection<User> _users;
        
        public DataBaseService(IDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<User>("Users");
        }

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public IList<User> Read() =>
            _users.Find(x => true).ToList();

        public User Find(string userId) =>
            _users.Find(x => x.UserID == userId).SingleOrDefault();

        public UpdateResult Update(string userId, User user)
        {
            var update = Builders<User>.Update
                    .Set(x => x.FirstName, user.FirstName)
                    .Set(x => x.LastName, user.LastName)
                    .Set(x => x.Email, user.Email)
                    .Set(x => x.Phone, user.Phone);
            var result = _users.UpdateOne(x => x.UserID == userId, update);
            return result;
        }
        public DeleteResult Delete(string id) =>
            _users.DeleteOne(x => x.UserID == id);
    }
}
