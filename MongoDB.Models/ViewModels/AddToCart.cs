using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace MongoDB.Models.ViewModels
{
    /// <summary>
    /// 加到購物車
    /// </summary>
    public class AddToCart
    {
        public AddToCart()
        {
            Product = new ViewModels.Product();
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
        /// 加入商品
        /// </summary>
        [BsonElement("Product")]
        public Product Product { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        [BsonElement("CreateTime")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateTime { get; set; }
    }
}
