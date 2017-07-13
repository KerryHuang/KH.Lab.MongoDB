using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB.Models.ViewModels
{
    public class Product
    {
        public Product()
        {
            Id = ObjectId.GenerateNewId();
            Quantity = 0;
            Price = 0;
            CreateTime = DateTime.Now;
        }

        [BsonId]
        public ObjectId Id { get; set; }
        /// <summary>
        /// 產品編號
        /// </summary>
        [BsonElement("ProductId")]
        public string ProductId { get; set; }
        /// <summary>
        /// 產品名稱
        /// </summary>
        [BsonElement("ProductName")]
        public string ProductName { get; set; }
        /// <summary>
        /// 顏色
        /// </summary>
        [BsonElement("Color")]
        public string Color { get; set; }
        /// <summary>
        /// 尺寸
        /// </summary>
        [BsonElement("Size")]
        public string Size { get; set; }
        /// <summary>
        /// 數量
        /// </summary>
        [BsonElement("Quantity")]
        public int Quantity { get; set; }
        /// <summary>
        /// 價格
        /// </summary>
        [BsonElement("Price")]
        public double Price { get; set; }
        /// <summary>
        /// 小計
        /// </summary>
        public double Subtotal
        {
            get { return Quantity * Price; }
        }
        /// <summary>
        /// 建立時間
        /// </summary>
        [BsonElement("CreateTime")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateTime { get; set; }
    }
}
