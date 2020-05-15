using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRMAPI.Models;

namespace CRMAPI.Controllers.CRM
{
    public class InvoiceController : ApiController
    {
        private CRMEntities db_context = new CRMEntities();

        //public IHttpActionResult GetInvoice()
        //{
        //    var result = db_context.Invoice.ToList();
        //    return Ok(result);
        //}

        //public IHttpActionResult GetCustomerInvoice(int cid)
        //{
        //    var result = db_context.Invoice.Where(x => x.CustomerId == cid).ToList();
        //    return Ok(result);
        //}

        //public IHttpActionResult GetInvoiceDate(DateTime date)
        //{
        //    var result = db_context.Invoice.Where(x => x.PaymentDate == date).ToList();
        //    return Ok(result);
        //}

        //public IHttpActionResult GetInvoiceStatus(int status)
        //{
        //    var result = db_context.Invoice.Where(x => x.Status == status).ToList();
        //    return Ok(result);
        //}
        
    }
}
