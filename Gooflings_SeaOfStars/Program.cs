using System;

namespace Gooflings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Resources resources = new Resources();
            Menu menu = new Menu();

            menu.DrawMainMenu();
            menu.DrawTeamMenu();
            menu.DrawBagMenu();
        }
    }
}