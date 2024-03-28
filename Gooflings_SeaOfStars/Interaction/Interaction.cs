using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gooflings
{
    public class Interaction
    {

        public Interaction() 
        {
        
        }

        public string CheckInteraction(int posX, int posY, string filename)
        {
            string Map = File.ReadAllText(filename);

            switch(Map[posX + posY]) 
            {

                case '1':
                    return "To-Desert";

                case '2':
                    return "To-Forest";

                case '3':
                    return "To-House";

                case '4':
                    return "To-Tippie";

                case '5':
                    return "Spawn_Goofling";

                case '/':
                    return "Not-Walkable";

                case '.':
                    return "noting";

            }

            return "error";

        }

    }
}
