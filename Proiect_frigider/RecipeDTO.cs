
namespace Proiect_frigider
{
    public class RecipeDTO
    {
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string unusedIngredients { get; set; }
        public string missedIngredients { get; set; }

        public RecipeDTO(string title, string description, string image, string unusedIngredients, string missedIngredients)
        {
            this.title = title;
            this.description = description;
            this.image = image;
            this.unusedIngredients = unusedIngredients;
            this.missedIngredients = missedIngredients;
        }
    }


}
