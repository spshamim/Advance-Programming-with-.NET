using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductMgmtSys.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string UserType { get; set; } // to find user type later using LINQ and to map
        public decimal TotalAmount { get; set; }
        public System.DateTime OrderDate { get; set; }
        public Nullable<int> UserId { get; set; }
    }
}