using System;
using Gooflings.Moves;

namespace Gooflings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Resources resources = new Resources();
            Menu menu = new Menu();

            //menu.DrawMainMenu();
            //menu.DrawTeamMenu();
            //menu.DrawBagMenu();

            GooflingData grayanData = resources.GetGooflingData(GooflingType.Grayan);
            Goofling grayan = new(grayanData);
            GooflingData danyData = resources.GetGooflingData(GooflingType.Radany);
            Goofling dany = new(danyData);

            Move move = resources.GetMove(MoveType.Croustifesses);
            move.OnAction(grayan, dany);
        }
    }
}