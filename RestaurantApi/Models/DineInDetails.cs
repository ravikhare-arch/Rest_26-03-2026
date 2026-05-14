using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantApi.Models
{
    public class DineInDetails
    {
        public int DineInTablemasterID { get; set; }
        public int OrderID { get; set; }
        public string TableName { get; set; }
        public string TableStatus { get; set; }
        public string Room_Number { get; set; }
    }
}