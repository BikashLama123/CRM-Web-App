using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using CRMInterface.Models;

namespace CRMInterface.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllProduct()
        {
            IEnumerable<ProductView> csList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Product").Result;
            csList = response.Content.ReadAsAsync<IEnumerable<ProductView>>().Result;
            return this.Json(csList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddEditProduct(int id = 0)
        {
            if (id == 0)
            {
                return View(new ProductView());
            }
            else
            {
                //IEnumerable<CustomerVIew> csList;
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Product/" + id).Result;
                //csList = response.Content.ReadAsAsync<IEnumerable<CustomerVIew>>().Result;
                return View(response.Content.ReadAsAsync<ProductView>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddEditProduct(ProductView product)
        {
            if (product.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Product", product).Result;
                TempData["Success"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Product/" + product.Id, product).Result;
                TempData["Success"] = "Updated Successfully";
            }
            return View();
        }

        [HttpGet]
        public JsonResult DeleteProduct(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Product/" + id).Result;
            return this.Json(1, JsonRequestBehavior.AllowGet);
        }
    }
}