using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMAPI.Models
{
    public class StaffDetail
    {
        public int staffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string Gender { get; set; }
    }
}