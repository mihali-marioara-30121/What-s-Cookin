using System.Collections.Generic;

namespace Proiect_frigider
{
    public class RecipeDTO
    {   
        public int id { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public string unusedIngredients { get; set; }
        public string missedIngredients { get; set; }

        public RecipeDTO(int id, string title, string image,  string unusedIngredients, string missedIngredients)
        {   
            this.id = id;
            this.title = title;
            this.image = image;
            this.unusedIngredients = unusedIngredients;
            this.missedIngredients = missedIngredients;
        }
    }
}
