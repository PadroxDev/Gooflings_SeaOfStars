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
        string Filename;

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

        public bool IsWalkable(string Direction)
        {
            string whathhapen;
            switch (Direction)
            {
                case "UP":
                    whathhapen = interaction.CheckInteraction(_plr.posX, _plr.posY - 1, Filename);
                    if (whathhapen != "Not-Walkable")
                    {
                        
                        return true;
                    }
                    return false;
                case "DOWN":
                    whathhapen = interaction.CheckInteraction(_plr.posX, _plr.posY + 4, Filename);
                    if (whathhapen != "Not-Walkable")
                    {
                        return true;
                    }
                    return false;
                case "LEFT":
                    whathhapen = interaction.CheckInteraction(_plr.posX - 1, _plr.posY, Filename);
                    if (whathhapen != "Not-Walkable")
                    {
                        return true;
                    }
                    return false;
                case "RIGHT":
                    whathhapen = interaction.CheckInteraction(_plr.posX + 4, _plr.posY, Filename);
                    if (whathhapen != "Not-Walkable")
                    {
                        return true;
                    }
                    return false;
            }
            return false;
        }

        public void DoInteraction(string filename, Menu menu, string map, GameState gamestate) 
        {

            Filename = filename;

            string whathhapen = interaction.CheckInteraction(_plr.posY, _plr.posY, Filename); 

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
                    DoesMove();
                    break;

                case "noting":
                    DoesMove();
                    break;
            }
        }

        private void GoUp()
        {
            if (IsWalkable("UP"))
            {
                for (int i = 0; i < MOVE_STEP; i++)
                {
                    if (_plr.posY <= 0) return;
                    _plr.posY--;
                }
            }
            
        }

        private void GoDown()
        {
            if (IsWalkable("DOWN"))
            {
                for (int i = 0; i < MOVE_STEP; i++)
                {
                    if (_plr.posY >= 150) return;
                    _plr.posY++;
                }
            }
            
        }

        private void GoLeft()
        {
            if (IsWalkable("LEFT"))
            {
                for (int i = 0; i < MOVE_STEP; i++)
                {
                    if (_plr.posX <= 0) return;
                    _plr.posX--;
                }
            }
            
        }

        private void GoRight()
        {
            if (IsWalkable("RIGHT"))
            {
                for (int i = 0; i < MOVE_STEP; i++)
                {
                    if (_plr.posX >= 250) return;
                    _plr.posX++;
                }
            } 
        }
    }
}
