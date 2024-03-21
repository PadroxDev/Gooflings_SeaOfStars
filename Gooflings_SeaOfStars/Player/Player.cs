﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gooflings
{
    public class Player
    {
        public float posX;
        public float posY;

        public Party Party { get; private set; }

        public Player()
        {
            posX = 0;
            posY = 0;
            Party = new Party();
        }

    }
}
