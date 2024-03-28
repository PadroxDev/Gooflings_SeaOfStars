using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Gooflings {
    public enum KeyState {
        Up,
        Pressed,
        Down,
        Released
    }

    public class InputManager {
        private Dictionary<ConsoleKey, KeyState> _keyDict;
            keyList = new Dictionary<string, bool>();
        public InputManager() {
            _keyDict = new();

            foreach (ConsoleKey key in Enum.GetValues(typeof(ConsoleKey))) {
                _keyDict[key] = KeyState.Up;
            }
        }

        void UpdatePressedKey(ConsoleKey key) {
            switch (_keyDict[key]) {
                case KeyState.Up:
                case KeyState.Released:
                    _keyDict[key] = KeyState.Pressed;
                    break;
                case KeyState.Pressed:
                    _keyDict[key] = KeyState.Down;
                    break;
                default:
                    break;
            }
        }
        }
        private void UpdateRemainingKey(ConsoleKey key) {
            switch (_keyDict[key]) {
                case KeyState.Pressed:
                case KeyState.Down:
                    _keyDict[key] = KeyState.Released;
                    break;
                case KeyState.Released:
                    _keyDict[key] = KeyState.Up;
                    break;
                default:
                    break;
            }
        }

        public void Update() {
            List<ConsoleKey> keysToHandle = _keyDict.Where(p => p.Value != KeyState.Up)
                .ToDictionary(p => p.Key, p => p.Value).Keys.ToList();
                // comment faire pour que ce s'active que quand la touche est lacher 
            while (Console.KeyAvailable) {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyList = keyList.ToDictionary(p => p.Key, p => false);
                keyList = keyList.ToDictionary(p => p.Key, p => false);

                if (keysToHandle.Contains(keyInfo.Key))
                    keysToHandle.Remove(keyInfo.Key);

                UpdatePressedKey(keyInfo.Key);
            foreach (var key in keysToHandle) {
                UpdateRemainingKey(key);
            }
            }

        }

        public bool GetKeyDown(ConsoleKey key) => _keyDict[key] == KeyState.Pressed;
        public bool GetKeyUp(ConsoleKey key) => _keyDict[key] == KeyState.Released;
        public bool GetKey(ConsoleKey key) => _keyDict[key] == KeyState.Pressed || _keyDict[key] == KeyState.Down;
    }
}
