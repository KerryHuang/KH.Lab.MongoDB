using MongoDB.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using System.Collections;

namespace MongoDB.Models.Implement
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        protected IMongoClient _client
        {
            get;
            private set;
        }
        protected IMongoDatabase _db
        {
            get;
            private set;
        }
        protected string _collectioname
        {
            get;
            private set;
        }
        protected static string _connectionString = "mongodb://localhost:27017";
        protected static string _database = "OBDB";

        public Repository()
        {
            _collectioname = typeof(T).Name;
            _client = new MongoClient(_connectionString);
            _db = _client.GetDatabase(_database);
        }

        public Repository(string DataBase, string ConnectionString)
        {
            _collectioname = typeof(T).Name;
            _client = new MongoClient(ConnectionString);
            _db = _client.GetDatabase(DataBase);
        }

        public IEnumerable<T> GetAll()
        {
            return _db.GetCollection<T>(_collectioname).Find(_ => true).ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await (await _db.GetCollection<T>(_collectioname).FindAsync(_ => true)).ToListAsync();
        }

        public T Get(Bson.ObjectId id)
        {
            var collection = _db.GetCollection<T>(_collectioname);
            var filter = Builders<T>.Filter.Eq("Id", id);
            var result = collection.Find(filter).ToList();
            return result.FirstOrDefault();
        }

        public async Task<T> GetAsync(Bson.ObjectId id)
        {
            var collection = _db.GetCollection<T>(_collectioname);
            var filter = Builders<T>.Filter.Eq("Id", id);
            var result = await collection.Find(filter).ToListAsync();
            return result.FirstOrDefault();
        }

        public void Create(T entity)
        {
            _db.GetCollection<T>(_collectioname).InsertOne(entity);
        }

        public async Task CreateAsync(T entity)
        {
            await _db.GetCollection<T>(_collectioname).InsertOneAsync(entity);
        }

        public void Update(Bson.ObjectId id, T entity)
        {
            var collection = _db.GetCollection<T>(_collectioname);
            var filter = Builders<T>.Filter.Eq("Id", id);
            var update = Builders<T>.Update.Set("Price", "100").CurrentDate("UpdateDateTime");
            var result = collection.UpdateOne(filter, update);
        }

        public void Update(Bson.ObjectId id, UpdateDefinition<T> update)
        {
            var collection = _db.GetCollection<T>(_collectioname);
            var filter = Builders<T>.Filter.Eq("Id", id);
            //var update = Builders<T>.Update.Set("Price", "100").CurrentDate("UpdateDateTime");
            update = update.CurrentDate("UpdateDateTime");
            var result = collection.UpdateOne(filter, update);
        }

        public async Task UpdateAsync(Bson.ObjectId id, T entity)
        {
            var collection = _db.GetCollection<T>(_collectioname);
            var filter = Builders<T>.Filter.Eq("Id", id);
            var update = Builders<T>.Update.Set("Price", "1").CurrentDate("UpdateDateTime");
            var result = await collection.UpdateOneAsync(filter, update);
        }

        public async Task UpdateAsync(Bson.ObjectId id, UpdateDefinition<T> update)
        {
            var collection = _db.GetCollection<T>(_collectioname);
            var filter = Builders<T>.Filter.Eq("Id", id);
            update = update.CurrentDate("UpdateDateTime");
            var result = await collection.UpdateOneAsync(filter, update);
        }

        public void Delete(Bson.ObjectId id)
        {
            var collection = _db.GetCollection<T>(_collectioname);
            var filter = Builders<T>.Filter.Eq("Id", id);
            var result = collection.DeleteOne(filter);
        }

        public async Task DeleteAsync(Bson.ObjectId id)
        {
            var collection = _db.GetCollection<T>(_collectioname);
            var filter = Builders<T>.Filter.Eq("Id", id);
            var result = await collection.DeleteOneAsync(filter);
        }

        public void DeleteAll()
        {
            var collection = _db.GetCollection<T>(_collectioname);
            var result = collection.DeleteMany(_ => true);
        }

        public async Task DeleteAllAsync()
        {
            var collection = _db.GetCollection<T>(_collectioname);
            var result = await collection.DeleteManyAsync(_ => true);
        }

        public void Drop()
        {
            _db.DropCollection(_collectioname);
        }

        public async Task DropAsync()
        {
            await _db.DropCollectionAsync(_collectioname);
        }
    }
}
