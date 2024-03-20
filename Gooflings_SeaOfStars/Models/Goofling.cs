using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Gooflings
{
    public enum GooflingType
    {
        Unknown,
        Grayan,
        Radany
    }

    public struct GooflingData
    {
        public GooflingType GooflingType;
        public string Name;
        public Type PrimaryType;
        public Type SecondaryType;
        public int Level;
        public int Exp;
        public ExpRequirement ExpRequirement;
        public int MaxHP;
        public int HP;
        public int MaxMana;
        public int Mana;
        public int Attack;
        public int Defense;
        public int SpAtk;
        public int SpDef;
        public int Speed;
        // Moves

        public GooflingData()
        {
            GooflingType = GooflingType.Unknown;
            Name = "Unknown";
            PrimaryType = Type.None;
            SecondaryType = Type.None;
            Level = 1;
            Exp = 0;
            ExpRequirement = ExpRequirement.Fast;
            MaxHP = 100;
            HP = MaxHP;
            MaxMana = 100;
            Mana = MaxMana;
            Attack = 1;
            Defense = 1;
            SpAtk = 1;
            SpDef = 1;
            Speed = 1;
        }
    }

    public class Goofling
    {
        public GooflingType GooflingType { get; private set; }
        public string Name { get; private set; }
        public Type PrimaryType { get; private set; }
        public Type SecondaryType { get; private set; }
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

        #region Events

        public Action<float> OnExpEarned;
        public Action<int> OnLevelUp;

        public Action<int> OnReceiveHealing;
        public Action<int> OnTakeDamage;
        public Action OnKnockOut;
        
        #endregion

        public Goofling(GooflingData data)
        {
            GooflingType = data.GooflingType;
            Name = data.Name;
            PrimaryType = data.PrimaryType;
            SecondaryType = data.SecondaryType;
            Level = data.Level;
            Exp = data.Exp;
            ExpRequirement = data.ExpRequirement;
            MaxHP = data.MaxHP;
            HP = data.HP;
            MaxMana = data.MaxMana;
            Mana = data.Mana;
            Attack = data.Attack;
            Defense = data.Defense;
            SpAtk = data.SpAtk;
            SpDef = data.SpDef;
            Speed = data.Speed;
        }

        #region HP

        public void ReceiveHealing(int amount)
        {
            int previousHP = HP;
            HP = Math.Clamp(HP + amount, 0, MaxHP);
            OnReceiveHealing?.Invoke(HP - previousHP);
        }

        public void TakeDamage(int amount)
        {
            int previousHP = HP;
            HP = Math.Clamp(HP - amount, 0, MaxHP);
            OnTakeDamage?.Invoke(previousHP - HP);

            Console.WriteLine($"{Name} has {HP} / {MaxHP} now !");

            if (HP <= 0) Faint();
        }

        public void Faint()
        {
            Console.WriteLine($"{Name} fainted !");
            OnKnockOut?.Invoke();
        }

        #endregion

        #region Experience

        private void AttemptLevelUp()
        {
            if (Level >= Helpers.MAX_LEVEL) return;

            int expRequired = ExpRequirement.GetExpRequired(Level);
            while (expRequired <= Exp)
            {
                Exp -= expRequired;
                Level++;
                OnLevelUp?.Invoke(Level);

                Console.WriteLine($"{Name} is now level {Level} !");

                expRequired = ExpRequirement.GetExpRequired(Level);
                if (Level >= Helpers.MAX_LEVEL) break;
            }
        }

        public void GainExperience(int amount)
        {
            if (Level >= Helpers.MAX_LEVEL) return;

            Exp += amount;
            AttemptLevelUp();

            OnExpEarned?.Invoke(amount);
        }

        #endregion
    }
}
