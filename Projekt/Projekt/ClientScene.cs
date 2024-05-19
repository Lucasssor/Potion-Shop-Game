using Projekt.Potions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Projekt.Menu;
using static Projekt.Potions.Recipe;
using static System.Console;

namespace Projekt
{
    internal class ClientScene : Scene
    {
        public ClientScene(Game game) : base(game)
        {
        }

        private string glassType = "none";

        private string capacityType = "none";

        Recipe.PotionCapacityType capacityTypeFactory;
        Recipe.PotionGlassType glassTypeFactory;


        private int excellence;
        private string chosen_potion = "none";

        public RecipeFactory recipeFactory;
        
        Random random = new Random();

        private List<string> typesofpotions = new List<string>() { "HealthPotion", "SleepPotion", "LovePotion", "StrengthPotion" };

        private string chosen_potion_rnd;
        Recipe.PotionGlassType glassTypeFactory_rnd;
        Recipe.PotionCapacityType capacityTypeFactory_rnd;

        private List<Recipe.PotionGlassType> potionGlassTypes = new List<Recipe.PotionGlassType>()
        { Recipe.PotionGlassType.Sferic,
          Recipe.PotionGlassType.Triangle,
          Recipe.PotionGlassType.Cylinder };

        private List<Recipe.PotionCapacityType> potionCapacityTypes = new List<Recipe.PotionCapacityType>() 
        { Recipe.PotionCapacityType.Mini, 
          Recipe.PotionCapacityType.Small, 
          Recipe.PotionCapacityType.Medium, 
          Recipe.PotionCapacityType.Big };

