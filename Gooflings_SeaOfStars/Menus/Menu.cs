using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gooflings
{
    public class Menu
    {

        public void DrawMenuDeco()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                if (i == 0 || i == Console.WindowWidth)
                {
                    
                }
            }
        }
        
                    string title = @"
                       _____                 __  _  _                    
                      / ____|               / _|| |(_)                   
                     | |  __   ___    ___  | |_ | | _  _ __    __ _  ___ 
                     | | |_ | / _ \  / _ \ |  _|| || || '_ \  / _` |/ __|
                     | |__| || (_) || (_) || |  | || || | | || (_| |\__ \
                      \_____| \___/  \___/ |_|  |_||_||_| |_| \__, ||___/
                                                               __/ |     
                                                              |___/      ";
                    string start = @" 
                       _____  _                _   
                      / ____|| |              | |  
                     | (___  | |_  __ _  _ __ | |_ 
                      \___ \ | __|/ _` || '__|| __|
                      ____) || |_| (_| || |   | |_ 
                     |_____/  \__|\__,_||_|    \__|";

                    string load = @"
                      _                        _ 
                     | |                      | |
                     | |      ___    __ _   __| |
                     | |     / _ \  / _` | / _` |
                     | |____| (_) || (_| || (_| |
                     |______|\___/  \__,_| \__,_|";

                    string credits = @"
                       _____                 _  _  _        
                      / ____|               | |(_)| |       
                     | |      _ __  ___   __| | _ | |_  ___ 
                     | |     | '__|/ _ \ / _` || || __|/ __|
                     | |____ | |  |  __/| (_| || || |_ \__ \
                      \_____||_|   \___| \__,_||_| \__||___/";

                    string extra = @"
                      ______        _  _   
                     |  ____|      (_)| |  
                     | |__   __  __ _ | |_ 
                     |  __|  \ \/ /| || __|
                     | |____  >  < | || |_ 
                     |______|/_/\_\|_| \__|";
        

        public void DrawTitleMenu()
        {
            Console.Clear();

           Console.WriteLine(title);
        }

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
            Console.WriteLine($" \\{returnStringName(party[0],25)}\\       __________________________");
            Console.WriteLine($"  \\{returnStringHp(party[0], 25)}\\      \\                         \\");
            Console.WriteLine($"   \\{returnStringMana(party[0], 25)}\\      \\{returnStringName(party[1], 25)}\\");
            Console.WriteLine($"    \\_________________________\\      \\{returnStringHp(party[1], 25)}\\");
            Console.WriteLine($"                                      \\{returnStringMana(party[1], 25)}\\");
            Console.WriteLine("__________________________             \\_________________________\\");
            Console.WriteLine("\\                         \\   ");
            Console.WriteLine($" \\{returnStringName(party[2], 25)}\\       __________________________");
            Console.WriteLine($"  \\{returnStringHp(party[2], 25)}\\      \\                         \\");
            Console.WriteLine($"   \\{returnStringMana(party[2], 25)}\\      \\{returnStringName(party[3], 25)}\\");
            Console.WriteLine($"    \\_________________________\\      \\{returnStringHp(party[3], 25)}\\");
            Console.WriteLine($"                                      \\{returnStringMana(party[3], 25)}\\");
            Console.WriteLine("__________________________             \\_________________________\\");
            Console.WriteLine("\\                         \\");
            Console.WriteLine($" \\{returnStringName(party[4], 25)}\\       __________________________");
            Console.WriteLine($"  \\{returnStringHp(party[4], 25)}\\      \\                         \\");
            Console.WriteLine($"   \\{returnStringMana(party[4], 25)}\\      \\{returnStringName(party[5], 25)}\\");
            Console.WriteLine($"    \\_________________________\\      \\{returnStringHp(party[5], 25)}\\");
            Console.WriteLine($"                                      \\{returnStringMana(party[5], 25)}\\");
            Console.WriteLine("                                       \\_________________________\\");
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

        public string returnStringName(Goofling goofling,int space)
        {
            string str = $" {goofling.Name} Niv.{goofling.Level}";
            int rest = space - str.Length;
            if (rest > 0)
            {
                return str + new string(' ', rest);
            }
            return str;
        }
        public string returnStringHp(Goofling goofling, int space)
        {
            string str = $" HP {goofling.HP}/{goofling.MaxHP}";
            int rest = space - str.Length;
            if (rest > 0)
            {
                return str + new string(' ', rest);
            }
            return str;
        }
        public string returnStringMana(Goofling goofling, int space)
        {
            string str = $" PM {goofling.Mana}/{goofling.MaxMana}";
            int rest = space - str.Length;
            if (rest > 0) {
               return str + new string(' ', rest);
            }
            return str;
        }
    }
}
