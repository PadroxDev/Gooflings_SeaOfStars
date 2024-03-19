using Gooflings;
using System;


namespace Gooflings
{

    public class Program
    {
        public static void Main(string[] args)
        {
            InputManager input = new InputManager();

            while (true)
            {
                bool pressed = Console.KeyAvailable;

                input.SetKeyState(pressed);

            }

        }
    }
}
