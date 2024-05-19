using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Potions
{
    internal class Storage
    {

        private List<ClientScene> potions = new List<ClientScene>();

        public enum IngredientType
        {
            root_of_mandrake,
            unicorn_horn,
            dragon_scale,           
            wing_of_bat,
            arctic_moss,
            fang_of_snake,
            golden_seed,
            black_pearl,
            white_mushroom,
        }

        static public Dictionary<IngredientType, int> storage = new Dictionary<IngredientType, int>()
        {
            {IngredientType.root_of_mandrake,  4},    
            {IngredientType.unicorn_horn, 4 },
            {IngredientType.dragon_scale, 4 },
            {IngredientType.wing_of_bat, 4 },
            {IngredientType.arctic_moss, 4 },
            {IngredientType.fang_of_snake, 4 },
            {IngredientType.golden_seed, 4 },
            {IngredientType.black_pearl, 4 },
            {IngredientType.white_mushroom, 4 },
      
        };
        public static void PrintStorageContents(Dictionary<Storage.IngredientType, int> storage)
        {
            foreach (var item in storage)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }   
    }
}
