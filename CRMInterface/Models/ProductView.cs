using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMInterface.Models
{
    public class ProductView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Details { get; set; }
    }
}