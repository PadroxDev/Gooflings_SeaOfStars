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

        public void DoesMove(Player player, InputManager input)
        {
            if(input.GetKey(ConsoleKey.D) || input.GetKey(ConsoleKey.RightArrow)) {
                GoRight(player);
            }
            if (input.GetKey(ConsoleKey.Q) || input.GetKey(ConsoleKey.LeftArrow)) {
                GoLeft(player);
            }
            if (input.GetKey(ConsoleKey.Z) || input.GetKey(ConsoleKey.UpArrow)) {
                GoUp(player);
            }
            if (input.GetKey(ConsoleKey.S) || input.GetKey(ConsoleKey.DownArrow)) {
                GoDown(player);
            }
        }

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
