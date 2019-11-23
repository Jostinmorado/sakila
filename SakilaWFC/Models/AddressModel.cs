using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SakilaWFC.Models
{
    public class AddressModel
    {
        public int address_id { get; set; }
        public string desc_address { get; set; }
        public string desc_address2 { get; set; }
        public string district { get; set; }
        public int city_id { get; set; }
        public string postal_code { get; set; }
        public string phone { get; set; }
        public DateTime? last_update { get; set; }
    }
}