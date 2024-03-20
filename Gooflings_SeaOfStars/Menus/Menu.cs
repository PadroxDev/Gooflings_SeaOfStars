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

        public void DrawTeamMenu(List<Goofling> party)
        {
            Console.Clear();

            Console.WriteLine("__________________________");
            Console.WriteLine("\\                         \\");
            Console.WriteLine($" \\ {returnStringName(Resources.Instance.GetGooflingData(party[0].GooflingType),24)}\\       __________________________");
            Console.WriteLine($"  \\ {returnStringHp(Resources.Instance.GetGooflingData(party[0].GooflingType), 24)}\\      \\                         \\");
            Console.WriteLine($"   \\ {returnStringMana(Resources.Instance.GetGooflingData(party[0].GooflingType), 24)}\\      \\ {returnStringName(Resources.Instance.GetGooflingData(party[1].GooflingType), 24)}\\");
            Console.WriteLine($"    \\_________________________\\      \\ {returnStringHp(Resources.Instance.GetGooflingData(party[1].GooflingType), 24)}\\");
            Console.WriteLine($"                                      \\ {returnStringMana(Resources.Instance.GetGooflingData(party[1].GooflingType), 24)}\\");
            Console.WriteLine("__________________________             \\_________________________\\");
            Console.WriteLine("\\                         \\   ");
            Console.WriteLine(" \\                         \\       __________________________");
            Console.WriteLine("  \\                         \\      \\                         \\");
            Console.WriteLine("   \\                         \\      \\                         \\");
            Console.WriteLine("    \\_________________________\\      \\                         \\");
            Console.WriteLine("                                      \\                         \\");
            Console.WriteLine("____________________________           \\_________________________\\");
            Console.WriteLine("\\                           \\");
            Console.WriteLine(" \\                           \\     ____________________________");
            Console.WriteLine("  \\                           \\    \\                           \\");
            Console.WriteLine("   \\                           \\    \\                           \\");
            Console.WriteLine("    \\___________________________\\    \\                           \\");
            Console.WriteLine("                                      \\                           \\");
            Console.WriteLine("                                       \\___________________________\\");
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

        public string returnStringName(GooflingData gooflingData,int space)
        {
            string str = $"{gooflingData.Name} Niv.{gooflingData.Level}";
            int rest = space - str.Length;
            if (rest > 0)
            {
                return str + new string(' ', rest);
            }
            return str;
        }
        public string returnStringHp(GooflingData gooflingData, int space)
        {
            string str = $"HP {gooflingData.HP}/{gooflingData.MaxHP}";
            int rest = space - str.Length;
            if (rest > 0)
            {
                return str + new string(' ', rest);
            }
            return str;
        }
        public string returnStringMana(GooflingData gooflingData, int space)
        {
            string str = $"PM {gooflingData.Mana}/{gooflingData.MaxMana}";
            int rest = space - str.Length;
            if (rest > 0) {
               return str + new string(' ', rest);
            }
            return str;
        }
    }
}
