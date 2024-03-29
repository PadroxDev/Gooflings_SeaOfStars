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
                    whathhapen = interaction.CheckInteraction(_plr.posX, _plr.posY - 4, Filename);
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
                    whathhapen = interaction.CheckInteraction(_plr.posX - 2, _plr.posY, Filename);
                    if (whathhapen != "Not-Walkable")
                    {
                        return true;
                    }
                    return false;
                case "RIGHT":
                    whathhapen = interaction.CheckInteraction(_plr.posX + 2, _plr.posY, Filename);
                    if (whathhapen != "Not-Walkable")
                    {
                        return true;
                    }
                    return false;
            }
            return false;
        }

        public string DoInteraction(string filename, Menu menu, string map, ref GameState gamestate) 
        {

            Filename = filename;

            string whathhapen = interaction.CheckInteraction(_plr.posX, _plr.posY, Filename); 

            switch (whathhapen)
            {
                case "To-Desert":
                    _plr.posX = 240;
                    _plr.posY = 45;
                    map = "Desert";
                    DoesMove();
                    return map;

                case "To-Forest":
                    _plr.posX = 10;
                    _plr.posY = 18;
                    map = "Forest";
                    DoesMove();
                    return map;

                // Not include for now
                case "To-House" or "To-tippie":
                    // switch buffer to shop
                    DoesMove();
                    return map;

                case "Spawn_Goofling":
                    int i = Helpers.Rand.Next(0, 5);
                    if(i == 4)
                    {
                        gamestate = GameState.Fighting;
                    }
                    DoesMove();
                    return map;

                case "Not-Walkable":
                    DoesMove();
                    return map;

                case "noting":
                    DoesMove();
                    return map;
            }
            return map;
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
                    if (_plr.posY >= 150 - 3) return;
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
                    if (_plr.posX >= 250 - 3) return;
                    _plr.posX++;
                }
            }
        }
    }
}
