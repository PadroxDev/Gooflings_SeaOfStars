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
        public const int MOVE_STEP = 3;

        Interaction interaction;
        InputManager _inputManager;
        Player _plr;

        public MovementPlayer(InputManager input, Player plr)
        {
            _plr = plr;
            _inputManager = input;
            interaction = new Interaction();
        }

        public void DoesMove()
        {
            if(_inputManager.GetKey(ConsoleKey.D) || _inputManager.GetKey(ConsoleKey.RightArrow)) {
                GoRight();
            }
            if (_inputManager.GetKey(ConsoleKey.Q) || _inputManager.GetKey(ConsoleKey.LeftArrow)) {
                GoLeft();
            }
            if (_inputManager.GetKey(ConsoleKey.Z) || _inputManager.GetKey(ConsoleKey.UpArrow)) {
                GoUp();
            }
            if (_inputManager.GetKey(ConsoleKey.S) || _inputManager.GetKey(ConsoleKey.DownArrow)) {
                GoDown();
            }
        }

        public void DoInteraction(Player player, string filename, Menu menu, string map, GameState gamestate) 
        {
            string whathhapen = interaction.CheckInteraction(player.posX, player.posY, filename); 

            switch (whathhapen)
            {
                case "To-Desert":
                    map = "Desert";
                    DoesMove();
                    break ;

                case "To-Forest":
                    map = "Forest";
                    DoesMove();
                    break;
                
                // Not include for now
                 case "To-House" or "To-tippie":
                    // switch buffer to shop
                    DoesMove();
                    break;
                

                case "Spawn_Goofling":
                    int i = Helpers.Rand.Next(0, 5);
                    if(i == 4)
                    {
                        gamestate = GameState.Fighting;
                    }
                    DoesMove();
                    break;

                case "Not-Walkable":
                    break;

                case "noting":
                    DoesMove();
                    break;
            }
        }

        private void GoUp()
        {
            for (int i = 0; i < MOVE_STEP; i++)
            {
                if (_plr.posY <= 0) return;
                _plr.posY--;
            }
        }

        private void GoDown()
        {
            for (int i = 0; i < MOVE_STEP; i++)
            {
                if (_plr.posY >= 150) return;
                _plr.posY++;
            }
        }

        private void GoLeft()
        {
            for (int i = 0; i < MOVE_STEP; i++)
            {
                if (_plr.posX <= 0) return;
                _plr.posX--;
            }
        }

        private void GoRight()
        {
            for (int i = 0; i < MOVE_STEP; i++)
            {
                if (_plr.posX >= 250) return;
                _plr.posX++;
            }
        }
    }
}
