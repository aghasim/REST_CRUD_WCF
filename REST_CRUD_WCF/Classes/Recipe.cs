using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_CRUD_WCF.Classes
{
    public class Recipe
    {
        public int dish_id { get; set; }
        public string dish_name { get; set; }
        public double price { get; set; }
        public List<Recipe_Image> images { get; set; } 
    }
}