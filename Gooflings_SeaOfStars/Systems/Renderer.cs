using Pastel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Gooflings
{
    public struct BufferSlot
    {
        public char Character;
        public Color FgColor;
        public Color BgColor;

        public BufferSlot(char c, Color fg, Color bg)
        {
            Character = c;
            FgColor = fg;
            BgColor = bg;
        }

        public BufferSlot() : this(' ', Color.White, Color.Black) { }
    }

    public class Renderer
    {
        private static Renderer _instance;

        static public BufferSlot[,] RenderBuffer;

        public int ViewportWidth { get; private set; }
        public int ViewportHeight { get; private set; }

        public Renderer(int width, int height)
        {
            Console.Title = "Gooflings";
            Console.SetWindowSize(width, height);
            Console.BufferWidth = width;
            Console.BufferHeight = height;
            Console.CursorVisible = false;

            ViewportWidth = width;
            ViewportHeight = height;

            RenderBuffer = new BufferSlot[ViewportWidth, ViewportHeight];
            for (int i = 0; i < ViewportWidth; i++)
            {
                for (int j = 0; j < ViewportHeight; j++)
                {
                    RenderBuffer[i, j] = new BufferSlot();
                }
            }
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

            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < _instance.ViewportHeight; i++)
            {
                for (int j = 0; j < _instance.ViewportWidth; j++)
                {
                    BufferSlot slot = RenderBuffer[j, i];
                    char c = slot.Character;
                    Color fg = slot.FgColor;
                    Color bg = slot.BgColor;
                    Console.Write(c.ToString().Pastel(fg).PastelBg(bg));
                }
            }

            Clear();
        }

        private static void Clear()
        {
            if (_instance is null) return;

            for (int i = 0; i < _instance.ViewportWidth; i++)
            {
                for (int j = 0; j < _instance.ViewportHeight; j++)
                {
                    RenderBuffer[i, j].Character = ' ';
                    RenderBuffer[i, j].FgColor = Color.White;
                    RenderBuffer[i, j].BgColor = Color.Black;
                }
            }
        }
    }
}
