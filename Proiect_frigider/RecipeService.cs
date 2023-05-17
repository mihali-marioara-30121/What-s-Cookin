﻿using RestSharp;
using System;
using System.Collections.Generic;

namespace Proiect_frigider
{
    internal class RecipeService
    {
            public static List<Recipe> findRecipesByIngredients(string ingredients, int number)
            {
            var client = new RestClient("https://api.spoonacular.com");
            // We create a new instance of the RestSharp RestRequest class, passing in the Spoonacular API endpoint path "recipes/findByIngredients" as a parameter
            var request = new RestRequest("recipes/findByIngredients");

            // We add the parameters for the search to the request object
            request.AddParameter("ingredients", ingredients); // ingredients to search for
            request.AddParameter("number", number); // number of results to return
            request.AddParameter("limitLicense", true); // whether the recipes should have an open license that allows display with proper attribution
            request.AddParameter("ranking", 1); // whether to maximize used ingredients (1) or minimize missing ingredients (2) first
            request.AddParameter("ignorePantry", true); // whether to ignore typical pantry items, such as water, salt, flour, etc.
            request.AddParameter("apiKey", "38d526420ec34b768787a8fd96de98f4"); // Spoonacular API key

            // We execute the request using the RestClient's Execute method, passing in the RestResponse class as a generic type parameter
            RestResponse<List<Recipe>> response = client.Execute<List<Recipe>>(request);

            // The method returns the data from the response, which is a list of Recipes
            return response.Data;
        }

        public static List<RecipeDTO> extractNecessaryInformationFromCompleteRecipes(List<Recipe> completeRecipes)
        {
            List<RecipeDTO> recipeDTOs = new List<RecipeDTO>();    

            foreach (Recipe recipe in completeRecipes)
            {
                string title = recipe.title;
                string description = generateDescription(recipe);
                string unusedIngredients = extractUnusedIngredients(recipe);
                string missedIngredients = extractMissedIngredients(recipe);
                string image = recipe.image;

                RecipeDTO recipeDTO = new RecipeDTO(title, description, image, unusedIngredients, missedIngredients);
                recipeDTOs.Add(recipeDTO);
            }

            return recipeDTOs;
        }

        private static string extractMissedIngredients(Recipe recipe)
        {
            string missedIngredients = "";

            foreach (Ingredient missedIngredient in recipe.missedIngredients)
            {
                missedIngredients += missedIngredient.name + ",";
            }

            if (missedIngredients.Length > 0)
            {
                return missedIngredients.Substring(0, missedIngredients.Length - 1);
            }
            return "";  
        }

        private static string extractUnusedIngredients(Recipe recipe)
        {

            string missedIngredients = "";

            foreach (Ingredient missedIngredient in recipe.unusedIngredients)
            {
                missedIngredients += missedIngredient.name + ",";
            }

            if (missedIngredients.Length > 0)
            {
                return missedIngredients.Substring(0, missedIngredients.Length - 1);
            }
            return "";
        }

        private static string generateDescription(Recipe recipe)
        {
            String description = "";

            foreach(Ingredient ingredient in recipe.usedIngredients)
            {
                description += " - " +ingredient.original + "\n";
            }

            return description;
        }
    }
}