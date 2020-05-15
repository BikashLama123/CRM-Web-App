using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using CRMInterface.Models;

namespace CRMInterface.Controllers
{
    public class StaffController : Controller
    {
        // GET: Task
        public ActionResult ViewStaff()
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

        public ActionResult AddEditStaff(int id = 0)
        {
            if (id == 0)
            {
                return View(new Staff());
            }
            else
            {
                //IEnumerable<CustomerVIew> csList;
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Staff/" + id).Result;
                //csList = response.Content.ReadAsAsync<IEnumerable<CustomerVIew>>().Result;
                return View(response.Content.ReadAsAsync<Staff>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddEditStaff(Staff newStaff)
        {
            if (newStaff.sid == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Staff",newStaff).Result;
                TempData["Success"] = newStaff.suserName + " Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Staff/" + newStaff.sid, newStaff).Result;
                TempData["Success"] = newStaff.suserName + " Updated Successfully";
            }
            return View();
        }

        [HttpGet]
        public JsonResult DeleteStaff(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Staff/" + id).Result;
            return this.Json(1, JsonRequestBehavior.AllowGet);
        }
    }
}