using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Projekt
{
    static class ConsoleShortcuts
    {
        public static void WaitForKeyPress()
        {
            WriteLine("(Press any key to continue.)");
            ReadKey(true);

        }
        public static void ExitConsole()
        {
            WriteLine("(Press any key to exit.)");
            ReadKey(true);
            Environment.Exit(0);
        }


    }
}
