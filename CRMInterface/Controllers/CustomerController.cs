using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using CRMInterface.Models;

namespace CRMInterface.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllCustomer()
        {
            IEnumerable<CustomerVIew> csList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Customer").Result;
            csList = response.Content.ReadAsAsync<IEnumerable<CustomerVIew>>().Result;
            return this.Json(csList, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult AddEditCustomer(int id=0)
        {
            if(id==0)
            {
                return View(new CustomerVIew());
            }
            else
            {
                //IEnumerable<CustomerVIew> csList;
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Customer/"+id).Result;
                //csList = response.Content.ReadAsAsync<IEnumerable<CustomerVIew>>().Result;
                return View(response.Content.ReadAsAsync<CustomerVIew>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddEditCustomer(CustomerVIew customer)
        {
            if(customer.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Customer", customer).Result;
                TempData["Success"] = customer.Username + " Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Customer/"+customer.Id, customer).Result;
                TempData["Success"] = customer.Username + " Updated Successfully";
            }
            return View();
        }

        [HttpGet]
        public JsonResult DeleteCustomer(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Customer/" + id).Result;
            return this.Json(1, JsonRequestBehavior.AllowGet);
        }
    }
}