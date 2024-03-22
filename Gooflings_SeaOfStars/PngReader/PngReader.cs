using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Collections.Immutable;

namespace Gooflings
{
    public class PngReader
    {
        
        int letterUsed;
        string Alphabet;

        public PngReader(Dictionary<(int, int, int, int), char> UsedColor)
        {         
            letterUsed = 0; 
            Alphabet = "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ";

            ImgDirectoryReader(UsedColor);

        }  
        
        public void PngToTxt(string Pngfile, string txtPath, Dictionary<(int, int, int, int), char> UsedColor)
        {
            Bitmap img = new Bitmap(Pngfile);
            StreamWriter txt = File.CreateText(txtPath);

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    (int, int, int, int) list;

                    Color pixel = img.GetPixel(i, j);
                    
                    list = (pixel.A, pixel.R, pixel.G, pixel.B);

                    if (UsedColor.TryGetValue(list,out char c))
                    {
                        txt.Write(c);
                        txt.Write(" ");
                    }
                    else
                    {
                        UsedColor.Add(list, Alphabet[letterUsed]);
                        letterUsed++;
                        txt.Write(Alphabet[letterUsed]);
                        txt.Write(" ");
                    }
                }
                txt.Write('\n');
            }
            txt.Close();
        }

        public void ImgDirectoryReader(Dictionary<(int, int, int, int), char> UsedColor)
        {
            DirectoryInfo folder = new DirectoryInfo("../../../img");
            if (folder.Exists)
            {
                foreach (FileInfo file in folder.GetFiles())
                {
                    string txtname = "../../../Txt/" + file.Name + ".txt";
                    PngToTxt(file.FullName, txtname, UsedColor);
                }  
            }
        }
    }

    
}
