using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gooflings
{
    public class Menu
    {
        
        public void DrawMainMenu()
        {
            Console.Clear();

            Console.WriteLine(" __________________________     _________________________ ");
            Console.WriteLine("|                          |   |                         |");
            Console.WriteLine("|        Gooflings         |   |           Sac           |");
            Console.WriteLine("|__________________________|   |_________________________|");
            Console.WriteLine(" __________________________     _________________________ ");
            Console.WriteLine("|                          |   |                         |");
            Console.WriteLine("|        Sauvegarde        |   |         Quitter         |");
            Console.WriteLine("|__________________________|   |_________________________|");

        }

        public void DrawTeamMenu()
        {
            Console.Clear();
            Console.WriteLine("__________________________");
            Console.WriteLine("\\                         \\");
            Console.WriteLine(" \\                         \\       ____________________________");
            Console.WriteLine("  \\                         \\      \\                           \\");
            Console.WriteLine("   \\                         \\      \\                           \\");
            Console.WriteLine("    \\_________________________\\      \\                           \\");
            Console.WriteLine("                                      \\                           \\");
            Console.WriteLine("__________________________             \\___________________________\\");
            Console.WriteLine("\\                         \\   ");
            Console.WriteLine(" \\                         \\       _____________________________");
            Console.WriteLine("  \\                         \\      \\                            \\");
            Console.WriteLine("   \\                         \\      \\                            \\");
            Console.WriteLine("    \\_________________________\\      \\                            \\");
            Console.WriteLine("                                      \\                            \\");
            Console.WriteLine("____________________________           \\____________________________\\");
            Console.WriteLine("\\                           \\");
            Console.WriteLine(" \\                           \\     ______________________________");
            Console.WriteLine("  \\                           \\    \\                             \\");
            Console.WriteLine("   \\                           \\    \\                             \\");
            Console.WriteLine("    \\___________________________\\    \\                             \\");
            Console.WriteLine("                                      \\                             \\");
            Console.WriteLine("                                       \\_____________________________\\");
        }

        public void DrawBagMenu()
        {
            Console.Clear();
            Console.WriteLine("                           __________________________________________");
            Console.WriteLine("                          |  __________________   _________________  |");
            Console.WriteLine("  ___________________     | |                  | |                 | |");
            Console.WriteLine(" /                   \\    | |                  | |                 | |");
            Console.WriteLine("|       Potions       |   | |__________________| |_________________| |");
            Console.WriteLine(" \\___________________/    |                                          |");
            Console.WriteLine("  ___________________     |                                          |");
            Console.WriteLine(" /                   \\    |                                          |");
            Console.WriteLine("|        Keys         |   |                                          |");
            Console.WriteLine(" \\___________________/    |                                          |");
            Console.WriteLine("  ___________________     |                                          |");
            Console.WriteLine(" /                   \\    |                                          |");
            Console.WriteLine("|       Boosts        |   |                                          |");
            Console.WriteLine(" \\___________________/    |                                          |");
            Console.WriteLine("                          |                                          |");
            Console.WriteLine("                          |__________________________________________|");
        }
    }
}
