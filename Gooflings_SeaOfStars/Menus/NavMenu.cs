using System;
using System.Collections.Generic;
using System.Linq;

namespace Gooflings {
    public abstract class NavMenu {
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public NavMenu(int rows, int columns) {
            Rows = rows;
            Columns = columns;
        }

        ~NavMenu() {
        }
    }
}