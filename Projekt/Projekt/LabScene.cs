using Projekt.Potions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Projekt.Potions.Storage;
using static System.Console;

namespace Projekt
{
    internal class LabScene : Scene
    {
        public LabScene(Game game) : base(game)
        {
        }
      
        public static List<Recipe> BrewedPotions = new List<Recipe>();
        public static bool CheckIngredientAvailability(string potionName)
        {

            IngredientType[] requiredIngredients = GetRequiredIngredientsForPotion(potionName);

            //if (requiredIngredients == null || requiredIngredients.Length == 0)
            //{
            //    Console.WriteLine($"Elixir '{potionName}' does not exist or has no required ingredients.");
            //    return false;
            //}
            List<IngredientType> missingIngredients = new List<IngredientType>();



            foreach (IngredientType ingredient in requiredIngredients)
            {
                if (!storage.ContainsKey(ingredient) || storage[ingredient] <= 0)
                {
                    //Console.WriteLine($"Ingredient '{ingredient}' is not available for elixir '{potionName}'.");
                    missingIngredients.Add(ingredient);
                    //return false;
                }

            }
            if (missingIngredients.Count > 0)
            {
                Console.WriteLine("Missing ingredients:");
                foreach (var missingIngredient in missingIngredients)
                {
                    Console.WriteLine($"- {missingIngredient}");
                    
                }
                return false;
            }


            return true;
        }
        public static IngredientType[] GetRequiredIngredientsForPotion(string potionName)
        {
            switch (potionName)
            {
                case "Potion of health":
                    return new IngredientType[] { IngredientType.root_of_mandrake, IngredientType.arctic_moss, IngredientType.black_pearl };
                case "Potion of love":
                    return new IngredientType[] { IngredientType.dragon_scale, IngredientType.wing_of_bat, IngredientType.golden_seed };
                case "Potion of sleep":
                    return new IngredientType[] { IngredientType.golden_seed, IngredientType.arctic_moss, IngredientType.unicorn_horn };
                case "Potion of strength":
                    return new IngredientType[] { IngredientType.white_mushroom, IngredientType.fang_of_snake, IngredientType.wing_of_bat };
                default:
                    return null;
            }
        }

        private void brewPotionNumber(int index)
        {
            if (MyGame.Potions.Count >= index)
            {
                var potion = MyGame.Potions[index - 1];

                if (CheckIngredientAvailability(potion.Name))
                {
                    //int exc = potion.Excellence;

                    potion.Brew(potion.Name, potion.Excellence);

                    MyGame.Potions.Remove(potion);
                    BrewedPotions.Add(potion);
                    
                    ConsoleShortcuts.WaitForKeyPress();
                    MyGame.MyLabScene.Run();
                }
                else
                {
                    Console.WriteLine("You don't have enough ingredients to brew this potion");
                    ConsoleShortcuts.WaitForKeyPress();
                    MyGame.MyLabScene.Run();
                }
            }
            else
            {
                WriteLine("You don't have any orders - to start brewing go take one");
                ConsoleShortcuts.WaitForKeyPress();
                MyGame.MyLabScene.Run();
            }
        }

        public override void Run()
        {
            string prompt = "Lab - here you can brew your potions";
            string[] options = { "Show current orders", "brew order 1 ", "brew order 2", "brew order 3", "go back" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("Potions:");
                    for (int i = 0; i < MyGame.Potions.Count; i++)
                    {
                        var potion1 = MyGame.Potions[i];
                        Console.WriteLine($"{i + 1}. Potion's name: {potion1.Name}, Glass type: {potion1.NameOfGlass}, Capacity type: {potion1.NameOfCapacity}, Excellence: {potion1.Excellence}");
                    }
                    ConsoleShortcuts.WaitForKeyPress();
                    MyGame.MyLabScene.Run();
                    break;

                case 1:
                    brewPotionNumber(1);
                    break;
                case 2:
                    brewPotionNumber(2);
                    break;
                case 3:
                    brewPotionNumber(3);
                    break;
                case 4:

                    MyGame.MyNavigationScene.Run();
                    break;



            }


        }
    }
}
