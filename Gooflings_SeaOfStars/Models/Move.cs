using System;
using System.Collections.Generic;
using System.Linq;

namespace Gooflings.Moves
{
    public enum MoveType
    {
        Unknown,
        Croustifesses
    }

    public enum MoveCategory
    {
        Physical,
        Special
    }

    public abstract class Move
    {
        public MoveType MoveType { get; protected set; }
        public string Name { get; protected set; }
        public Types AtkType { get; protected set; }
        public MoveCategory MoveCategory {get; protected set; }
        public int Power { get; protected set; }
        public int ManaCost { get; protected set; }
        public int Accuracy { get; protected set; }
        public int CriticalRate { get; protected set; }

        public Move()
        {
            MoveType = MoveType.Unknown;
            Name = "Unknown";
            AtkType = Types.None;
            MoveCategory = MoveCategory.Physical;
            Power = 0;
            ManaCost = 0;
            Accuracy = 100;
            CriticalRate = 20;
        }

        ~Move()
        {}

        public abstract void OnAction(Goofling attacker, Goofling target);
    }
}
