using System.Collections.Generic;

namespace Proiect_frigider
{
    public class RecipeInformation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string ImageType { get; set; }
        public int Servings { get; set; }
        public int ReadyInMinutes { get; set; }
        public string License { get; set; }
        public string SourceName { get; set; }
        public string SourceUrl { get; set; }
        public string SpoonacularSourceUrl { get; set; }
        public int AggregateLikes { get; set; }
        public double HealthScore { get; set; }
        public double SpoonacularScore { get; set; }
        public double PricePerServing { get; set; }
        public List<Instruction> AnalyzedInstructions { get; set; }
        public bool Cheap { get; set; }
        public string CreditsText { get; set; }
        public List<string> Cuisines { get; set; }
        public bool DairyFree { get; set; }
        public List<string> Diets { get; set; }
        public string Gaps { get; set; }
        public bool GlutenFree { get; set; }
        public string Instructions { get; set; }
        public bool Ketogenic { get; set; }
        public bool LowFodmap { get; set; }
        public List<string> Occasions { get; set; }
        public bool Sustainable { get; set; }
        public bool Vegan { get; set; }
        public bool Vegetarian { get; set; }
        public bool VeryHealthy { get; set; }
        public bool VeryPopular { get; set; }
        public bool Whole30 { get; set; }
        public int WeightWatcherSmartPoints { get; set; }
        public List<string> DishTypes { get; set; }
        public List<ExtendedIngredient> ExtendedIngredients { get; set; }
        public string Summary { get; set; }
        public WinePairing WinePairing { get; set; }
    }

        public class Instruction
        {
            public string Step { get; set; }
        }

        public class ExtendedIngredient
        {
            public string Aisle { get; set; }
            public double Amount { get; set; }
            public string Consistency { get; set; }
            public int Id { get; set; }
            public string Image { get; set; }
            public Measure Measures { get; set; }
            public List<string> Meta { get; set; }
            public string Name { get; set; }
            public string Original { get; set; }
            public string OriginalName { get; set; }
            public string Unit { get; set; }
        }

        public class Measure
        {
            public Metric Metric { get; set; }
            public US Customary { get; set; }
        }

        public class Metric
        {
            public double Amount { get; set; }
            public string UnitLong { get; set; }
            public string UnitShort { get; set; }
        }

        public class US
        {
            public double Amount { get; set; }
            public string UnitLong { get; set; }
            public string UnitShort { get; set; }
        }

        public class WinePairing
        {
            public List<string> PairedWines { get; set; }
            public string PairingText { get; set; }
            public List<ProductMatch> ProductMatches { get; set; }

        }
        public class ProductMatch
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Price { get; set; }
            public string Image { get; set; }
            public string Url { get; set; }
            public double AverageRating { get; set; }
            public int RatingCount { get; set; }
            public string Score { get; set; }
        }
}