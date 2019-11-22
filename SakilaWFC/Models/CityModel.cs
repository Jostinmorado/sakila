using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SakilaWFC.Models
{
    public class CityModel
    {
        public int cityId { get; set; }
        public string city { get; set; }
        public int countryId { get; set; }
        public DateTime? last_update { get; set; }
    }
}