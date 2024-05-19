using Projekt.Potions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Console;

namespace Projekt
{
    internal class AlchemistScene :Scene
    {
            
        public AlchemistScene(Game game) : base(game)
        {
        }

        private bool endlessMode = false;
     

        private static List<Recipe> soldPotions = new List<Recipe>();

        private void sellPotionNumber(int index)
        {
            if (LabScene.BrewedPotions.Count >= index)
            {
                var potion = LabScene.BrewedPotions[index - 1];               

                LabScene.BrewedPotions.Remove(potion);
                soldPotions.Add(potion);
                Console.WriteLine($"You sold {potion.Name} for {potion.Price} gold");
                IngredientShop.userBalance += potion.Price;
                ConsoleShortcuts.WaitForKeyPress();
                checkIfWon();                                                                           
            }
            else
            {
                WriteLine("You don't have enough brewed potions to sell.");
                ConsoleShortcuts.WaitForKeyPress();
                MyGame.MyAlchemistScene.Run();
            }
        }
        private void endOrEndlessMode()
        {
            string prompt = "Congratulations." +
                " You won the game - reached 500 gold. Do you want to turn on endless game or exit the game?";
            string[] options = { "Endless mode", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    endlessMode = true;
                    MyGame.MyAlchemistScene.Run();
                    break;
                case 1:                    
                    ConsoleShortcuts.WaitForKeyPress();
                    ConsoleShortcuts.ExitConsole();
                    break;
            }
        }
        private void checkIfWon()
        {
            if (IngredientShop.userBalance >= 500)
                if (endlessMode)
                {
                    ConsoleShortcuts.WaitForKeyPress();
                    MyGame.MyAlchemistScene.Run();
                }
                else
                {
                    endOrEndlessMode();
                }
            
            MyGame.MyAlchemistScene.Run();
        }
        public override void Run()
        {
            string prompt = "Now you became alchemist-seller you can check your brewed potions inventory and sell them if you want.";
            string[] options = { "check orders ready to sell", "sell order nr 1", "sell order nr 2", "sell order nr 3", "check done deals",  "go back" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("Potions:");
                    for (int i = 0; i < LabScene.BrewedPotions.Count; i++)
                    {
                        var potion1 = LabScene.BrewedPotions[i];
                        Console.WriteLine($"{i + 1}. Potion's name: {potion1.Name}, Glass type: {potion1.NameOfGlass}, Capacity type: {potion1.NameOfCapacity}, Excellence: {potion1.Excellence}, Price: {potion1.Price}");
                    }
                    ConsoleShortcuts.WaitForKeyPress();
                    MyGame.MyAlchemistScene.Run();
                    break;                   

                case 1:
                    sellPotionNumber(1);
                    break;

                case 2:
                    sellPotionNumber(2);
                    break;
                case 3:
                    sellPotionNumber(3);
                    break;
                case 4:
                    Console.WriteLine("Done deals:");
                    for (int i = 0; i < soldPotions.Count; i++)
                    {
                        var potion1 = soldPotions[i];
                        Console.WriteLine($"{i + 1}. Potion's name: {potion1.Name}, Glass type: {potion1.NameOfGlass}, Capacity type: {potion1.NameOfCapacity}, Excellence: {potion1.Excellence}, Price: {potion1.Price}");
                    }
                    ConsoleShortcuts.WaitForKeyPress();
                    MyGame.MyAlchemistScene.Run();
                    break;                    
                case 5:
                    MyGame.MyNavigationScene.Run();
                    break;
            }
        }
    }
}
