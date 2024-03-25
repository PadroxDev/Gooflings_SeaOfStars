using System;
using Gooflings.Moves;

namespace Gooflings
{

    public class Program
    {
        public static void Main(string[] args)
        {

            Console.Title = "Gooflings";
            Console.SetWindowSize(160, 30);
          
            MovementPlayer movement = new MovementPlayer();
            Player player = new Player();
            InputManager input = new InputManager();
            Resources resources = new Resources();
            Menu menu = new Menu();

            GooflingData grayanData = resources.GetGooflingData(GooflingType.Grayan);
            grayanData.Level = 20;
            Goofling grayan = new(grayanData);
            GooflingData danyData = resources.GetGooflingData(GooflingType.Radany);
            danyData.CurrentHP = 0.8252427f;

            danyData.Level = 32;
            Goofling dany = new(danyData);

            player.Party.Members.Add(grayan);
            player.Party.Members.Add(dany);


            string[] options = { "oui","non", "merci", "papa?" };

            menu.DrawTitleMenu(options);
            menu.displayOptions();
            //Move move = resources.GetMove(MoveType.Croustifesses);
            //move.OnAction(grayan, dany);
        }
    }
}