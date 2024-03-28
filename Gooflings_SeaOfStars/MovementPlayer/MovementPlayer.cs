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

        private void GoUp()
        {
            if (_plr.posY > 0)
            {
                _plr.posY--;
            }
            
        }

        private void GoDown()
        {
            if(_plr.posY < 10)
            {
                _plr.posY++;
            }
            
        }

        private void GoLeft()
        {
            if (_plr.posX > 0)
            {
                _plr.posX--;
            }
            
        }

        private void GoRight()
        {
            if (_plr.posX < 10)
            {
                _plr.posX++;
            }
            
        }
    }
}
