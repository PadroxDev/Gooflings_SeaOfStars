using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gooflings
{
    public class Player
    {
        public int posX;
        public int posY;

        private char[,] _pattern;

        public string Name;

        //public Dictionary<items, int> inventory;
        //public Dictionary<Goofling, int> CapturedGoofling;
        public Party Party { get; private set; }

        public Player()
        {
            posX = 153;
            posY = 103;
            Party = new Party();

            _pattern = new char[3, 3]
            {
                {'_', 'O', '_',},
                {' ', '|', ' ',},
                {'/', ' ', '\\'}
            };
        }

        public void Draw()
        {
            int x = (int)(Console.WindowWidth * 0.5f - 1);
            int y = (int)(Console.WindowHeight * 0.5f - 1);

            for (int i = 0; i < _pattern.GetLength(0); i++)
            {
                for (int j = 0; j < _pattern.GetLength(1); j++)
                {

                    Renderer.RenderBuffer[x + j, y + i].Character = _pattern[i, j];
                    Renderer.RenderBuffer[x + j, y + i].FgColor = Color.Black;
                }
            }
        }
    }
}
