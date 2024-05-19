using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Projekt.Potions.Storage;

namespace Projekt.Potions
{
    internal class SleepPotion : Recipe
    {
        public SleepPotion(PotionGlassType _typeofglass, PotionCapacityType _typeofcapacity, int _excellence)
        {
            Excellence = _excellence;
            Name = "Potion of sleep";
            Price = 20 * Excellence;
            NameOfGlass = _typeofglass;
            NameOfCapacity = _typeofcapacity;

            if (potionGlassNames.TryGetValue(NameOfGlass, out int glassPrice))
            {
                Price += glassPrice;
            }
            if (potionCapacityNames.TryGetValue(NameOfCapacity, out int capacityPrice))
            {
                Price += capacityPrice;
            }


        }

        public override string getInfo()
        {
            return $"Type: {Name}, Price: {Price}, Excellence: {Excellence}, Glass: {NameOfGlass}, Capacity: {NameOfCapacity}";
        }

        IngredientType[] requiredIngredients = { IngredientType.golden_seed, IngredientType.arctic_moss, IngredientType.unicorn_horn };
        override public void prepare(ref Dictionary<IngredientType, int> storage)
        {
            foreach (IngredientType ingredient in requiredIngredients)
            {
                storage[ingredient] -= 1;
            }
        }

    }
}
