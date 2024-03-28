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
    public class MapPngReader
    {
        
        int letterUsed;
        string Alphabet;
        public Dictionary<(int, int, int, int), char> UsedColor { get; private set; }

        public MapPngReader()
        {         
            letterUsed = 0; 
            Alphabet = "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ";
            UsedColor = new();

            DirectoryInfo txtfolder = new DirectoryInfo("../../../MapTxt");
            if (txtfolder.Exists)
            {
                foreach (FileInfo file in txtfolder.GetFiles())
                {
                    file.Delete();
                }
            }

            ImgDirectoryReader(UsedColor);

        }  
        
        public void PngToTxt(string Pngfile, string txtPath)
        {
            Bitmap img = new Bitmap(Pngfile);
            StreamWriter txt = File.CreateText(txtPath);

            for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    (int, int, int, int) list;

                    Color pixel = img.GetPixel(j, i);
                    
                    list = (pixel.A, pixel.R, pixel.G, pixel.B);

                    if (UsedColor.TryGetValue(list,out char c))
                    {
                        txt.Write(c);
                    }
                    else
                    {
                        UsedColor.Add(list, Alphabet[letterUsed]);
                        txt.Write(Alphabet[letterUsed]);
                        letterUsed++;
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
                    string fileName = file.Name.Substring(0, file.Name.Length-4);
                    string txtname = "../../../MapTxt/" + fileName + ".txt";
                    PngToTxt(file.FullName, txtname);
                }  
            }
        }
    }

    
}
