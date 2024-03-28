using Pastel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gooflings
{
    public class MapTxtReader
    {

        public string txt;
        public Dictionary<char, (int, int, int, int)> _colorDic;
        public Dictionary<string, string[]> _mapsDictionary;

        public MapTxtReader(Dictionary<(int, int, int, int), char> UsedColor)
        {
            _colorDic = new Dictionary<char, (int, int, int, int)>();
            _mapsDictionary = new();

            InverseDictionary(UsedColor);
            SetMapDictionary();
        }

        private void SetMapDictionary()
        {
            DirectoryInfo folder = new DirectoryInfo("../../../MapTxt");
            if (folder.Exists)
            {
                foreach (FileInfo file in folder.GetFiles())
                {
                    string[] map = File.ReadAllLines(file.FullName);
                    string key = file.Name.Substring(0, file.Name.Length - 4);
                    _mapsDictionary.Add(key, map);
                }
            }
        }

        private void InverseDictionary(Dictionary<(int, int, int, int), char> UsedColor)
        {
            foreach (KeyValuePair<(int, int, int, int), char> kvp in UsedColor)
            {
                _colorDic.Add(kvp.Value, kvp.Key);
            }
        }

        public void Draw(Player plr, string map)
        {
            if(_mapsDictionary.TryGetValue(map, out string[] data))
            {
                int originX = (int)Math.Clamp(plr.posX - Console.WindowWidth * 0.5f, 0, 250 - Console.WindowWidth);
                int originY = (int)Math.Clamp(plr.posY - Console.WindowHeight * 0.5f, 0, 150 - Console.WindowHeight);

                for (int x = 0; x < Console.WindowWidth; x++)
                {
                    for (int y = 0; y < Console.WindowHeight; y++)
                    {
                        int mappedX = originX + x;
                        int mappedY = originY + y;
                        char c = data[mappedY][mappedX];
                        if (!_colorDic.TryGetValue(c, out (int, int, int, int) color)) continue;
                        Renderer.RenderBuffer[x, y].BgColor = Color.FromArgb(color.Item1, color.Item2, color.Item3, color.Item4);
                    }
                }
            }
        }
    }
}
