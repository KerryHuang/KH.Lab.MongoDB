using MongoDB.Models.Implement;
using MongoDB.Models.Interface;
using MongoDB.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;

namespace MongoDB.WebAPI.Controllers
{
    /// <summary>
    /// 搜尋
    /// </summary>
    public class SearchController : ApiController
    {
        /// <summary>
        /// 搜尋 Get 方法
        /// </summary>
        /// <param name="CookeId">CookeId</param>
        /// <param name="UserId">使用者</param>
        /// <param name="KeyWord">關鍵字</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> Get(string CookeId, string UserId, string KeyWord)
        {
            try
            {
                IRepository<Search> reposity = new Repository<Search>();

                Search item = new Search()
                {
                    CookeId = CookeId,
                    UserId = UserId,
                    KeyWord = KeyWord
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
        /// 搜尋 Post 方法
        /// </summary>
        /// <param name="value">Json，範例：{CookeId:"ykvj01xtgnnibglou2m0igb2",UserId:"使用者",KeyWord:"關鍵字"}</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Post(Search value)
        {
            try
            {
                IRepository<Search> reposity = new Repository<Search>();
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
