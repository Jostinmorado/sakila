using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SakilaWFC.Models
{
    public class CustomerModel
    {
        public int customer_id { get; set; }
        public int store_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public int address_id { get; set; }
        public string active { get; set; }
        public DateTime? create_date { get; set; }
        public DateTime? last_update { get; set; }
    }
}