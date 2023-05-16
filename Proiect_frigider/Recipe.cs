using System.Collections.Generic;

namespace Proiect_frigider
{
    public class Recipe
    {
        public int id { get; set; }
        public string image { get; set; }
        public string imageType { get; set; }
        public int likes { get; set; }
        public int missedIngredientCount { get; set; }
        public List<Ingredient> missedIngredients { get; set; }
        public string title { get; set; }
        public List<Ingredient> unusedIngredients { get; set; }
        public int usedIngredientCount { get; set; }
        public List<Ingredient> usedIngredients { get; set; }

        public override string ToString()
        {
            return $"id: {id}\n" +
                   $"title: {title}\n" +
                   $"image: {image}\n" +
                   $"imageType: {imageType}\n" +
                   $"likes: {likes}\n" +
                   $"missedIngredientCount: {missedIngredientCount}\n" +
                   $"usedIngredientCount: {usedIngredientCount}";
        }
    }
}
