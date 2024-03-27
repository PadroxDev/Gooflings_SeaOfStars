using System;
using System.Collections.Generic;
using System.Linq;

namespace Gooflings.Systems
{
    public class Renderer
    {
        private static Renderer _instance;

        static public char[][] RenderBuffer;

        public int ViewportWidth { get; private set; }
        public int ViewportHeight { get; private set; }

        public Renderer(int width, int height)
        {
            ViewportWidth = width;
            ViewportHeight = height;

            RenderBuffer = new char[height][];
            for (int i = 0; i < height; i++)
            {
                RenderBuffer[i] = new char[width];
            }

            Console.SetBufferSize(width, height);
            Console.SetWindowSize(width, height);
        }

        public static bool Initialize(int width, int height)
        {
            if (_instance is not null) return false;

            _instance = new Renderer(width, height);
            return true;
        }

        public static void Flush()
        {
            if (_instance is null) return;

            Console.Clear();

            for (int i = 0; i < _instance.ViewportHeight; i++)
            {
                Console.WriteLine(RenderBuffer[i]);
            }
        }

        public static void Clear()
        {
            if(_instance is null) return;

            for (int i = 0; i < _instance.ViewportHeight; i++)
            {
                RenderBuffer[i] = new char[_instance.ViewportWidth];
                for (int j = 0; j < _instance.ViewportWidth; j++)
                {
                    RenderBuffer[i][j] = 'z';
                }
            }
        }
    }
}
