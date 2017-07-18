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
        /// 開始結帳 Get 方法
        /// </summary>
        /// <param name="CookeId">CookeId</param>
        /// <param name="UserId">使用者</param>
        /// <param name="Products">產品列，範例：[{ProductId:"產品編號",ProductName:"產品名稱",Color:"顏色",Size:"尺寸",Quantity:數量,Price:價格},{ProductId:"產品編號",ProductName:"產品名稱",Color:"顏色",Size:"尺寸",Quantity:數量,Price:價格}]</param>
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
        /// 開始結帳 Post 方法，範例：{CookeId:"ykvj01xtgnnibglou2m0igb2",UserId:"使用者",Product:[{ProductId:"產品編號",ProductName:"產品名稱",Color:"顏色",Size:"尺寸",Quantity:數量,Price:價格},{ProductId:"產品編號",ProductName:"產品名稱",Color:"顏色",Size:"尺寸",Quantity:數量,Price:價格}] }
        /// </summary>
        /// <param name="value">Json</param>
        /// <returns></returns>
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
