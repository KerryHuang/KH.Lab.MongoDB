using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB.Models.ViewModels
{
    /// <summary>
    /// 潛在顧客
    /// </summary>
    public class Lead
    {
        public Lead()
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
        /// 使用者名稱
        /// </summary>
        [BsonElement("UserName")]
        public string UserName { get; set; }
        /// <summary>
        /// 電話
        /// </summary>
        [BsonElement("Tel")]
        public string Tel { get; set; }
        /// <summary>
        /// 郵件
        /// </summary>
        [BsonElement("Email")]
        public string Email { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        [BsonElement("CreateTime")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateTime { get; set; }
    }
}
