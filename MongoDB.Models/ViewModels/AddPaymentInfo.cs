using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB.Models.ViewModels
{
    /// <summary>
    /// 新增付款資料
    /// </summary>
    public class AddPaymentInfo
    {
        public AddPaymentInfo()
        {
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
        /// 收件人
        /// </summary>
        [BsonElement("UserName")]
        public string UserName { get; set; }
        /// <summary>
        /// 收件人電話
        /// </summary>
        [BsonElement("Tel")]
        public string Tel { get; set; }
        /// <summary>
        /// 收件人地址
        /// </summary>
        [BsonElement("Address")]
        public string Address { get; set; }
        /// <summary>
        /// 付款方式
        /// </summary>
        [BsonElement("PaymentType")]
        public string PaymentType { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        [BsonElement("CreateTime")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateTime { get; set; }
    }
}
