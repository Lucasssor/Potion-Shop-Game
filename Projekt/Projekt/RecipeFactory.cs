using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Projekt.Potions.Recipe;

namespace Projekt
{
    internal abstract class RecipeFactory
    {
        public static RecipeFactory CreateFactory(string recipeName)
        {
            switch (recipeName)
            {
                case "HealthPotion":
                    return new HealthPotionFactory();
                case "LovePotion":
                    return new LovePotionFactory();
                case "SleepPotion":
                    return new SleepPotionFactory();
                case "StrengthPotion":
                    return new StrengthPotionFactory();
                default:
                    throw new ArgumentException("Invalid recipe name");
            }
        }

        public abstract Potions.Recipe Create(PotionGlassType _nameofglass, PotionCapacityType _nameofcapacity, int _excellence);
        //public abstract Potions.Recipe Create(GlassTypeFactory _nameofglass, string _nameofcapacity, int _excellence);

    }
}
