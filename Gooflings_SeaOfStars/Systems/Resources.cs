using System;
using System.Collections.Generic;
using System.Linq;

namespace Gooflings
{
    public class Resources
    {
        public static Resources Instance { get; private set; }

        public Resources() {
            if (Instance is not null) return;
            Instance = this;

            AssembleResources();
        }

        ~Resources()
        {}

        public void AssembleResources()
        {

        }

        // Getters
    }
}
