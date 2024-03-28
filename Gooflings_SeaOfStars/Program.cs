using System;
using System.Drawing;
using Gooflings.Moves;
using Pastel;
using static System.Net.Mime.MediaTypeNames;

namespace Gooflings
{

    public class Program
    {
        public struct BufferSlot
        {
            public char Character;
            public Color FgColor;
            public Color BgColor;

            string[] text;
            Dictionary<char, (int, int, int, int)> ColorDic;

            public BufferSlot(char c, Color fg, Color bg)
            {
                Character = c;
                text = File.ReadAllLines("../../../Desert.png.txt");
                FgColor = fg;
                BgColor = bg;
                ColorDic = new()
                {
                    { 'a', (255, 219, 198, 112)},
                    { 'A', (255, 245, 228, 156)},
                    { 'b', (255, 209, 194, 132)},
                    { 'B', (255, 163, 196, 84)},
                    { 'c', (255, 153, 217, 234)},
                    { 'C', (255, 156, 90, 60) },
                    { 'd', (255, 153, 0, 48) },
                    { 'D', (255, 209, 33, 42) },
                    { 'e', (255, 237, 28, 36) },
                    { 'E', (255, 255, 48, 59) },
                    { 'f', (255, 0, 0, 0) }
                };
            }

            public BufferSlot() : this(' ', Color.FromName("White"), Color.FromName("Black")) { }
        }

        public class Renderer
        {
            private static Renderer _instance;

            static public BufferSlot[,] RenderBuffer;

            public int ViewportWidth { get; private set; }
            public int ViewportHeight { get; private set; }

            public Renderer(int width, int height)
            {
                Console.SetWindowSize(width, height);
                Console.BufferWidth = width;
                Console.BufferHeight = height;

                ViewportWidth = width;
                ViewportHeight = height;

                RenderBuffer = new BufferSlot[ViewportHeight, ViewportWidth];
                for (int i = 0; i < ViewportHeight; i++)
                {
                    for (int j = 0; j < ViewportWidth; j++)
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
                /*for (int i = 0; i < _instance.ViewportHeight - 1; i++)
                {
                    for (int j = 0; j < _instance.ViewportWidth; j++)
                    {
                        BufferSlot slot = RenderBuffer[i, j];
                        char c = slot.Character;
                        Color fg = slot.FgColor;
                        Color bg = slot.BgColor;
                        Console.Write(c.ToString().Pastel(fg).PastelBg(bg));
                    }
                }*/
                for (int y = 0; y < _instance.ViewportHeight; y++)
                {
                    for (int x = 0; x < _instance.ViewportWidth * 2; x++)
                    {
                        int xMapped = (int)(posX + x - _instance.ViewportWidth * 0.5f);
                        int yMapped = (int)(posY + y - _instance.ViewportHeight * 0.5f);
                        char c = text[yMapped][xMapped];
                        if (!ColorDic.TryGetValue(c, out (int, int, int, int) coco)) continue;
                        var color = coco;
                        Console.Write(c.ToString().Pastel(Color.FromArgb(color.Item1 - 10, color.Item2, color.Item3, color.Item4)).PastelBg(Color.FromArgb(color.Item1, color.Item2, color.Item3, color.Item4)));
                    }
                }
                Console.WriteLine();
            }
        }
        public static void Main(string[] args)
        {

            Console.Title = "Gooflings";

            Renderer.Initialize(150, 50);

            while(true)
            {
                Renderer.Flush();
                Thread.Sleep(2000);
                Console.Clear();
            }
            
            //Dictionary<(int, int, int, int), char> UsedColor = new Dictionary<(int, int, int, int), char>();
            //MovementPlayer movement = new MovementPlayer();
            //InputManager input = new InputManager();
            //MapPngReader img = new MapPngReader(UsedColor);
            //MapTxtReader text = new MapTxtReader(UsedColor);

            /*
            while (true)
            {
                bool pressed = Console.KeyAvailable;
                movement.DoesMove(pressed, player, input);

                for (int i = 0; i < Console.WindowHeight; i++)
                {
                    for (int j = 0;j < Console.WindowWidth; j++)
                    {
                        if (i == player.posY && j == player.posX)
                        {
                            Console.Write("0");
                        }
                        else
                        {
                            Console.Write(".");
                        }
            //while (true)
            //{
            //    bool pressed = Console.KeyAvailable;
            //    movement.DoesMove(pressed, player, input);

            //    for (int i = 0; i < 10; i++)
            //    {
            //        for (int j = 0;j < 10; j++)
            //        {
            //            if (i == player.posY && j == player.posX)
            //            {
            //                Console.Write("0");
            //            }
            //            else
            //            {
            //                Console.Write(".");
            //            }                     
            //        } 
            //        Console.WriteLine();
            //    }

            //    Thread.Sleep(1000);
            //    Console.Clear();

            //}

            
            Resources resources = new Resources();
            Menu menu = new Menu();
            Player player = new Player();

            Trainer enemy = new Trainer(resources.GetTrainerData(TrainerType.Alice));

            GooflingData grayanData = resources.GetGooflingData(GooflingType.Grayan);
            grayanData.Level = 20;
            Goofling grayan = new(grayanData);

            GooflingData danyData = resources.GetGooflingData(GooflingType.Radany);
            danyData.CurrentHP = 0.8252427f;
            danyData.Level = 32;
            Goofling dany = new(danyData);

            player.Party.Members.Add(grayan);
            player.Party.Members.Add(dany);

            BattleManager battle = new BattleManager(player, enemy);
            battle.HandleSpawnGooflings(resources);

            //Console.WriteLine(dany);
            //Move move = resources.GetMove(MoveType.Croustifesses);
            //move.OnAction(grayan, dany);*/
        }
    }
}