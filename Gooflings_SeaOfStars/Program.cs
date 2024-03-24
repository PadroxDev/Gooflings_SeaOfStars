using System;
using Gooflings.Moves;

namespace Gooflings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Encapsuler dans une class App
            Console.Title = "Gooflings";
            Console.SetWindowSize(180,50);

            // Initialization
            Resources resources = new Resources();
            MovementPlayer movement = new MovementPlayer();
            Player player = new Player();
            InputManager inputManager = new InputManager();
            NavMenu nav = new(inputManager, 3, 4);

            // Gameloop
            while (true) {
                inputManager.Update();
                nav.Update();

                int[,] buffer = new int[nav.Columns, nav.Rows];

                for (int x = 0; x < nav.Columns; x++) {
                    for (int y = 0; y < nav.Rows; y++) {
                        int v = x * nav.Rows + y;
                        buffer[x, y] = nav.SelectedIndex == v ? 'S' : v;
                    }
                }

                for (int x = 0;  x < nav.Rows;  x++) {
                    for (int y = 0; y < nav.Columns; y++) {
                        Console.Write(buffer[y, x] == 83 ? "P ," : buffer[y, x] + " ,");
                    }
                    Console.WriteLine();
                }

                //movement.DoesMove(player, inputManager);

                //for (int i = 0; i < 10; i++) {
                //    for (int j = 0; j < 10; j++) {
                //        if (i == player.posY && j == player.posX) {
                //            Console.Write("0");
                //        } else {
                //            Console.Write(".");
                //        }
                //    }
                //    Console.WriteLine();
                //}

                Thread.Sleep(250);
                Console.Clear();
            }



            //Menu menu = new Menu();
            //GooflingData grayanData = resources.GetGooflingData(GooflingType.Grayan);
            //grayanData.Level = 20;
            //Goofling grayan = new(grayanData);
            //GooflingData danyData = resources.GetGooflingData(GooflingType.Radany);
            //danyData.CurrentHP = 0.8252427f;

            //danyData.Level = 32;
            //Goofling dany = new(danyData);

            //player.Party.Members.Add(grayan);
            //player.Party.Members.Add(dany);

            //Console.WriteLine(dany);
            //Move move = resources.GetMove(MoveType.Croustifesses);
            //move.OnAction(grayan, dany);
        }
    }
}