using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gooflings
{
    public class MovementPlayer
    {
        Interaction interaction;

        public MovementPlayer()
        {
            interaction = new Interaction();

        }

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

        public void DoInteraction(int posX, int posY, string filename) 
        {
            string whathhapen = interaction.CheckInteraction(posX, posY, filename); 

            switch (whathhapen)
            {
                case "To-Desert":
                    // switch buffer to desert map
                    break ;

                case "To-Forest":
                    // switch buffer to forest map
                    break;

                case "To-House" or "To-tippie":
                    // switch buffer to shop
                    break;

                case "noting":
                    break;
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
