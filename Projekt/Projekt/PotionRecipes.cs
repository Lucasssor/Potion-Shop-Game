using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Projekt.Potions.Storage;

namespace Projekt
{
    internal class PotionRecipes
    {
        private Dictionary<string, IngredientType[]> potionDictionary;

        public PotionRecipes()
        {
            InitializeRecipes();
        }

        private void InitializeRecipes()
        {
            potionDictionary = new Dictionary<string, IngredientType[]>
        {
            { "Potion of health", new IngredientType[] { IngredientType.root_of_mandrake, IngredientType.arctic_moss, IngredientType.black_pearl } },
            { "Potion of love", new IngredientType[] { IngredientType.dragon_scale, IngredientType.wing_of_bat, IngredientType.golden_seed } },
            { "Potion of sleep", new IngredientType[] { IngredientType.golden_seed, IngredientType.arctic_moss, IngredientType.unicorn_horn } },
            { "Potion of strength", new IngredientType[] { IngredientType.white_mushroom, IngredientType.fang_of_snake, IngredientType.wing_of_bat } }
        };
        }

        public void PrintRecipe(string potionName)
        {
            if (potionDictionary.ContainsKey(potionName))
            {
                Console.WriteLine($"Recipe for {potionName}:");
                foreach (var ingredient in potionDictionary[potionName])
                {
                    Console.WriteLine($"- {ingredient}");
                }
            }
            else
            {
                Console.WriteLine($"Recipe for {potionName} not found.");
            }
        }
    }
}
