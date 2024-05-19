using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Projekt.Potions.Recipe;
using static Projekt.Potions.Storage;
using System.Xml.Linq;

namespace Projekt.Potions
{
    internal class StrengthPotion : Recipe
    {
        public StrengthPotion(PotionGlassType _typeofglass, PotionCapacityType _typeofcapacity, int _excellence)
        {
            Excellence = _excellence;
            Name = "Potion of strength";
            Price = 15 * Excellence;
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

        IngredientType[] requiredIngredients = { IngredientType.white_mushroom, IngredientType.fang_of_snake, IngredientType.wing_of_bat};
        override public void prepare(ref Dictionary<IngredientType, int> storage)
        {
            foreach (IngredientType ingredient in requiredIngredients)
            {
                storage[ingredient] -= 1;
            }
        }
    }
}
