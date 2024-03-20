using System;
using System.Collections.Generic;
using System.Linq;
using Gooflings.Moves;

namespace Gooflings
{
    public class Resources
    {
        public static Resources Instance { get; private set; }

        public List<GooflingData> GooflingsData { get; private set; } = new()
        {
            new GooflingData()
            {
                GooflingType = GooflingType.Grayan,
                Name = "Grayan",
                PrimaryType = Types.Food,
                ExpRequirement = ExpRequirement.Fluctuating,
                MaxHP = 1000,
                HP = 1000,
                MaxMana = 1000,
                Mana = 1000,
                Attack = 40,
                Defense = 30,
                SpAtk = 2,
                SpDef = 40,
                Speed = 2,
                Moves = new MoveType[4]
                {
                    MoveType.Croustifesses,
                    MoveType.Unknown,
                    MoveType.Unknown,
                    MoveType.Unknown
                }
            },

            new GooflingData()
            {
                GooflingType = GooflingType.Radany,
                Name = "Radany",
                PrimaryType = Types.Caillou,
                SecondaryType = Types.Food,
                ExpRequirement = ExpRequirement.Slow,
                MaxHP = 1200,
                HP = 1200,
                MaxMana = 700,
                Mana = 700,
                Attack = 5,
                Defense = 40,
                SpAtk = 1,
                SpDef = 10,
                Speed = 1,
                Moves = new MoveType[4]
                {
                    MoveType.Croustifesses,
                    MoveType.Unknown,
                    MoveType.Unknown,
                    MoveType.Unknown
                }
            }
        };
        private Dictionary<GooflingType, GooflingData> _GooflingsDataDict;

        public List<Move> MovesData { get; private set; } = new()
        {
            new Croustifesses(),
        };
        private Dictionary<MoveType, Move> _MovesDataDict;

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
            _MovesDataDict = MovesData.ToDictionary(m => m.MoveType, m => m);
        }

        public GooflingData GetGooflingData(GooflingType type) => _GooflingsDataDict[type];
        public Move GetMove(MoveType type) => _MovesDataDict[type];
    }
}
