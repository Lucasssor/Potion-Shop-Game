using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Projekt
{
    internal class TitleScene : Scene
    {

        
        public TitleScene(Game game) : base(game)
        {

        }

        public override void Run()
        {
            string prompt = $@"Welcome to alchemy shop
Use arrows and enter to navigate :)
";
            string[] options = { "Play", "About", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    MyGame.MyNavigationScene.Run();
                    ConsoleShortcuts.WaitForKeyPress();
                    break;

                case 1:
                    DisplayAboutInfo();
                    break;

                case 2:
                    ConsoleShortcuts.ExitConsole();
                    break;
            }
        }
        private void DisplayAboutInfo()
        {
            Clear();
            WriteLine("Game by: Łukasz Kiecka");
            WriteLine("Press any key to return to the main menu");
            ReadKey();
            Run();

        }

    }
}
