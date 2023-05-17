using System.Collections.Generic;

namespace Proiect_frigider
{
    public class RecipeInformationDTO
    {
        public string title { get; set; }
        public string image { get; set; }
        public int servings { get; set; }
        public int readyInMinutes { get; set; }
       // public List<Instruction> AnalyzedInstructions { get; set; }
        public string instructions { get; set; }
        public List<string> ingredientsList { get; set; }

        public RecipeInformationDTO( string title, string image, int servings, int readyInMinutes, string instructions, List<string> ingredientsList)
        {
            this.title = title;
            this.image = image;
            this.servings = servings;
            this.readyInMinutes = readyInMinutes;
            this.instructions = instructions;
            this.ingredientsList = ingredientsList;
        }
    }
}