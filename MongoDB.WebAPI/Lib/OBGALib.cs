using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace MongoDB.WebAPI.Lib
{
    /// <summary>
    /// 發送資料類別
    /// </summary>
    public static class OBGALib
    {
        /// <summary>
        /// 發送資料
        /// </summary>
        /// <param name="type">類別</param>
        /// <param name="jsondata">Json資料</param>
        /// <returns></returns>
        public static async Task<bool> Post(Type type, string jsondata)
        {
            string domin = "http://192.168.1.101:7771/api/";

            using (var client = new HttpClient())
            {
                try
                {
                    var buffer = System.Text.Encoding.UTF8.GetBytes(jsondata);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var result = await client.PostAsync(domin + type.ToString(), byteContent);
                    //object value = await JsonConvert.DeserializeObjectAsync<object>(jsondata);
                    //var result = await client.PostAsJsonAsync(domin + type.ToString(), value);
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch { return false; }
            }
        }

        /// <summary>
        /// 類別
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// 查看內容
            /// </summary>
            ViewContent,
            /// <summary>
            /// 搜尋
            /// </summary>
            Search,
            /// <summary>
            /// 加到購物車
            /// </summary>
            AddToCart,
            /// <summary>
            /// 加到願望清單
            /// </summary>
            AddToWishlist,
            /// <summary>
            /// 開始結帳
            /// </summary>
            InitiateCheckout,
            /// <summary>
            /// 新增付款資料
            /// </summary>
            AddPaymentInfo,
            /// <summary>
            /// 購買
            /// </summary>
            Purchase,
            /// <summary>
            /// 潛在顧客
            /// </summary>
            Lead,
            /// <summary>
            /// 完成註冊
            /// </summary>
            CompleteRegistration
        }
    }
}