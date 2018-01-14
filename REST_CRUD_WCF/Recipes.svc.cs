using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using REST_CRUD_WCF.Model;
using REST_CRUD_WCF.Classes;

namespace REST_CRUD_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Recipes" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Recipes.svc or Recipes.svc.cs at the Solution Explorer and start debugging.
    public class Recipes : IRecipes
    {

        // recipes
        public bool CreateRecipe(Recipe r)
        {
            int n_id = Convert.ToInt32(r.dish_id);
            using (coffee_room_Entities db = new coffee_room_Entities())
            {
                try
                {
                    dish d = new dish();
                    d.dish_name = r.dish_name;
                    d.price = r.price;
                    db.dishes.Add(d);

                    for (int i = 0; i < r.images.Count; i++)
                    {
                        dish_images img = new dish_images();
                        img.dish_id = n_id;
                        img.image = r.images[i].image;
                        db.dish_images.Add(img);
                    }
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }



        public bool DeleteRecipe(Recipe r)
        {
            int n_id = Convert.ToInt32(r.dish_id);
            using (coffee_room_Entities db = new coffee_room_Entities())
            {
                try
                {
                    var db_dish = db.dishes.Where(x => x.dish_id == n_id).First();
                    db.dishes.Remove(db_dish);
                    var db_dish_images = db.dish_images.Where(x => x.dish_id == n_id);
                    db.dish_images.RemoveRange(db_dish_images);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }



        public bool EditRecipe(Recipe r)
        {
            int n_id = Convert.ToInt32(r.dish_id);
            using (coffee_room_Entities db = new coffee_room_Entities())
            {
                try
                {
                    var db_dish = db.dishes.Where(x => x.dish_id == n_id).First();
                    db_dish.dish_name = r.dish_name;
                    db_dish.price = r.price;
                    for (int i = 0; i < r.images.Count; i++)
                    {
                        var db_dish_img = db.dish_images.Where(x => x.id == r.images[i].id).First();
                        db_dish_img.dish_id = n_id;
                        db_dish_img.image = r.images[i].image;
                    }
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public Recipe FindRecipe(string id)
        {
            int n_id = Convert.ToInt32(id);
            using (coffee_room_Entities db = new coffee_room_Entities())
            {
                Recipe r = new Recipe();
                var tmp = db.dishes.Where(x => x.dish_id == n_id).First();
                r.dish_id = tmp.dish_id;
                r.dish_name = tmp.dish_name;
                r.price = (double)tmp.price;
                r.images = new List<Recipe_Image>();
                foreach (var item in db.dish_images)
                {
                    if (item.dish_id == n_id)
                    {
                        Recipe_Image img = new Recipe_Image();
                        img.id = item.id;
                        img.image = item.image;
                        r.images.Add(img);
                    }
                }
                return r;
            }
        }



        public List<Recipe> GetAllRecipes()
        {
            using (coffee_room_Entities db = new coffee_room_Entities())
            {
                List<Recipe> r = new List<Recipe>();
                foreach (var item in db.dishes)
                {
                    Recipe tmp = new Recipe();
                    tmp.dish_id = item.dish_id;
                    tmp.dish_name = item.dish_name;
                    tmp.price = (double)item.price;
                    tmp.images = new List<Recipe_Image>();
                    foreach (var i in db.dish_images)
                    {
                        Recipe_Image img = new Recipe_Image();
                        img.id = i.id;
                        img.image = i.image;
                        tmp.images.Add(img);
                    }
                    r.Add(tmp);
                }
                return r;
            }
        }

        //ingredient
        public bool EditIngredient(Ingredient ing)
        {
            int n_id = Convert.ToInt32(ing.product_id);
            using (coffee_room_Entities db = new coffee_room_Entities())
            {
                try
                {
                    var db_ing = db.ingredients.Where(x => x.product_id == n_id).First();
                    db_ing.product_name = ing.product_name;
                    db_ing.product_price = ing.product_price;
                    for (int i = 0; i < ing.images.Count; i++)
                    {
                        var db_img = db.ingredient_images.Where(x => x.id == ing.images[i].id).First();
                        db_img.ingredient_id = n_id;
                        db_img.image = ing.images[i].image;
                    }
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public bool DeleteIngredient(Ingredient ing)
        {
            int n_id = Convert.ToInt32(ing.product_id);
            using (coffee_room_Entities db = new coffee_room_Entities())
            {
                try
                {
                    var db_ing = db.ingredients.Where(x => x.product_id == n_id).First();
                    db.ingredients.Remove(db_ing);
                    var db_img = db.ingredient_images.Where(x => x.ingredient_id == n_id).ToList();
                    db.ingredient_images.RemoveRange(db_img);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public bool CreateIngredient(Ingredient ing)
        {
            int n_id = Convert.ToInt32(ing.product_id);
            using (coffee_room_Entities db = new coffee_room_Entities())
            {
                try
                {
                    ingredient ingredient = new ingredient();
                    ingredient.product_name = ing.product_name;
                    ingredient.product_price = ing.product_price;
                    db.ingredients.Add(ingredient);
                    for (int i = 0; i < ing.images.Count; i++)
                    {
                        ingredient_images img = new ingredient_images();
                        img.ingredient_id = n_id;
                        img.image = ing.images[i].image;
                        db.ingredient_images.Add(img);
                    }
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public Ingredient FindIngredient(string id)
        {
            int n_id = Convert.ToInt32(id);
            using (coffee_room_Entities db = new coffee_room_Entities())
            {
                Ingredient ingredient = new Ingredient();
                ingredient.images = new List<Ingredient_Image>();
                var tmp = db.ingredients.Where(x => x.product_id == n_id).First();
                ingredient.product_id = tmp.product_id;
                ingredient.product_name = tmp.product_name;
                ingredient.product_price = (double)tmp.product_price;

                foreach (var i in db.ingredient_images)
                {
                    if (i.ingredient_id == n_id)
                    {
                        Ingredient_Image img = new Ingredient_Image();
                        img.id = i.id;
                        img.image = i.image;
                        ingredient.images.Add(img);
                    }
                }
                return ingredient;
            }
        }
        public List<Ingredient> GetAllIngredients()
        {
            using (coffee_room_Entities db = new coffee_room_Entities())
            {
                var ingredients = (from x in db.ingredients
                          select new Ingredient
                          {
                              product_id = x.product_id,
                              product_name = x.product_name,
                              product_price = (double)x.product_price,
                              images = (from y in db.ingredient_images
                                        where y.ingredient_id == x.product_id
                                        select new Ingredient_Image { id = y.id, image = y.image }).ToList(),
                          }).ToList();
                return ingredients;
            }
        }

    }
}
