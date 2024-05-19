using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Projekt.Potions.Recipe;

namespace Projekt
{
    internal class SleepPotionFactory : RecipeFactory
    {
        override public Potions.Recipe Create(PotionGlassType _typeofglass, PotionCapacityType _typeofcapacity, int _excellence)
        {

            return new Potions.SleepPotion(_typeofglass, _typeofcapacity, _excellence);

        }
    }
}
