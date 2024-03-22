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
    public class TxtReader
    {

        public string txt;
        public Dictionary<char, (int, int, int, int)> ColorDic;

        public TxtReader(Dictionary<(int, int, int, int), char> UsedColor)
        {
            ColorDic = new Dictionary<char, (int, int, int, int)>();

            foreach (KeyValuePair<(int, int, int, int), char> kvp in UsedColor)
            {
                ColorDic.Add(kvp.Value, kvp.Key);
            }

            TxtRead(ColorDic);
        }

        public void TxtRead(Dictionary<char, (int, int, int, int)> ColorDic) 
        {
            DirectoryInfo folder = new DirectoryInfo("../../../Txt");
            if (folder.Exists)
            {
                foreach (FileInfo file in folder.GetFiles())
                {
                    string[] text = File.ReadAllLines(file.FullName);

                    foreach( string line in text)
                    {
                        foreach (char c in line)
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
