using System;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace MongoDB.Models.ViewModels
{
    /// <summary>
    /// 開始結帳
    /// </summary>
    public class InitiateCheckout
    {
        public InitiateCheckout()
        {
            CreateTime = DateTime.Now;
            Products = new List<Product>();
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
        /// 購買產品資料
        /// </summary>
        [BsonElement("Products")]
        public List<Product> Products { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        [BsonElement("CreateTime")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateTime { get; set; }
    }
}
