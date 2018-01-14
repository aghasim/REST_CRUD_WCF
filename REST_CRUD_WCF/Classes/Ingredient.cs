using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REST_CRUD_WCF.Classes
{
    public class Ingredient
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public double product_price { get; set; }
        public List<Ingredient_Image> images { get; set; }
    }
}