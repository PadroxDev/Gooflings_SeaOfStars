
﻿using Gooflings;
using System;
using Gooflings.Moves;



namespace Gooflings
{

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(180, 50);
            Console.SetBufferSize(180, 50);

            // width = 180
            // heigh = 50

            Console.Title = "Gooflings";

            MovementPlayer movement = new MovementPlayer();
            Player player = new Player();
            InputManager input = new InputManager();

            while (true)
            {
                bool pressed = Console.KeyAvailable;
                movement.DoesMove(pressed, player, input);

                for (int i = 0; i < Console.WindowHeight; i++)
                {
                    for (int j = 0;j < Console.WindowWidth; j++)
                    {
                        if (i == player.posY && j == player.posX)
                        {
                            Console.Write("0");
                        }
                        else
                        {
                            Console.Write(".");
                        }
                        
                    } 
                    Console.WriteLine();
                }

                Thread.Sleep(1000);
                Console.Clear();

            }


            Resources resources = new Resources();
            Menu menu = new Menu();
          

            GooflingData grayanData = resources.GetGooflingData(GooflingType.Grayan);
            Goofling grayan = new(grayanData);
            GooflingData danyData = resources.GetGooflingData(GooflingType.Radany);
            Goofling dany = new(danyData);

            Move move = resources.GetMove(MoveType.Croustifesses);
            move.OnAction(grayan, dany);
        }
    }
}