using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Projekt.Potions.Recipe;

namespace Projekt
{
    internal class LovePotionFactory : RecipeFactory
    {
        override public Potions.Recipe Create(PotionGlassType _typeofglass, PotionCapacityType _typeofcapacity, int _excellence)
        {

            // Create and return a new Potion object
            return new Potions.LovePotion(_typeofglass, _typeofcapacity, _excellence);

        }
    }
}
