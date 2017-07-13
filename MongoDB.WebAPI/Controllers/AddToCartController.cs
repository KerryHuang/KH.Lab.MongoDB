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
using System.Web.Http.Description;

namespace MongoDB.WebAPI.Controllers
{
    /// <summary>
    /// 加到購物車
    /// </summary>
    public class AddToCartController : ApiController
    {
        /// <summary>
        /// Get 方法
        /// </summary>
        /// <param name="CookeId">CookeId</param>
        /// <param name="UserId">使用者</param>
        /// <param name="ProductId">產品編號</param>
        /// <param name="ProductName">產品名稱</param>
        /// <param name="Color">顏色</param>
        /// <param name="Size">尺寸</param>
        /// <param name="Quantity">數量</param>
        /// <param name="Price">價格</param>
        /// <returns>Json 範例：{ "Valid": true, "Error": "string" }</returns>
        [HttpGet]
        public async Task<IHttpActionResult> Get(string CookeId, string UserId, string ProductId, string ProductName, string Color, string Size, int Quantity, double Price)
        {
            try
            {
                IRepository<AddToCart> reposity = new Repository<AddToCart>();

                AddToCart item = new AddToCart()
                {
                    CookeId = CookeId,
                    UserId = UserId,
                    Product = new Product()
                    {
                        ProductId = ProductId,
                        ProductName = ProductName,
                        Color = Color,
                        Size = Size,
                        Quantity = Quantity,
                        Price = Price
                    }
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
        /// Post 方法，範例：{"CookeId":"qwertyuiopasdfghjjvbx","UserId":"官網123456789","Product":{"ProductId":"K129091","ProductName":"韓版圓領不規則感豹紋口袋長版上衣‧2色","Color":"白","Size":"M","Quantity":1,"Price":319,"Subtotal":319}}
        /// </summary>
        /// <param name="value">Json</param>
        /// <returns>Json 範例：{ "Valid": true, "Error": "string" }</returns>
        [HttpPost]
        public async Task<IHttpActionResult> Post(AddToCart value)
        {
            try
            {
                IRepository<AddToCart> reposity = new Repository<AddToCart>();
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
