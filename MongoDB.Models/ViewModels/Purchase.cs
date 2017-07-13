using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace MongoDB.Models.ViewModels
{
    /// <summary>
    /// 購買
    /// </summary>
    public class Purchase
    {
        public Purchase()
        {
            CouponMoney = 0;
            FeedbackMoney = 0;
            ShoppingMoney = 0;
            TotalAmount = 0;
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
        /// 使用折價卷
        /// </summary>
        [BsonElement("CouponMoney")]
        public int CouponMoney { get; set; }
        /// <summary>
        /// 使用回鐀金
        /// </summary>
        [BsonElement("FeedbackMoney")]
        public int FeedbackMoney { get; set; }
        /// <summary>
        /// 使用購物金
        /// </summary>
        [BsonElement("ShoppingMoney")]
        public int ShoppingMoney { get; set; }
        /// <summary>
        /// 付款總金額
        /// </summary>s
        [BsonElement("TotalAmount")]
        public int TotalAmount { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        [BsonElement("CreateTime")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateTime { get; set; }
    }
}
