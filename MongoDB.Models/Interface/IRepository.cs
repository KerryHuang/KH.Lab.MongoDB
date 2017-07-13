using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;

namespace MongoDB.Models.Interface
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T Get(ObjectId id);
        Task<T> GetAsync(ObjectId id);
        void Create(T entity);
        Task CreateAsync(T entity);
        void Update(ObjectId id, UpdateDefinition<T> update);
        Task UpdateAsync(ObjectId id, UpdateDefinition<T> update);
        void Delete(ObjectId id);
        Task DeleteAsync(ObjectId id);
        void DeleteAll();
        Task DeleteAllAsync();
        void Drop();
        Task DropAsync();
    }
}
