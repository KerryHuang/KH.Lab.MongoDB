using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;

namespace MongoDB.Model
{
    public class DataAccess<T>
        where T : class
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _db;
        protected static string _databasename = "restaurants";
        

        public DataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _db = _client.GetDatabase(_databasename);
        }

        public IEnumerable<T> GetAll()
        {
            return _db.GetCollection<T>(_databasename).Find(_ => true).ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await (await _db.GetCollection<T>(_databasename).FindAsync(_ => true)).ToListAsync();
        }

        public T Get(ObjectId id)
        {
            var collection = _db.GetCollection<T>(_databasename);
            var filter = Builders<T>.Filter.Eq("Id", id);
            var result = collection.Find(filter).ToList();
            return result.FirstOrDefault();
        }

        public async Task<T> GetAsync(ObjectId id)
        {
            var collection = _db.GetCollection<T>(_databasename);
            var filter = Builders<T>.Filter.Eq("Id", id);
            var result = await collection.Find(filter).ToListAsync();
            return result.FirstOrDefault();
        }

        public void Create(T entity)
        {
            _db.GetCollection<T>(_databasename).InsertOne(entity);
        }

        public async Task CreateAsync(T entity)
        {
            await _db.GetCollection<T>(_databasename).InsertOneAsync(entity);
        }

        public void Update(ObjectId id, T p)
        {
            var collection = _db.GetCollection<T>("restaurants");
            var filter = Builders<T>.Filter.Eq("Id", id);
            var update = Builders<T>.Update.Set("Price", "100").CurrentDate("lastModified");
            var result = collection.UpdateOne(filter, update);
        }

        public async Task UpdateAsync(ObjectId id, T p)
        {
            var collection = _db.GetCollection<T>("restaurants");
            var filter = Builders<T>.Filter.Eq("ProductName", "Juni");
            var update = Builders<T>.Update.Set("Price", "1").CurrentDate("lastModified");
            var result = await collection.UpdateOneAsync(filter, update);
        }

        public void Delete(ObjectId id)
        {
            var collection = _db.GetCollection<T>(_databasename);
            var filter = Builders<T>.Filter.Eq("Id", id);
            var result = collection.DeleteOne(filter);
        }

        public async Task DeleteAsync(ObjectId id)
        {
            var collection = _db.GetCollection<T>(_databasename);
            var filter = Builders<T>.Filter.Eq("Id", id);
            var result = await collection.DeleteManyAsync(filter);
        }

        public void DeleteAll()
        {
            var collection = _db.GetCollection<T>("restaurants");
            var result = collection.DeleteMany(_ => true);
        }

        public async Task DeleteAllAsync()
        {
            var collection = _db.GetCollection<T>("restaurants");
            var result = await collection.DeleteManyAsync(_ => true);
        }

        public async Task DropAsync()
        {
            await _db.DropCollectionAsync("restaurants");
        }
    }
}
