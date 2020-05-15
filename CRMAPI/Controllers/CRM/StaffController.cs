using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRMAPI.Models;

namespace CRMAPI.Controllers.CRM
{
    public class StaffController : ApiController
    {
        private CRMEntities db_context = new CRMEntities();

        [HttpGet]
        public IHttpActionResult GetStaffs()
        {
            db_context.Configuration.ProxyCreationEnabled = false;
            var result1 = db_context.Staff
                .ToList();
            return Ok(result1);
        }

        [HttpGet]
        public IHttpActionResult GetStaff(int id)
        {
            db_context.Configuration.ProxyCreationEnabled = false;
            var result = db_context.Staff.Find(id);
            return Ok(result);
        }

        public IHttpActionResult PostStaff(Staff newStaff)
        {
            db_context.Staff.Add(newStaff);
            db_context.SaveChanges();
            return Ok(true);
        }

        public IHttpActionResult DeleteStaff(int id)
        {
            Staff stf = db_context.Staff.Find(id);
            db_context.Staff.Remove(stf);
            db_context.SaveChanges();
            return Ok(true);
        }

        public IHttpActionResult PutStaff(int id, Staff staff)
        {
            if (id != staff.sid)
            {
                return BadRequest();
            }
            db_context.Entry(staff).State = System.Data.Entity.EntityState.Modified;
            db_context.SaveChanges();
            return Ok(true);
        }

    }
}