        private void resetAndBack()
        {
            ConsoleShortcuts.WaitForKeyPress();
            MyGame.MyClientScene.Run();
        }
        public List<Recipe> Potions => MyGame.Potions;
        private void checkIfOrderPossible()
        {
            if (Potions.Count >= 3)
            {
                Console.WriteLine("You can't make more than 3 orders");
                resetAndBack();
            }
        }        
        public override void Run()
        {
            string prompt = "Now youa are a client. Make your order here.";
            string[] options = { "show current order's details",
                "***** Choose potion type: *****",
                "healthpotion",
                "sleeppotion",
                "lovepotion",
                "strenghtpotion",
                "***** Choose glass type: *****",
                "sferic",
                "triangle",
                "cylinder",
                "***** Choose capacity type: *****",
                "mini",
                "small",
                "medium",
                "big",
                "***** Choose excellence of potion: *****",
                "excellence: 1",
                "excellence: 2",
                "excellence: 3",
                "SUBMIT YOUR ORDER",
                "make random order - you can accept or decline it after seeing details",
                "go back"};
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine($"potion: {chosen_potion}, glass type: {glassType}, capacity: {capacityType}, excellence: {excellence}");

                    resetAndBack();

                    break;
                case 1:                    
                    MyGame.MyClientScene.Run();
                    break;
                case 2:
                    chosen_potion = "HealthPotion";
                    Console.WriteLine("Chosen potion type: Health");
                    resetAndBack();
                    break;

                case 3:
                    chosen_potion = "SleepPotion";
                    Console.WriteLine("Chosen potion type: Sleep");
                    resetAndBack();
                    break;

                case 4:
                    chosen_potion = "LovePotion";
                    Console.WriteLine("Chosen potion type: Love");
                    resetAndBack();
                    break;
                case 5:
                    chosen_potion = "StrengthPotion";
                    Console.WriteLine("Chosen potion type: Strength");
                    resetAndBack();
                    break;
                case 6:
                    MyGame.MyClientScene.Run();
                    break;

                case 7:
                    glassType = "Sferic";

                    glassTypeFactory = PotionGlassType.Sferic;
                    Console.WriteLine("Chosen glass type: Sferic");
                    resetAndBack();
                    break;

                case 8:
                    glassType = "Triangle";
                    glassTypeFactory = PotionGlassType.Triangle;
                    Console.WriteLine("Chosen glass type: Triangle");
                    resetAndBack();
                    break;

                case 9:
                    glassType = "Cylinder";
                    glassTypeFactory = PotionGlassType.Cylinder;
                    Console.WriteLine("Chosen glass type: Cylinder");
                    resetAndBack();
                    break;
                case 10:
                    MyGame.MyClientScene.Run();
                    break;
                case 11:
                    capacityType = "Mini";
                    capacityTypeFactory = PotionCapacityType.Mini;
                    
                    Console.WriteLine("Chosen potion type: Mini");
                    resetAndBack();
                    break;
                

                case 12:
                    capacityType = "Small";
                    capacityTypeFactory = PotionCapacityType.Small;
                    Console.WriteLine("Chosen potion type: Small");
                    resetAndBack();
                    break;
                    

                case 13:
                    capacityType = "Medium";
                    capacityTypeFactory = PotionCapacityType.Medium;
                    Console.WriteLine("Chosen potion type: Medium");
                    resetAndBack();
                    break;

                case 14:
                    capacityType = "Big";
                    capacityTypeFactory = PotionCapacityType.Big;
                    Console.WriteLine("Chosen potion type: Big");
                    resetAndBack();
                    break;
                case 15:
                    MyGame.MyClientScene.Run();
                    break;
                case 16:
                    excellence = 1;
                    Console.WriteLine("Chosen excellence: 1");
                    resetAndBack();
                    break;
                case 17:
                    excellence = 2;
                    Console.WriteLine("Chosen excellence: 2");
                    resetAndBack();
                    break;
                case 18:
                    excellence = 3;
                    Console.WriteLine("Chosen excellence: 3");
                    resetAndBack();
                    break;

                case 19:
                    if (chosen_potion == "none" || glassType == "none" || capacityType == "none" || excellence == 0)
                    {
                        Console.WriteLine("You have to choose all options");
                        resetAndBack();
                        break;
                    }
                    else
                    {
                        checkIfOrderPossible();
                        recipeFactory = RecipeFactory.CreateFactory(chosen_potion);
                        var potion = recipeFactory.Create(glassTypeFactory, capacityTypeFactory, excellence);
                        Console.WriteLine($"Order made for: {potion.getInfo()}");
                        Potions.Add(potion);
                        resetAndBack();

                        break;
                        
                    }
                case 20:
                    int rnd = random.Next(0, 4);
                    int rnd2 = random.Next(0, 3);
                    int rnd3 = random.Next(0, 4);
                    int excellencernd = random.Next(1, 4);

                    chosen_potion_rnd = typesofpotions[rnd];
                    glassTypeFactory_rnd = potionGlassTypes[rnd2];
                    capacityTypeFactory_rnd = potionCapacityTypes[rnd3]; 
                    
                    checkIfOrderPossible();
                    Console.WriteLine($"Order will be for for: {chosen_potion_rnd}, {glassTypeFactory_rnd}, {capacityTypeFactory_rnd}, {excellencernd}\nDo you accept (Y/N)?");
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    char keyPressed = char.ToUpper(keyInfo.KeyChar);

                    if (keyPressed == 'Y')
                    {
                        Console.WriteLine($"\nOrder accepted.");
                        recipeFactory = RecipeFactory.CreateFactory(chosen_potion_rnd);
                        var potion2 = recipeFactory.Create(glassTypeFactory_rnd, capacityTypeFactory_rnd, excellencernd);
                        Console.WriteLine($"Order made for: {potion2.getInfo()}");
                        Potions.Add(potion2);
                        resetAndBack();
                    }
                    else if (keyPressed == 'N')
                    {
                        Console.WriteLine($"\nOrder declined.");
                        resetAndBack();
                    }
                    else
                    {
                        Console.WriteLine($"\nNext time click Y/N - order declined");
                        resetAndBack();
                    }
                    break;

                case 21:
                    ConsoleShortcuts.WaitForKeyPress();
                    MyGame.MyNavigationScene.Run();
                    break;

            }
        }
    }
}
