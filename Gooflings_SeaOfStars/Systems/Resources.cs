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
                HP = 80,
                Mana = 1000,
                Attack = 82,
                Defense = 83,
                SpAtk = 100,
                SpDef = 100,
                Speed = 80,
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
                HP = 80,
                Mana = 700,
                Attack = 120,
                Defense = 130,
                SpAtk = 55,
                SpDef = 65,
                Speed = 45,
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

        public List<TrainerData> TrainersData { get; private set; } = new()
        {
            new TrainerData()
            {
                TrainerType = TrainerType.Alice,
                Name = "Alice",
                Party = new TrainerGoofling[2]
                {
                    new TrainerGoofling()
                    {
                        GooflingType = GooflingType.Grayan,
                        Level = 12
                    },
                    new TrainerGoofling()
                    {
                        GooflingType = GooflingType.Radany,
                        Level = 14
                    }
                }
            }
        };
        private Dictionary<TrainerType, TrainerData> _TrainersDataDict;

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
            _TrainersDataDict = TrainersData.ToDictionary(t => t.TrainerType, t => t);
        }

        public GooflingData GetGooflingData(GooflingType type) => _GooflingsDataDict[type];
        public Move GetMove(MoveType type) => _MovesDataDict[type];
        public TrainerData GetTrainerData(TrainerType type) => _TrainersDataDict[type];
    }
}
