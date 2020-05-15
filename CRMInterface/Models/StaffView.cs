using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMInterface.Models
{
    public class StaffView
    {
        public int sid { get; set; }
        public string sfirstName { get; set; }
        public string slastName { get; set; }
        public string suserName { get; set; }
        public string sEmail { get; set; }
        public string sGender { get; set; }
        public string sPassword { get; set; }
        public string sDesignation { get; set; }
        public Nullable<System.DateTime> sDateofBirth { get; set; }
        public Nullable<bool> sIsVerified { get; set; }
    }
}