using System;
using System.Collections.Generic;
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

        public Party Party { get; private set; }

        public Player()
        {
            posX = 0;
            posY = 0;
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
            for (int i = 0; i < _pattern.GetLength(0); i++)
            {
                for (int j = 0; j < _pattern.GetLength(1); j++)
                {
                    Renderer.RenderBuffer[posX + j, posY + i].Character = _pattern[i, j];
                }
            }
        }
    }
}
