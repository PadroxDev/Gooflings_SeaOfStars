using System;


namespace Gooflings
{

    public class Program
    {
        public static void Main(string[] args)
        {
            MovementPlayer movement = new MovementPlayer();
            Player player = new Player();
            InputManager input = new InputManager();

            while (true)
            {
                bool pressed = Console.KeyAvailable;
                movement.DoesMove(pressed, player, input);

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0;j < 10; j++)
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

        }
    }
}
