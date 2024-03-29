using System;

namespace Gooflings
{
    public class Program
    {
        private static int _consoleWidth = 180;
        private static int _consoleHeight = 50;
        private static int _mlBetweenFrames = 50;

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
            }
            //BattleManager battle = new BattleManager(player, enemy);
            //battle.HandleSpawnGooflings(resources);

            //Console.WriteLine(dany);
            
            //Move move = resources.GetMove(MoveType.Croustifesses);
            //move.OnAction(grayan, dany);*/
        }
    }
}