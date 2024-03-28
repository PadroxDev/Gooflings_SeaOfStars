using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

        public void DoesMove(Player player, InputManager input)
        {
            if (input.GetKey(ConsoleKey.D) || input.GetKey(ConsoleKey.RightArrow))
            {
                GoRight(player);
            }
            if (input.GetKey(ConsoleKey.Q) || input.GetKey(ConsoleKey.LeftArrow))
            {
                GoLeft(player);
            }
            if (input.GetKey(ConsoleKey.Z) || input.GetKey(ConsoleKey.UpArrow))
            {
                GoUp(player);
            }
            if (input.GetKey(ConsoleKey.S) || input.GetKey(ConsoleKey.DownArrow))
            {
                GoDown(player);
            }
        }

        public void DoInteraction(Player player, string filename, InputManager input, Menu menu) 
        {
            string whathhapen = interaction.CheckInteraction(player.posX, player.posY, filename); 

            switch (whathhapen)
            {
                case "To-Desert":
                    // switch buffer to desert map
                    DoesMove(player, input);
                    break ;

                case "To-Forest":
                    // switch buffer to forest map
                    DoesMove(player, input);
                    break;

                case "To-House" or "To-tippie":
                    // switch buffer to shop
                    DoesMove(player, input);
                    break;

                case "Spawn_Goofling":
                    // random spawn 
                    // start fight
                    menu.DrawBattleMenu();
                    break;

                case "Not-Walkable":
                    break;

                case "noting":
                    DoesMove(player, input);
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
            if(player.posY < 50)
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
            if (player.posX < 180)
            {
                player.posX++;
            }
            
        }
    }
}
