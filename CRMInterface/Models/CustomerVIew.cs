using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMInterface.Models
{
    public class CustomerVIew
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public Nullable<int> Gender { get; set; }
        public Nullable<int> Staff { get; set; }
        public Nullable<System.DateTime> cdateofBirth { get; set; }
    }
}