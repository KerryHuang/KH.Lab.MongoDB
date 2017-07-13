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
    /// 查看內容
    /// </summary>
    public class ViewContentController : ApiController
    {
        /// <summary>
        /// Get 方法
        /// </summary>
        /// <param name="CookeId">CookeId</param>
        /// <param name="UserId">使用者</param>
        /// <param name="ProductId">產品編號</param>
        /// <param name="ProductName">產品名稱</param>
        /// <returns>Json 範例：{ "Valid": true, "Error": "string" }</returns>
        [HttpGet]
        public async Task<IHttpActionResult> Get(string CookeId, string UserId, string ProductId, string ProductName)
        {
            try
            {
                IRepository<ViewContent> reposity = new Repository<ViewContent>();

                ViewContent item = new ViewContent()
                {
                    CookeId = CookeId,
                    UserId = UserId,
                    ProductId = ProductId,
                    ProductName = ProductName
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
        /// Post 方法，範例：{ "CookeId": "qwertyuiopasdfghjjvbx", "UserId": "官網123456789", "ProductId": "K129091", "ProductName": "韓版圓領不規則感豹紋口袋長版上衣‧2色" }
        /// </summary>
        /// <param name="value">Json</param>
        /// <returns>Json 範例：{ "Valid": true, "Error": "string" }</returns>
        [HttpPost]
        public async Task<IHttpActionResult> Post(ViewContent value)
        {
            try
            {
                IRepository<ViewContent> reposity = new Repository<ViewContent>();
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
