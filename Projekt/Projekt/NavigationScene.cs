using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace Projekt
{
    internal class NavigationScene : Scene
    {
        public NavigationScene(Game game) : base(game)
        {
        }

        public override void Run()
        {
            string prompt = "Welcome to the potion shop command centre - here you can become a client, alchemist, ingredient buyer and seller.";
            string[] options = { "Go to become client", "Go to Lab", "Go to Ingredient Shop", "Go to sell at shop counter" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    MyGame.MyClientScene.Run();
                    break;
                case 1:
                    MyGame.MyLabScene.Run();
                    break;
                case 2:
                    MyGame.MyIngredientShopScene.Run();
                    break;
                case 3:
                    MyGame.MyAlchemistScene.Run();
                    break;



            }
        }
    }
}
