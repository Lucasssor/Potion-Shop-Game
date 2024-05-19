// See https://aka.ms/new-console-template for more information
using Projekt;
using Projekt.Potions;
using System;
using System.Collections.Generic;
using static System.Console;


namespace KeyboardMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            Title = " Alchemy shop";
            CursorVisible = false;
            try
            {
                WindowWidth = 148;
                WindowHeight = 31;
            }
            catch
            {
                WriteLine("Please adjust console menu manually");
            }

            

            Game myGame = new Game();
            myGame.Start();
        }

    }
}


//IngredientShop ingredientShop = new IngredientShop();
//ingredientShop.Do();

/*
Console.WriteLine("Hello, World!");
IngredientShop ingredientShop = new IngredientShop();
RecipeFactory recipeFactory = RecipeFactory.CreateFactory("HealthPotion");


var potion1 = recipeFactory.Create(Recipe.PotionGlassType.Sferic, Recipe.PotionCapacityType.Small, 2);

Console.WriteLine(potion1.getInfo());

RecipeFactory recipeFactory1 = RecipeFactory.CreateFactory("SleepPotion");


var potion2 = recipeFactory1.Create(Recipe.PotionGlassType.Sferic, Recipe.PotionCapacityType.Small, 2);

Console.WriteLine(potion2.getInfo());



Storage.PrintStorageContents(Storage.storage);


ingredientShop.DisplayIngredients();

ingredientShop.RestockIngredients();
ingredientShop.DisplayIngredients();

ingredientShop.BuyIngredient(Storage.IngredientType.root_of_mandrake);
Storage.PrintStorageContents(Storage.storage);
*/


