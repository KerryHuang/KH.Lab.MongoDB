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
        /// 完成註冊 Get 方法
        /// </summary>
        /// <param name="CookeId">CookeId</param>
        /// <param name="UserId">使用者</param>
        /// <param name="UserName">使用者名稱</param>
        /// <param name="Sex">性別</param>
        /// <param name="Tel">電話</param>
        /// <param name="Birthday">生日</param>
        /// <param name="Email">郵件</param>
        /// <returns></returns>
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
        /// 完成註冊 Post 方法
        /// </summary>
        /// <param name="value">Json，範例：{CookeId:"ykvj01xtgnnibglou2m0igb2",UserId:"使用者",UserName:"使用者名稱",Sex:"性別",Tel:"電話",Birthday:"生日",Email:"郵件"}</param>
        /// <returns></returns>
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
