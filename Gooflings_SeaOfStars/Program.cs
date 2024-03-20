using System;

namespace Gooflings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "Gooflings";

            Resources resources = new Resources();
            Menu menu = new Menu();

            GooflingData data = new GooflingData();
            data.Name = "Grayana";
            data.Level = 1;
            data.HP = 100;
            data.MaxHP = 110;
            data.Mana = 280;
            data.MaxMana = 320;
            //menu.DrawMainMenu();
            menu.DrawTeamMenu(data);
            //menu.DrawBagMenu();
        }
    }
}