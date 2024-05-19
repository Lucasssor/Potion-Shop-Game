using Projekt.Potions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
        
namespace Projekt
{
    internal class IngredientShopScene : Scene
    {
        public IngredientShopScene(Game game) : base(game)
        {
            
        }
        IngredientShop ingredientShop = new IngredientShop();
        


        private void resetAndBack()
        {
            ConsoleShortcuts.WaitForKeyPress();
            MyGame.MyIngredientShopScene.Run();
        }
        PotionRecipes potionRecipes = new PotionRecipes();
        
        private void showRecipes()
        {
            string prompt = "What potion's recipe do you want to know?";
            string[] options = { "healthpotion", "lovepotion", "sleeppotion", "strenghtpotion", "go back" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    potionRecipes.PrintRecipe("Potion of health");
                    resetAndBack();
                    break;
                case 1:
                    potionRecipes.PrintRecipe("Potion of love");
                    resetAndBack();
                    break; ;
                case 2:
                    potionRecipes.PrintRecipe("Potion of sleep");
                    resetAndBack();
                    break;
                case 3:
                    potionRecipes.PrintRecipe("Potion of strength");
                    resetAndBack();
                    break;
                case 4:
                    MyGame.MyIngredientShopScene.Run();
                    break;
            }
        }
        
        private bool isShopGenerated = false;
        public override void Run()
        {
            if (!isShopGenerated)
            {
                ingredientShop.GenerateShop();
                isShopGenerated = true;
            }
            
            
            string prompt = @"
Welcome to ingredient shop. Hre you can buy ingredients for your potions and do other stuff.
";

            string[] options = { "show my balance",
                "show my storage",
                "show shop offer",
                "restock for 50 gold",
                "show recipes",
                "-------------------",
                $"Buy root of mandrake - price:{ingredientShop.GetIngredientPrice(Storage.IngredientType.root_of_mandrake)}",
                $"Buy unicorn horn - price:{ingredientShop.GetIngredientPrice(Storage.IngredientType.unicorn_horn)}",
                $"Buy dragon scale - price:{ingredientShop.GetIngredientPrice(Storage.IngredientType.dragon_scale)}",
                $"Buy wing of bat- price:{ingredientShop.GetIngredientPrice(Storage.IngredientType.wing_of_bat)}",
                $"Buy arctic moss - price:{ingredientShop.GetIngredientPrice(Storage.IngredientType.arctic_moss)}",
                $"Buy fang of snake - price:{ingredientShop.GetIngredientPrice(Storage.IngredientType.fang_of_snake)}",
                $"Buy golden seed - price:{ingredientShop.GetIngredientPrice(Storage.IngredientType.golden_seed)}",
                $"Buy black pearl - price:{ingredientShop.GetIngredientPrice(Storage.IngredientType.black_pearl)}",
                $"Buy white mushroom - price:{ingredientShop.GetIngredientPrice(Storage.IngredientType.white_mushroom)}",
                "go back" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    
                    Console.WriteLine($"User's balance: {ingredientShop.GetBalance()} gold");           
                    resetAndBack();
                    break;
                case 1:
                    Storage.PrintStorageContents(Storage.storage);
                    resetAndBack();
                    break;

                case 2:
                    ingredientShop.DisplayIngredients();
                    resetAndBack();
                    break;

                case 3:
                    ingredientShop.RestockIngredients();
                    resetAndBack();
                    break;
                case 4:
                    showRecipes();                    
                    break;
                case 5:
                    MyGame.MyIngredientShopScene.Run();
                    break;
                case 6:
                    ingredientShop.BuyIngredient(Storage.IngredientType.root_of_mandrake);
                    resetAndBack();
                    break;
                case 7:
                    ingredientShop.BuyIngredient(Storage.IngredientType.unicorn_horn);
                    resetAndBack();
                    break;
                case 8:
                    ingredientShop.BuyIngredient(Storage.IngredientType.dragon_scale);
                    resetAndBack();
                    break;
                case 9:
                    ingredientShop.BuyIngredient(Storage.IngredientType.wing_of_bat);
                    resetAndBack();
                    break;
                case 10:
                    ingredientShop.BuyIngredient(Storage.IngredientType.arctic_moss);
                    resetAndBack();
                    break;
                case 11:
                    ingredientShop.BuyIngredient(Storage.IngredientType.fang_of_snake);
                    resetAndBack();
                    break;
                case 12:
                    ingredientShop.BuyIngredient(Storage.IngredientType.golden_seed);
                    resetAndBack();
                    break;
                case 13:
                    ingredientShop.BuyIngredient(Storage.IngredientType.black_pearl);
                    resetAndBack();
                    break;
                case 14:
                    ingredientShop.BuyIngredient(Storage.IngredientType.white_mushroom);
                    resetAndBack();
                    break;
                case 15:
                    MyGame.MyNavigationScene.Run();
                    break;
            }
        }
    }
}
