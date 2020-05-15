using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRMAPI.Models;

namespace CRMAPI.Controllers.CRM
{
    public class ProductController : ApiController
    {
        CRMEntities db_context = new CRMEntities();

        public IHttpActionResult GetProducts()
        {
            db_context.Configuration.ProxyCreationEnabled = false;
            var result = db_context.Product.ToList();
            return Ok(result);
        }

        public IHttpActionResult GetProduct(int id)
        {
            db_context.Configuration.ProxyCreationEnabled = false;
            var result = db_context.Product.Find(id);
            return Ok(result);
        }

        public IHttpActionResult PostProduct(Product newProduct)
        {
            db_context.Product.Add(newProduct);
            db_context.SaveChanges();
            return Ok(true);
        }

        public IHttpActionResult DeleteProduct(int id)
        {
            Product prd = db_context.Product.Find(id);
            db_context.Product.Remove(prd);
            db_context.SaveChanges();
            return Ok(true);
        }

        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            db_context.Entry(product).State = System.Data.Entity.EntityState.Modified;
            db_context.SaveChanges();
            return Ok(true);
        }


    }
}
