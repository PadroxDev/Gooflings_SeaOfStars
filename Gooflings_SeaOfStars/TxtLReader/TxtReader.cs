using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gooflings
{
    public class TxtReader
    {

        public string txt;

        public TxtReader(string filename)
        {
            txt = TxtRead(filename);
        }

        public string TxtRead(string filename) 
        {
            if (!File.Exists(filename))
            {
                return "error with file";
            }
            else 
            {
                return File.ReadAllText(filename);
            }
        }
    }
}
