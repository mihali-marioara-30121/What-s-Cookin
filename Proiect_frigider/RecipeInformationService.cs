using RestSharp;
using System.Collections.Generic;


namespace Proiect_frigider
{
    internal class RecipeInformationService
    {
        public static RecipeInformation GetRecipeInformation(int recipeId)
        {
            var client = new RestClient("https://api.spoonacular.com");
            var request = new RestRequest($"recipes/{recipeId}/information");

            // Add the required API key as a query parameter
            request.AddParameter("id", recipeId); // ingredients to search for
            request.AddParameter("includeNutrition", false);
            request.AddParameter("apiKey", "38d526420ec34b768787a8fd96de98f4");

            // Execute the request and retrieve the response
            RestResponse<RecipeInformation> response = client.Execute<RecipeInformation>(request);

            // Return the data from the response, which is an instance of RecipeInformation
            return response.Data;
        }

        public static RecipeInformationDTO extractNecessaryInformationFromCompleteRecipes(RecipeInformation recipeInformation)
        { 
                string title = recipeInformation.Title;
                string image = recipeInformation.Image;
                int servings = recipeInformation.Servings;
                int readyInMinutes = recipeInformation.ReadyInMinutes;
                string instructions = recipeInformation.Instructions;
            List<string> ingredientsList = getIngredientsFromRecipeInformation(recipeInformation);

            RecipeInformationDTO recipeInformationDTO = new RecipeInformationDTO( title, image, servings, readyInMinutes, instructions, ingredientsList);

            return recipeInformationDTO;
        }


       public static List<string> getIngredientsFromRecipeInformation(RecipeInformation recipeInformation)
       {

        List<string> ingredientsList = new List<string>();

            foreach(ExtendedIngredient ingredient in recipeInformation.ExtendedIngredients)
                {
                ingredientsList.Add(ingredient.Original);
                }
            return ingredientsList;
       }
}
}
