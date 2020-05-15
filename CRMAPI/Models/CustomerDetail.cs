using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMAPI.Models
{
    public class CustomerDetail
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public Nullable<int> Gender { get; set; }
    }
}