using Projekt.Potions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Projekt.Potions.Recipe;

namespace Projekt
{
    internal class HealthPotionFactory : RecipeFactory
    {
        override public Potions.Recipe Create(PotionGlassType _typeofglass, PotionCapacityType _typeofcapacity, int _excellence)
        {                        
                return new Potions.HealthPotion(_typeofglass, _typeofcapacity, _excellence);
            
        }
    }
}
            
        
    

        
    
