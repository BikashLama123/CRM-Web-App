using CRMInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CRMInterface.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllStaff()
        {
            IEnumerable<StaffView> stfList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Staff").Result;
            stfList = response.Content.ReadAsAsync<IEnumerable<StaffView>>().Result;
            return this.Json(stfList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult EditStaff(int id)
        {
            IEnumerable<StaffView> stfList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Staff/" +id).Result;
            stfList = response.Content.ReadAsAsync<IEnumerable<StaffView>>().Result;
            return this.Json(stfList, JsonRequestBehavior.AllowGet);
        }
    }
}