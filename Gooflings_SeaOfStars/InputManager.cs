using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gooflings
{
    public class InputManager
    {

        private Dictionary<string, bool> keyList;
        public InputManager()
        {
            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                Console.WriteLine(consoleKeyInfo.Key);
            }

            /*keyList.Add("Escape", false);
            keyList.Add("Enter", false);

            keyList.Add("Up", false);
            keyList.Add("Down", false);
            keyList.Add("Left", false);
            keyList.Add("Right", false);

            keyList.Add("ArrowUp", false);
            keyList.Add("ArrowDown", false);
            keyList.Add("ArrowLeft", false);
            keyList.Add("ArrowRight", false);*/

        }

        public bool getKeyDown(string key)
        {
            return keyList.GetValueOrDefault(key);
        }      

    }

}
