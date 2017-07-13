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
    /// 完成註冊
    /// </summary>
    public class CompleteRegistrationController : ApiController
    {
        /// <summary>
        /// Get 方法
        /// </summary>
        /// <param name="CookeId">CookeId</param>
        /// <param name="UserId">使用者</param>
        /// <param name="UserName">使用者名稱</param>
        /// <param name="Sex">性別</param>
        /// <param name="Tel">電話</param>
        /// <param name="Birthday">生日</param>
        /// <param name="Email">郵件</param>
        /// <returns>Json 範例：{ "Valid": true, "Error": "string" }</returns>
        [HttpGet]
        public async Task<IHttpActionResult> Get(string CookeId, string UserId, string UserName, string Sex, string Tel, DateTime Birthday, string Email)
        {
            try
            {
                IRepository<CompleteRegistration> reposity = new Repository<CompleteRegistration>();

                CompleteRegistration item = new CompleteRegistration()
                {
                    CookeId = CookeId,
                    UserId = UserId,
                    UserName = UserName,
                    Sex = Sex,
                    Tel = Tel,
                    Birthday = Birthday,
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
        /// Post 方法，範例：{ "CookeId": "qwertyuiopasdfghjjvbx", "UserId": "官網123456789", "UserName": "橘熊科技股份有限公司", "Sex": "女", "Tel": "0277226870", "Birthday": "2017-01-05", "Email": "ob@obdesign.com.tw" }
        /// </summary>
        /// <param name="value">Json</param>
        /// <returns>Json 範例：{ "Valid": true, "Error": "string" }</returns>
        [HttpPost]
        public async Task<IHttpActionResult> Post(CompleteRegistration value)
        {
            try
            {
                IRepository<CompleteRegistration> reposity = new Repository<CompleteRegistration>();
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
