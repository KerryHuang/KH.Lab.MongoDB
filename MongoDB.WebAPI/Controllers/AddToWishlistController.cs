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
    /// 加到願望清單
    /// </summary>
    public class AddToWishlistController : ApiController
    {
        /// <summary>
        /// 加到願望清單 Get 方法
        /// </summary>
        /// <param name="CookeId"></param>
        /// <param name="UserId">使用者</param>
        /// <param name="ProductId">產品編號</param>
        /// <param name="ProductName">產品名稱</param>
        /// <param name="Price">價格</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> Get(string CookeId, string UserId, string ProductId, string ProductName, double Price)
        {
            try
            {
                IRepository<AddToWishlist> reposity = new Repository<AddToWishlist>();

                AddToWishlist item = new AddToWishlist()
                {
                    CookeId = CookeId,
                    UserId = UserId,
                    ProductId = ProductId,
                    ProductName = ProductName,
                    Price = Price
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
        /// 加到願望清單 Post 方法
        /// </summary>
        /// <param name="value">Json，範例：{CookeId:"ykvj01xtgnnibglou2m0igb2",UserId:"使用者",ProductId:"產品編號",ProductName:"產品名稱",Price:價格}</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Post(AddToWishlist value)
        {
            try
            {
                IRepository<AddToWishlist> reposity = new Repository<AddToWishlist>();
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
