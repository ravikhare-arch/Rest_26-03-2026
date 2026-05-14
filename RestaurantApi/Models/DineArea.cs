using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApi.Models
{
    public class DineArea
    {
        public int DineAreaMasterID { get; set; }
        public string AreaName { get; set; }
        public int OrderTypeID { get; set; }
    }
}