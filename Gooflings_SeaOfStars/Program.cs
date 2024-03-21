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
            Console.SetWindowSize(180,50);
          
            MovementPlayer movement = new MovementPlayer();
            Player player = new Player();
            InputManager input = new InputManager();

            //while (true)
            //{
            //    bool pressed = Console.KeyAvailable;
            //    movement.DoesMove(pressed, player, input);

            //    for (int i = 0; i < 10; i++)
            //    {
            //        for (int j = 0;j < 10; j++)
            //        {
            //            if (i == player.posY && j == player.posX)
            //            {
            //                Console.Write("0");
            //            }
            //            else
            //            {
            //                Console.Write(".");
            //            }
                        
            //        } 
            //        Console.WriteLine();
            //    }

            //    Thread.Sleep(1000);
            //    Console.Clear();

            //}


            Resources resources = new Resources();
            Menu menu = new Menu();
            GooflingData grayanData = resources.GetGooflingData(GooflingType.Grayan);
            grayanData.Level = 20;
            Goofling grayan = new(grayanData);
            GooflingData danyData = resources.GetGooflingData(GooflingType.Radany);
            danyData.Level = 32;
            Goofling dany = new(danyData);




            player.Party.Members.Add(grayan);
            player.Party.Members.Add(dany);
            player.Party.Members.Add(grayan);
            player.Party.Members.Add(dany);
            player.Party.Members.Add(dany);
            player.Party.Members.Add(grayan);

            menu.DrawTeamMenu(player.Party.Members);

            Move move = resources.GetMove(MoveType.Croustifesses);
            move.OnAction(grayan, dany);
        }
    }
}