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
        public Dictionary<char, (int, int, int, int)> ColorDic;

        public MapTxtReader(Dictionary<(int, int, int, int), char> UsedColor)
        {
            ColorDic = new Dictionary<char, (int, int, int, int)>();

            foreach (KeyValuePair<(int, int, int, int), char> kvp in UsedColor)
            {
                ColorDic.Add(kvp.Value, kvp.Key);
            }

            MapTxtRead(ColorDic);
        }

        public void MapTxtRead(Dictionary<char, (int, int, int, int)> ColorDic) 
        {
            DirectoryInfo folder = new DirectoryInfo("../../../MapTxt");
            if (folder.Exists)
            {
                foreach (FileInfo file in folder.GetFiles())
                {
                    string[] text = File.ReadAllLines(file.FullName);
                    
                    // les lignes s'affiche mal car avec les lettres il faut une windows size de 250 par 50 pour afficher une ligne entiere

                    foreach( string line in text)
                    {
                        foreach (char c in line.Substring(0,180))
                        {
                            if (ColorDic.TryGetValue(c, out (int, int, int, int) list))
                            {
                                Console.Write(c.ToString().Pastel(Color.FromArgb(list.Item1 - 10, list.Item2, list.Item3, list.Item4)).PastelBg(Color.FromArgb(list.Item1, list.Item2, list.Item3, list.Item4)));
                            }
                        }

                        Console.WriteLine();

                    }
                }
            }
        }
    }
}
