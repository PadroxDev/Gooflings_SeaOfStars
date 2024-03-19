using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gooflings
{
    public class InputManager
    {

        private Dictionary<string, bool> keyList = new Dictionary<string, bool>();
        public InputManager()
        {
           
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


        public void SetKeyState(bool pressed)
        {
            if (pressed)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

                switch (keyList[consoleKeyInfo.Key.ToString()])
                {
                    case false:
                        keyList[consoleKeyInfo.Key.ToString()] = true;
                        Console.WriteLine("false to true");
                        break;
                    case true:
                        keyList[consoleKeyInfo.Key.ToString()] = true;
                        Console.WriteLine("true to true");
                        break;
                }
            }else
            {
                //keyList = keyList.ToDictionary(p => p.Key, p => false);
            }
            
        }
        
    }

}
