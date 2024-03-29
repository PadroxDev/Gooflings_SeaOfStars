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
            int originX = (int)Math.Clamp(posX - Console.WindowWidth * 0.5f, 0, 250 - Console.WindowWidth);
            int originY = (int)Math.Clamp(posY - Console.WindowHeight * 0.5f, 0, 150 - Console.WindowHeight);

            int offsetX = (int)(posX - Console.WindowWidth * 0.5f);
            int offsetY = (int)(posY - Console.WindowHeight * 0.5f);

            int preX = offsetX - originX;
            int preY = offsetY - originY;

            int x = preX + (int)(Console.WindowWidth * 0.5f);
            int y = preY + (int)(Console.WindowHeight * 0.5f);

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
