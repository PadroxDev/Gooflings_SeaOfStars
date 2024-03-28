using System;

namespace Gooflings
{
    public class Program
    {
        private static int _consoleWidth = 180;
        private static int _consoleHeight = 50;

        public static void Main(string[] args)
        {
            Renderer.Initialize(_consoleWidth, _consoleHeight);

            // Initialization 
            Resources resources = new Resources();
            InputManager inputManager = new InputManager();
            Menu menu = new Menu();
            Player player = new Player();
            MovementPlayer movement = new MovementPlayer();

            // Gameloop
            while (true)
            {
                //    nav.Update();
                //    int[,] buffer = new int[nav.Columns, nav.Rows];

                inputManager.Update();
                movement.DoesMove(player, inputManager);
                player.Draw();
                Renderer.Flush();
                Thread.Sleep(100);

                //for (int x = 0; x < nav.Columns; x++) {
                //    for (int y = 0; y < nav.Rows; y++) {
                //        int v = x * nav.Rows + y;
                //        buffer[x, y] = nav.SelectedIndex == v ? 'S' : v;
                //    }
                //}

                //for (int x = 0;  x < nav.Rows;  x++) {
                //    for (int y = 0; y < nav.Columns; y++) {
                //        Console.Write(buffer[y, x] == 83 ? "P ," : buffer[y, x] + " ,");
                //    }
                //    Console.WriteLine();
                //}
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

                //Thread.Sleep(250);
                //Console.Clear();
                //}

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
            }
            //BattleManager battle = new BattleManager(player, enemy);
            //battle.HandleSpawnGooflings(resources);

            //Console.WriteLine(dany);
            menu.displayMenus();
            
            //Move move = resources.GetMove(MoveType.Croustifesses);
            //move.OnAction(grayan, dany);*/
        }
    }
}