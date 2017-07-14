using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using MongoDB.Models.ViewModels;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MongoDB.WebAPI.Lib;

namespace MongoDB.WebAPI.Controllers
{
    /// <summary>
    /// Home
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Index
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Home Page";

            //await OBGALib.Post(OBGALib.Type.Search, "");

            return View();
        }
    }
}
