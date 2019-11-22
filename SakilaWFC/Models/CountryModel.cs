using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SakilaWFC.Models
{
    public class CountryModel
    {
        public int country_id { get; set; }
        public string country { get; set; }
        public DateTime? last_update { get; set; }

    }
}