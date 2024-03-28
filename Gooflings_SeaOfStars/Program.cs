using System;

namespace Gooflings
{
    public class Program
    {
        private static int _consoleWidth = 180;
        private static int _consoleHeight = 50;
        private static int _mlBetweenFrames = 100;

        public static void Main(string[] args)
        {
            // Initialization
            Renderer.Initialize(_consoleWidth, _consoleHeight);
            GameManager gameManager = new GameManager();

            // Gameloop
            while (true)
            {

                gameManager.Update();
                Thread.Sleep(_mlBetweenFrames);

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

            }
            //BattleManager battle = new BattleManager(player, enemy);
            //battle.HandleSpawnGooflings(resources);

            //Console.WriteLine(dany);
            
            //Move move = resources.GetMove(MoveType.Croustifesses);
            //move.OnAction(grayan, dany);*/
        }
    }
}