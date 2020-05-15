using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CRMAPI.Models;

namespace CRMAPI.Controllers.CRM
{
    public class UserController : ApiController
    {
        private CRMEntities db_context = new CRMEntities();

        [HttpGet]
        public IHttpActionResult CheckUser(string username, string password)
        {
            var uname = db_context.User.Where(x => x.userName == username).FirstOrDefault();
            var result = "";
            if(uname != null)
            {
                if(uname.userPassword ==password)
                {
                    return Ok(true);
                }
                else
                {
                    result = "Password Didn't Match";
                    return Ok(result);
                }
            }
            else
            {
                result = "User Not Found";
                return Ok(result);
            }
            
        }
        
    }
}
