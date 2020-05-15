using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMInterface.Models
{
    public class OrderView
    {
        public int OrderId { get; set; }
        public Nullable<int> customerId { get; set; }
        public Nullable<int> staffId { get; set; }
        public Nullable<System.DateTime> orderDate { get; set; }
        
        public virtual Staff Staff { get; set; }
    }
}