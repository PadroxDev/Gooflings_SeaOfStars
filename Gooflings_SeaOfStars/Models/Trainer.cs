using System;
using System.Collections.Generic;

namespace Gooflings
{
    public class Trainer
    {
        public string Name { get; private set; }

        public Trainer(string name)
        {
            Name = name;
        }

        ~Trainer()
        { }
    }
}
