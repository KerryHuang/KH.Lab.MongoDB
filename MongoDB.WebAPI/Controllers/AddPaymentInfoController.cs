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
    /// 新增付款資料
    /// </summary>
    public class AddPaymentInfoController : ApiController
    {
        /// <summary>
        /// 新增付款資料 Get 方法
        /// </summary>
        /// <param name="CookeId">CookeId</param>
        /// <param name="UserId">使用者</param>
        /// <param name="UserName">收件人</param>
        /// <param name="Tel">收件人電話</param>
        /// <param name="Address">收件人地址</param>
        /// <param name="PaymentType">付款方式</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> Get(string CookeId, string UserId, string UserName, string Tel, string Address, string PaymentType)
        {
            try
            {
                IRepository<AddPaymentInfo> reposity = new Repository<AddPaymentInfo>();

                AddPaymentInfo item = new AddPaymentInfo()
                {
                    CookeId = CookeId,
                    UserId = UserId,
                    UserName = UserName,
                    Tel = Tel,
                    Address = Address,
                    PaymentType = PaymentType
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
        /// 新增付款資料 Post 方法
        /// </summary>
        /// <param name="value">Json，範例：{CookeId:"ykvj01xtgnnibglou2m0igb2",UserId:"使用者",UserName:"收件人",Tel:"收件人電話",Address:"收件人地址",PaymentType:"付款方式"}</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Post(AddPaymentInfo value)
        {
            try
            {
                IRepository<AddPaymentInfo> reposity = new Repository<AddPaymentInfo>();
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
