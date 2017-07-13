using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB.Models.ViewModels
{
    /// <summary>
    /// 加到願望清單
    /// </summary>
    public class AddToWishlist
    {
        public AddToWishlist()
        {
            Price = 0;
            CreateTime = DateTime.Now;
        }

        [BsonId]
        public ObjectId Id { get; set; }
        /// <summary>
        /// CookeId
        /// </summary>
        [BsonElement("CookeId")]
        public string CookeId { get; set; }
        /// <summary>
        /// 使用者
        /// </summary>
        [BsonElement("UserId")]
        public string UserId { get; set; }
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
        /// 價格
        /// </summary>
        [BsonElement("Price")]
        public double Price { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        [BsonElement("CreateTime")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateTime { get; set; }
    }
}
