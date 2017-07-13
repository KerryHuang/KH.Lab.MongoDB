using MongoDB.Models.Implement;
using MongoDB.Models.Interface;
using MongoDB.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MongoDB.WebAPI.Controllers
{
    /// <summary>
    /// 開始結帳
    /// </summary>
    public class InitiateCheckoutController : ApiController
    {
        /// <summary>
        /// Get 方法
        /// </summary>
        /// <param name="CookeId">CookeId</param>
        /// <param name="UserId">使用者</param>
        /// <param name="Products">產品列，範例：[{"ProductId": "A5151", "ProductName": "童年記憶~寶藍系菱格車線動物印圖連帽長版上衣", "Color": "白", "Size": "M", "Quantity": 1, "Price": 199},{ "ProductId": "K129091", "ProductName": "韓版圓領不規則感豹紋口袋長版上衣‧2色", "Color": "白", "Size": "M", "Quantity": 1, "Price": 319 }]</param>
        /// <returns>Json 範例：{ "Valid": true, "Error": "string" }</returns>
        [HttpGet]
        public async Task<IHttpActionResult> Get(string CookeId, string UserId, string Products)
        {
            try
            {
                IRepository<InitiateCheckout> reposity = new Repository<InitiateCheckout>();

                InitiateCheckout item = new InitiateCheckout()
                {
                    CookeId = CookeId,
                    UserId = UserId,
                    Products = JsonConvert.DeserializeObject<List<Product>>(Products)
                };

                await reposity.CreateAsync(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        /// <summary>
        /// Post 方法，範例：{"CookeId": "qwertyuiopasdfghjjvbx", "UserId": "官網123456789", "Product": [{"ProductId": "A5151", "ProductName": "童年記憶~寶藍系菱格車線動物印圖連帽長版上衣", "Color": "白", "Size": "M", "Quantity": 1, "Price": 199},{ "ProductId": "K129091", "ProductName": "韓版圓領不規則感豹紋口袋長版上衣‧2色", "Color": "白", "Size": "M", "Quantity": 1, "Price": 319 }] }
        /// </summary>
        /// <param name="value">Json</param>
        /// <returns>Json 範例：{ "Valid": true, "Error": "string" }</returns>
        [HttpPost]
        public async Task<IHttpActionResult> Post(InitiateCheckout value)
        {
            try
            {
                IRepository<InitiateCheckout> reposity = new Repository<InitiateCheckout>();
                await reposity.CreateAsync(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
