using System;
using System.Collections.Generic;
using System.Linq;

namespace Gooflings {
    public  class NavMenu {
        public int SelectedIndex { get; private set; }
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public bool TakeInput = true;

        InputManager _inputManager;

        public NavMenu(InputManager input, int rows, int columns) {
            _inputManager = input;

            SelectedIndex = 0;
            Rows = rows;
            Columns = columns;
        }

        ~NavMenu() {
        }

        public void Update() {
            if (!TakeInput) return;

            if(_inputManager.GetKey(ConsoleKey.RightArrow)) {
                NavigateRightwards();
            }
            if (_inputManager.GetKey(ConsoleKey.LeftArrow)) {
                NavigateLeftwards();
            }
            if (_inputManager.GetKey(ConsoleKey.UpArrow)) {
                NavigateUpwards();
            }
            if (_inputManager.GetKey(ConsoleKey.DownArrow)) {
                NavigateDownwards();
            }
        }

        private int ColsXRows() => Rows * Columns;
        private int GetColOffset() => Rows * GetColCursor();
        private int GetColCursor() => SelectedIndex / Columns;

        private void NavigateUpwards() {
            int tmp = SelectedIndex - GetColOffset() - 1;
            int delta = tmp % Rows;
            SelectedIndex = delta + GetColOffset();
        }

        private void NavigateDownwards() {
            int delta = SelectedIndex - GetColOffset() + 1 % Rows;
            SelectedIndex = delta + GetColOffset();
        }

        private void NavigateRightwards() {
            SelectedIndex = (SelectedIndex + Rows) % ColsXRows();
        }

        private void NavigateLeftwards() {
            int tmp = (SelectedIndex - Rows);
            SelectedIndex = (tmp < 0 ? tmp + ColsXRows() : tmp) % ColsXRows();
        }
    }
}