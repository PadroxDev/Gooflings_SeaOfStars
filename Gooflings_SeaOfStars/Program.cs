using System;
using Gooflings.Moves;

namespace Gooflings
{

    public class Program
    {
        public static void Main(string[] args)
        {
            //Console.SetWindowSize(240, 62);
            //Console.SetBufferSize(240, 62);

            // width = 180
            // heigh = 50

            Console.Title = "Gooflings";
            Dictionary<(int, int, int, int), char> UsedColor = new Dictionary<(int, int, int, int), char>();
            MovementPlayer movement = new MovementPlayer();
            Player player = new Player();
            InputManager input = new InputManager();
            MapPngReader img = new MapPngReader(UsedColor);
            MapTxtReader text = new MapTxtReader(UsedColor);

            /*
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
            danyData.CurrentHP = 0.8252427f;

            danyData.Level = 32;
            Goofling dany = new(danyData);
            Move move = resources.GetMove(MoveType.Croustifesses);
            move.OnAction(grayan, dany);*/
            //player.Party.Members.Add(grayan);
            //player.Party.Members.Add(dany);
            //Console.WriteLine(dany);
            //Move move = resources.GetMove(MoveType.Croustifesses);
            //move.OnAction(grayan, dany);
        }
    }
}