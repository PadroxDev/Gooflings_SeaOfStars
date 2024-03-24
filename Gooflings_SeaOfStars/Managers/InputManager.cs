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
            keyList = new Dictionary<string, bool>();

            keyList.Add("Escape", false);
            keyList.Add("Enter", false);

            keyList.Add("Z", false);
            keyList.Add("S", false);
            keyList.Add("Q", false);
            keyList.Add("D", false);

            keyList.Add("UpArrow", false);
            keyList.Add("DownArrow", false);
            keyList.Add("LeftArrow", false);
            keyList.Add("RightArrow", false);
        }

        public string SetKeyState(bool pressed)
        {
            if (pressed)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);

                switch (keyList[consoleKeyInfo.Key.ToString()])
                {
                    case false: // down -> true
                        keyList[consoleKeyInfo.Key.ToString()] = true;
                        return consoleKeyInfo.Key.ToString();
                    case true: // hold -> true
                        keyList[consoleKeyInfo.Key.ToString()] = true;
                        return consoleKeyInfo.Key.ToString();
                }
            }
            else // up -> reset
            {
                // comment faire pour que ce s'active que quand la touche est lacher 

                keyList = keyList.ToDictionary(p => p.Key, p => false);

                return "no";

            }

        }

    }

}
