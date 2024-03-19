using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gooflings
{
    public enum ExpRequirement
    {
        Erratic = 600000,
        Fast = 800000,
        Medium_Fast = 1000000,
        Medium_Slow = 1059860,
        Slow = 1250000,
        Fluctuating = 1640000
    }

    public struct GooflingData
    {
        public string Name;
        public int Level;
        public int Exp;
        public ExpRequirement ExpRequirement;
        public int MaxHP;
        public int HP;
        public int MaxMana;
        public int Mana;
        public int Attack;
        public int Defense;
        public int SpAttack;
        public int SpDef;
        public int Speed;
        // Moves
    }

    public class Goofling
    {
        public string Name { get; private set; }

        // Types

        public int Level { get; private set; }
        public int Exp { get; private set; }
        public ExpRequirement ExpRequirement { get; private set; }
        public int MaxHP { get; private set; }
        public int HP { get; private set; }
        public int MaxMana { get; private set; }
        public int Mana { get; private set; }
        public int Attack { get; private set; }
        public int Defense { get; private set; }
        public int SpAtk { get; private set; }
        public int SpDef { get; private set; }
        public int Speed { get; private set; }

        // Moves
    }
}
