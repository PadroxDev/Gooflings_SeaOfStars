using System;
using Gooflings.Moves;
using Gooflings.Managers;

namespace Gooflings
{

    public class Program
    {
        public static void Main(string[] args)
        {

            Console.Title = "Gooflings";
          
            MovementPlayer movement = new MovementPlayer();
            Player player = new Player();
            InputManager input = new InputManager();
            Resources resources = new Resources();
            Menu menu = new Menu();
            GooflingData grayanData = resources.GetGooflingData(GooflingType.Grayan);
            Goofling grayan = new(grayanData);
            GooflingData danyData = resources.GetGooflingData(GooflingType.Radany);
            Goofling dany = new(danyData);

            player.Party.Members.Add(grayan);
            player.Party.Members.Add(dany);

            menu.DrawTeamMenu(player.Party.Members);

            Move move = resources.GetMove(MoveType.Croustifesses);
            move.OnAction(grayan, dany);
        }
    }
}