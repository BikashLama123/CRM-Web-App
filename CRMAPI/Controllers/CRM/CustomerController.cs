using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CRMAPI.Models;

namespace CRMAPI.Controllers.CRM
{
    public class CustomerController : ApiController
    {
        private CRMEntities db_context = new CRMEntities();

        public IHttpActionResult GetCustomer()
        {
            db_context.Configuration.ProxyCreationEnabled = false;
            var result = db_context.Customers.ToList();
            return Ok(result);
        }
        
        public IHttpActionResult GetCustomer(int id)
        {
            db_context.Configuration.ProxyCreationEnabled = false;
            var result = db_context.Customers.Find(id);
            return Ok(result);
        }

        public IHttpActionResult PostCustomer(Customers newCustomer)
        {
            db_context.Customers.Add(newCustomer);
            db_context.SaveChanges();
            return Ok(true);
        }

        public IHttpActionResult DeleteCustomer(int id)
        {
            Customers cus = db_context.Customers.Find(id);
            db_context.Customers.Remove(cus);
            db_context.SaveChanges();
            return Ok(true);
        }

        public IHttpActionResult PutCustomer(int id,Customers customer)
        {
            if(id !=customer.Id)
            {
                return BadRequest();
            }
            db_context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            db_context.SaveChanges();
            return Ok(true);
        }
    }
}
