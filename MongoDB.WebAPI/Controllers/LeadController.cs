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
    /// 潛在顧客
    /// </summary>
    public class LeadController : ApiController
    {
        /// <summary>
        /// 潛在顧客 Get 方法
        /// </summary>
        /// <param name="CookeId">CookeId</param>
        /// <param name="UserId">使用者</param>
        /// <param name="UserName">使用者名稱</param>
        /// <param name="Tel">電話</param>
        /// <param name="Email">郵件</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> Get(string CookeId, string UserId, string UserName, string Tel, string Email)
        {
            try
            {
                IRepository<Lead> reposity = new Repository<Lead>();

                Lead item = new Lead()
                {
                    CookeId = CookeId,
                    UserId = UserId,
                    UserName = UserName,
                    Tel = Tel,
                    Email = Email
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
        /// 潛在顧客 Post 方法
        /// </summary>
        /// <param name="value">Json，範例：{CookeId:"ykvj01xtgnnibglou2m0igb2",UserId:"使用者",UserName:"使用者名稱",Tel:"電話",Email:"郵件"}</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Post(Lead value)
        {
            try
            {
                IRepository<Lead> reposity = new Repository<Lead>();
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
