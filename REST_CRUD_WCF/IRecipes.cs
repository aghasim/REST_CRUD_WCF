using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using REST_CRUD_WCF.Classes;

namespace REST_CRUD_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRecipes" in both code and config file together.
    [ServiceContract]
    public interface IRecipes
    {
        // dish or dish images
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetAllRecipes", ResponseFormat = WebMessageFormat.Json)]
        List<Recipe> GetAllRecipes();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "FindRecipe/{id}", ResponseFormat = WebMessageFormat.Json)]
        Recipe FindRecipe( string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "CreateRecipe", ResponseFormat = WebMessageFormat.Json, RequestFormat =WebMessageFormat.Json)]
        bool CreateRecipe(Recipe resipe);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "EditRecipe", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool EditRecipe(Recipe resipe);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "DeleteRecipe", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool DeleteRecipe(Recipe resipe);

        //ingredient or ingredient images
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetAllIngredients", ResponseFormat = WebMessageFormat.Json)]
        List<Ingredient> GetAllIngredients();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "FindIngredient/{id}", ResponseFormat = WebMessageFormat.Json)]
        Ingredient FindIngredient(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "CreateIngredient", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool CreateIngredient(Ingredient ing);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "EditIngredient", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool EditIngredient(Ingredient ing);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "DeleteIngredient", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool DeleteIngredient(Ingredient ing);
    }
}
