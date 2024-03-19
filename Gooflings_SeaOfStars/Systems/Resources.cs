using System;
using System.Collections.Generic;
using System.Linq;

namespace Gooflings
{
    public class Resources
    {
        public static Resources Instance { get; private set; }

        public List<GooflingData> GooflingsData { get; private set; } = new List<GooflingData>()
        {
            new GooflingData()
            {
                GooflingType = GooflingType.Grayan,
                Name = "Grayan",
                PrimaryType = Type.Food,
                ExpRequirement = ExpRequirement.Fluctuating,
                MaxHP = 1000,
                MaxMana = 1000,
                Attack = 15,
                Defense = 30,
                SpAtk = 2,
                SpDef = 40,
                Speed = 2
            },

            new GooflingData()
            {
                GooflingType = GooflingType.Radany,
                Name = "Radany",
                PrimaryType = Type.Caillou,
                SecondaryType = Type.Food,
                ExpRequirement = ExpRequirement.Slow,
                MaxHP = 1200,
                Attack = 5,
                Defense = 60,
                SpAtk = 1,
                SpDef = 10,
                Speed = 1
            }
        };

        private Dictionary<GooflingType, GooflingData> _GooflingsDataDict;

        public Resources() {
            if (Instance is not null) return;
            Instance = this;

            AssembleResources();
        }

        ~Resources()
        {}

        public void AssembleResources()
        {
            // Read from parser ?
            _GooflingsDataDict = GooflingsData.ToDictionary(g => g.GooflingType, g => g);
        }

        public GooflingData GetGooflingData(GooflingType type) => _GooflingsDataDict[type];
    }
}
