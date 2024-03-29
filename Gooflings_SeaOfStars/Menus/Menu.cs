using Gooflings.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Gooflings
{

    public class Menu
    {
        public enum MenusDisplay
        {
            Title,
            MainMenu,
            GooflingMenu,
            GooflingStat,
            BagMenu,
            SaveMenu,
            Battle
        }

        InputManager _input;
        private int _selectedIndex;
        private string[] _options;

        #region stings

        string title = $"{returnDividedLine(@"   _____  ____   ____  ______ _      _____ _   _  _____  _____ ", Console.WindowWidth,2)}" +
            $"{returnDividedLine(@"  / ____|/ __ \ / __ \|  ____| |    |_   _| \ | |/ ____|/ ____|", Console.WindowWidth,2)}" +
            $"{returnDividedLine(@" | |  __| |  | | |  | | |__  | |      | | |  \| | |  __| (___  ", Console.WindowWidth,2)}" +
            $"{returnDividedLine(@" | | |_ | |  | | |  | |  __| | |      | | | . ` | | |_ |\___ \ ", Console.WindowWidth,2)}" +
            $"{returnDividedLine(@" | |__| | |__| | |__| | |    | |____ _| |_| |\  | |__| |____) |", Console.WindowWidth,2)}" +
            $"{returnDividedLine(@"  \_____|\____/ \____/|_|    |______|_____|_| \_|\_____|_____/ ", Console.WindowWidth,2)}";

        string continueButton = $"{returnDividedLine(@"                  _   _                  ", Console.WindowWidth,2)}" +
            $"{returnDividedLine(@"                 | | (_)                 ", Console.WindowWidth,2)}" +
            $"{returnDividedLine(@"   ___ ___  _ __ | |_ _ _ __  _   _  ___ ", Console.WindowWidth,2)}" +
            $"{returnDividedLine(@"  / __/ _ \| '_ \| __| | '_ \| | | |/ _ \", Console.WindowWidth,2)}" +
            $"{returnDividedLine(@" | (_| (_) | | | | |_| | | | | |_| |  __/", Console.WindowWidth,2)}" +
            $"{returnDividedLine(@"  \___\___/|_| |_|\__|_|_| |_|\__,_|\___|", Console.WindowWidth,2)}" +
            $"{returnDividedLine(@"                                         ", Console.WindowWidth,2)}";
        
        string credits = $"{returnDividedLine(@"                       _  _  _        ", Console.WindowWidth,2)}" +
            $"{returnDividedLine(@"                      | |(_)| |       ", Console.WindowWidth,2)}" +
            $"{returnDividedLine(@"   ___  _ __  ___   __| | _ | |_  ___ ", Console.WindowWidth,2)}" +
            $"{returnDividedLine(@"  / __|| '__|/ _ \ / _` || || __|/ __|", Console.WindowWidth,2)}" +
            $"{returnDividedLine(@" | (__ | |  |  __/| (_| || || |_ \__ \", Console.WindowWidth,2)}" +
            $"{returnDividedLine(@"  \___||_|   \___| \__,_||_| \__||___/", Console.WindowWidth,2)}" +
            $"{returnDividedLine(@"                                      ", Console.WindowWidth,2)}";
        
        string exit = $"{returnDividedLine(@"              _  _   ", Console.WindowWidth, 2)}" +
            $"{returnDividedLine(@"             (_)| |  ", Console.WindowWidth, 2)}" +
            $"{returnDividedLine(@"   ___ __  __ _ | |_ ", Console.WindowWidth, 2)}" +
            $"{returnDividedLine(@"  / _ \\ \/ /| || __|", Console.WindowWidth, 2)}" +
            $"{returnDividedLine(@" |  __/ >  < | || |_ ", Console.WindowWidth, 2)}" +
            $"{returnDividedLine(@"  \___|/_/\_\|_| \__|", Console.WindowWidth, 2)}" +
            $"{returnDividedLine(@"                     ", Console.WindowWidth, 2)}";



        string gooflingMenuG = $" __________________________  \n|                          |\n|{returnCenteredLine("Gooflings",26)}|\n|__________________________|\n";
        string gooflingMenuB = $" __________________________  \n|                          |\n|{returnCenteredLine("Bag",26)}|\n|__________________________|\n";
        string gooflingMenuS = $" __________________________  \n|                          |\n|{returnCenteredLine("Save",26)}|\n|__________________________|\n";
        string gooflingMenuQ = $" __________________________  \n|                          |\n|{returnCenteredLine("Quit",26)}|\n|__________________________|\n";

        string missingno = "⠀⠀⠀⠀⡆⠁⢿⡯⡟⡝⣿⠂\n⠀⠀⠀⠀⡟⠿⢷⣶⢙⣽⠖⡇\n⠀⠀⠀⠀⡷⣍⣭⣍⣍⣿⣟⡇\n⠀⠀⠀⠀⣗⣟⣿⣯⣟⣿⣛⠆\n⠀⠀⠀⠀⡷⣴⣵⣟⣑⣫⣥⡇\n⢰⠒⠒⢶⣷⢶⣽⣟⠷⣳⢬⠇\n⢸⣖⣒⣺⡷⢿⢦⡴⠹⣾⡛⡇\n⢸⣗⣒⣿⣾⣿⡹⣇⣿⣏⣚⡇\n⢸⣹⡻⣻⡻⣻⢓⣯⣶⣾⣯⠇\n⢸⣀⣀⣀⣁⢩⣴⢯⣯⣟⡝⡇\n⢸⣤⣴⣶⢎⢿⠉⣽⡿⣻⣮⡇\n⢸⠶⢖⡿⢛⣛⢭⡵⡞⠇⣷⡇";
        string missingnorevert = "⠂⣿⡝⡟⡯⢿⠁⡆⠀⠀\n⡇⠖⣽⢙⣶⢷⠿⡟\n⡇⣟⣿⣍⣍⣭⣍⡷\n⠆⣛⣿⣟⣯⣿⣟⣗\n⡇⣥⣫⣑⣟⣵⣴⡷\n⠇⢬⣳⠷⣟⣽⢶⣷⢶⠒⠒⢰\n⡇⣮⣻⡿⣽⠉⢿⢎⣶⣴⣤⢸\n⡇⡝⣟⣯⢯⣴⢩⣁⣀⣀⣀⢸\n⠇⣯⣾⣶⣯⢓⣻⡻⣻⡻⣹⢸\n⡇⣚⣏⣿⣇⡹⣿⣾⣿⣒⣗⢸\n⡇⡛⣾⠹⡴⢦⢿⡷⣺⣒⣖⢸\n⠇⢬⣳⠷⣟⣽⢶⣷⢶⠒⠒⢰";
        #endregion

        public Menu(InputManager input)
        {
            _input = input;
        }

        public void Update(int menu, Player player, BattleManager battleManager, ref GameState state) 
        {
            bool displayDirty = false;
            if (_input.GetKeyDown(ConsoleKey.DownArrow))
            {
                _selectedIndex = ++_selectedIndex%_options.Count();
                displayDirty = true;
            }
            if (_input.GetKeyDown(ConsoleKey.UpArrow))
            {
                _selectedIndex--;
                if (_selectedIndex < 0)
                {
                    _selectedIndex = _options.Count()-1;
                }
                displayDirty = true;
            }
            if (_input.GetKeyDown(ConsoleKey.Enter))
            {
                Console.Beep();
                switch (_selectedIndex)
                {
                    case 0:
                        if (menu == (int)MenusDisplay.Title)
                        {
                            state = GameState.Exploring;
                        }
                        if (menu == (int)MenusDisplay.MainMenu)
                        {
                            DrawTeamMenu(player.Party.Members);
                        }
                        if (menu == (int)MenusDisplay.Battle)
                        {
                            //DrawMove();
                        }
                        break;
                    case 1:
                        if (menu == (int)MenusDisplay.Title)
                        {
                            CreditsPage();

                        }
                        if (menu == (int)MenusDisplay.MainMenu)
                        {
                            DrawBagMenu();
                        }
                        if (menu == (int)MenusDisplay.Battle)
                        {
                            DrawTeamMenu(player.Party.Members);
                        }
                        break;
                    case 2:
                        if (menu == (int)MenusDisplay.Title)
                        {
                            Environment.Exit(0);
                        }
                        if (menu == (int)MenusDisplay.MainMenu)
                        {
                            Serializer.Save(player);
                        }
                        if (menu == (int)MenusDisplay.Battle)
                        {

                        }
                        break;
                    case 3:
                        if (menu == (int)MenusDisplay.MainMenu)
                        {
                            Environment.Exit(0);
                        }
                        if (menu == (int)MenusDisplay.Battle)
                        {
                            state = GameState.Exploring;
                        }
                        break;
                    case 4:
                        break;
                    default:
                        break;
                }
            }
            if (displayDirty)
            {
                Console.Clear();
                switch (menu)
                {
                    case (int)MenusDisplay.Title:
                        DrawTitleMenu();
                        break;
                    case (int)MenusDisplay.MainMenu:
                        DrawMainMenu(); 
                        break;
                    case (int)MenusDisplay.Battle:
                        Goofling enemyGoofling = battleManager.EnemyGoofling;
                        List<Goofling> allyGooflings = battleManager.Player.Party.Members;
                        DrawBattleMenu(allyGooflings, enemyGoofling);
                        break;
                    default:
                        break;
                }
            }
        }
    

        public void DrawTitleMenu() 
        {
            string[] titleOptions = { continueButton, credits, exit };
            _options =  titleOptions;

            Helpers.SkipLines(5);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(title);
            Console.ResetColor();
            Helpers.SkipLines(7);
            for (int i = 0; i < _options.Length; i++)
            {
                string currentOption = _options[i];
                if (i == _selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(currentOption);
                }
                else
                {
                    Console.Write(currentOption); 
                }
                Helpers.SkipLines(2);
                Console.ResetColor();
            }
        }

        private void CreditsPage()
        {
            Console.Clear ();
            Helpers.SkipLines((Console.WindowHeight/2)-4);
            Console.WriteLine(returnDividedLine("CREDITS:", Console.WindowWidth, 2));
            Console.WriteLine(returnDividedLine("Antoine VOLLET", Console.WindowWidth, 2));
            Console.WriteLine(returnDividedLine("Gwendal REBOUL", Console.WindowWidth, 2));
            Console.WriteLine(returnDividedLine("William BAILLEUL", Console.WindowWidth, 2));
            Console.ReadKey(true);
            Console.Clear();
            DrawTitleMenu();
        }

        public void DrawMainMenu()
        {
            string[] MainOptions = { gooflingMenuG, gooflingMenuB, gooflingMenuS, gooflingMenuQ };
            _options = MainOptions;

            for (int i = 0; i < _options.Length; i++)
            {
                string currentOption = _options[i];
                if (i == _selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(currentOption);
                }
                else
                {
                    Console.Write(currentOption);
                }
                Console.ResetColor();
            }
        }

        public void DrawGooflingStatMenu(Goofling goofling)
        {
            Console.Clear();

            Console.WriteLine(goofling);
        }
        
        public void DrawBattleMenu(List<Goofling> party,Goofling goofling) 
        {
            string[] battleOptions = { "Attack", "Gooflings", "Bag", "Flee" };
            _options = battleOptions;
            char prefix;

            Console.WriteLine(new string('*',Console.WindowWidth));
            for (int i = 0; i < _options.Length; i++)
            {
                string currentOption = _options[i];
                if (i == _selectedIndex)
                {
                    prefix = '>';
                    Console.WriteLine($"{prefix}{currentOption}");
                }
                else
                {
                    prefix = ' ';
                    Console.WriteLine($"{prefix}{currentOption}");
                }
                Console.ResetColor();
            }
            Console.WriteLine(new string('*',Console.WindowWidth));
        }
        public void DrawTeamMenu(List<Goofling> party)
        {

            Console.WriteLine("__________________________");
            Console.WriteLine("\\                         \\");
            Console.WriteLine($" \\" + (party[0] != null ? returnStringName(party[0], 25) : new string(' ', 25)) +  "\\       __________________________");
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
        public static string returnCenteredLine(string prompt, int space)
        {
            string str = $"{prompt}";
            int rest = space - str.Length;
            if (rest > 0) {
                for (int i = 0; i < rest/2; i++)
                {
                    str = " " + str ;
                }
               return str + new string(' ', Maths.IsEven(rest)? rest/2 : rest/2+1);
            }
            return str;
        } 
        public static string returnDividedLine(string prompt, int space, int divider)
        {
            string str = $"{prompt}";
            int rest = space - str.Length;
            int newRest = rest / divider;
            int last = rest - newRest;
            if (rest > 0) {
                for (int i = 0; i < rest/divider; i++)
                {
                    str = " " + str ;
                }
               return str + new string(' ', last);
            }
            return str;
        }
    }
}
