using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Projekt.Potions.Storage;

namespace Projekt.Potions
{
    internal abstract class Recipe
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Excellence { get; set; }
        public PotionGlassType NameOfGlass { get; set; }

        public PotionCapacityType NameOfCapacity { get; set; }
        public enum PotionGlassType
        {
            Sferic,
            Triangle,
            Cylinder,
        }
        protected static Dictionary<PotionGlassType, int> potionGlassNames = new Dictionary<PotionGlassType, int>
        {
            { PotionGlassType.Sferic, 20 },
            { PotionGlassType.Triangle, 15 },
            { PotionGlassType.Cylinder, 18 },         
        };

        public enum PotionCapacityType
        {
            Mini,
            Small,
            Medium,
            Big,
        }

        protected static Dictionary<PotionCapacityType, int> potionCapacityNames = new Dictionary<PotionCapacityType, int>
        {
            { PotionCapacityType.Mini, 5 },
            { PotionCapacityType.Small, 10 },
            { PotionCapacityType.Medium, 15 },
            { PotionCapacityType.Big, 20 },
        };
        
        public virtual string getInfo()
        {
            return $"Type: {Name}, Price: {Price}";
        }

        static void ShowDots(int numberofsec)
        {

            for (int i = 0; i < numberofsec; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000); 
            }
            Console.WriteLine();
        }

        public void Brew(string potionName, int excellence)
        {
            IngredientType[] requiredIngredients = LabScene.GetRequiredIngredientsForPotion(potionName);
           
           
            foreach (IngredientType ingredient in requiredIngredients)
            {
                if (storage.TryGetValue(ingredient, out int ingredientCount) && ingredientCount > excellence - 1)
                {
                    storage[ingredient] -= excellence;
                }
                else
                {
                    Console.WriteLine($"Ingredient '{ingredient}' is not available in sufficient quantity.");
                    return;
                }
            }
            Console.WriteLine($"Brewing {potionName}...");
            ShowDots(5);
            Console.WriteLine($"You brewed {potionName}");
        }
        abstract public void prepare(ref Dictionary<IngredientType, int> storage);
    }
}
