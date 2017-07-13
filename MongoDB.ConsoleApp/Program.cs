using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Models.Interface;
using MongoDB.Models.ViewModels;
using MongoDB.Models.Implement;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository<Product> repository = new Repository<Product>();

            //repository.Drop();

            //for (int i = 1; i < 11; i++)
            //{
            //    Product product = new Product()
            //    {
            //        ProductId = 10001 + i,
            //        ProductName = "SSD" + i.ToString("00"),
            //        Price = 9000,
            //        Category = "Electronics" + i.ToString("00")
            //    };
            //    repository.Create(product);
            //}

            ObjectId id = ObjectId.Parse("596481eba2cf431eb43da8a6");
            var item = repository.Get(id);
            var update = Builders<Product>.Update.Set("Price", "100");
            repository.Update(id, update);

            //var items = repository.GetAll().ToList();
            //foreach (var p in items)
            //{
            //    repository.Delete(p.Id);
            //}

            Console.ReadKey();

        }
    }
}
