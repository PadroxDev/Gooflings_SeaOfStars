using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gooflings
{
    public class MovementPlayer
    {

        public MovementPlayer()
        {

        }
        /*
        public void DoesMove(bool pressed, Player player, InputManager input)
        {
            string key = input.SetKeyState(pressed);
            if (key != "no")
            {
                switch (key)
                {
                    case "Z":
                        GoUp(player);
                        break;
                    case "S":
                        GoDown(player);
                        break;
                    case "Q":
                        GoLeft(player);
                        break;
                    case "D":
                        GoRight(player);
                        break;
                }
            }
        }
        */
        private void GoUp(Player player)
        {
            if (player.posY > 0)
            {
                player.posY--;
            }
            
        }

        private void GoDown(Player player)
        {
            if(player.posY < 10)
            {
                player.posY++;
            }
            
        }

        private void GoLeft(Player player)
        {
            if (player.posX > 0)
            {
                player.posX--;
            }
            
        }

        private void GoRight(Player player)
        {
            if (player.posX < 10)
            {
                player.posX++;
            }
            
        }
    }
}
