using RestSharp;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace Proiect_frigider
{
    //Mari's key:38d526420ec34b768787a8fd96de98f4
    //Diana's key: 808494c3cf674464a6d0269234e271e4
    internal class RecipeInformationService
    {
        public static RecipeInformation GetRecipeInformation(int recipeId)
        {
            var client = new RestClient("https://api.spoonacular.com");
            var request = new RestRequest($"recipes/{recipeId}/information");

            // Add the required API key as a query parameter
            request.AddParameter("id", recipeId); // ingredients to search for
            request.AddParameter("includeNutrition", false);
            request.AddParameter("apiKey", "808494c3cf674464a6d0269234e271e4");

            // Execute the request and retrieve the response
            RestResponse<RecipeInformation> response = client.Execute<RecipeInformation>(request);

            // Return the data from the response, which is an instance of RecipeInformation
            return response.Data;
        }

        public static RecipeInformationDTO extractNecessaryInformationFromCompleteRecipes(RecipeInformation recipeInformation)
        {       int id = recipeInformation.Id;
                string title = recipeInformation.Title;
                string image = recipeInformation.Image;
                int servings = recipeInformation.Servings;
                int readyInMinutes = recipeInformation.ReadyInMinutes;
                string instructions = recipeInformation.Instructions;
            List<string> ingredientsList = getIngredientsFromRecipeInformation(recipeInformation);


            string cleanedDescription;
            string extractedContent;

            // Remove the <ol> and </ol> tags
            if (instructions.Contains("<li>") && instructions.Contains("</li>"))
            {
              cleanedDescription = Regex.Replace(instructions, @"<[/]?ol>", "");

                // Extract the content from the list items using regex
                MatchCollection matches = Regex.Matches(cleanedDescription, @"<li>(.*?)</li>");

                StringBuilder sb = new StringBuilder();
                foreach (Match match in matches)
                {
                    string listItemContent = match.Groups[1].Value;
                    sb.AppendLine(listItemContent.Trim());
                }

                 extractedContent = sb.ToString();
            }
            else
            {
                extractedContent = instructions;
            }


            RecipeInformationDTO recipeInformationDTO = new RecipeInformationDTO( id, title, image, servings, readyInMinutes, extractedContent, ingredientsList);

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
