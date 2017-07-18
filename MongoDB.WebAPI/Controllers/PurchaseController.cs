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
    /// 購買
    /// </summary>
    public class PurchaseController : ApiController
    {
        /// <summary>
        /// 購買 Get 方法
        /// </summary>
        /// <param name="CookeId">CookeId</param>
        /// <param name="UserId">使用者</param>
        /// <param name="CouponMoney">使用折價卷</param>
        /// <param name="FeedbackMoney">使用回鐀金</param>
        /// <param name="ShoppingMoney">使用購物金</param>
        /// <param name="TotalAmount">總金額</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IHttpActionResult> Get(string CookeId, string UserId, int CouponMoney, int FeedbackMoney, int ShoppingMoney, int TotalAmount)
        {
            try
            {
                IRepository<Purchase> reposity = new Repository<Purchase>();

                Purchase item = new Purchase()
                {
                    CookeId = CookeId,
                    UserId = UserId,
                    CouponMoney = CouponMoney,
                    FeedbackMoney = FeedbackMoney,
                    ShoppingMoney = ShoppingMoney,
                    TotalAmount = TotalAmount
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
        /// 購買 Post 方法
        /// </summary>
        /// <param name="value">Json，範例：{CookeId:"ykvj01xtgnnibglou2m0igb2",UserId:"使用者",CouponMoney:使用折價卷,FeedbackMoney:使用購物金,ShoppingMoney:使用購物金,TotalAmount:總金額}</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IHttpActionResult> Post(Purchase value)
        {
            try
            {
                IRepository<Purchase> reposity = new Repository<Purchase>();
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
