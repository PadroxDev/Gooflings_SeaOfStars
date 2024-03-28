using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using Gooflings.Moves;

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
        [JsonInclude] public GooflingType GooflingType;
        public string Name;
        public Types PrimaryType;
        public Types SecondaryType;
        [JsonInclude] public int Level;
        [JsonInclude] public int Exp;
        public ExpRequirement ExpRequirement;
        public int HP;
        public float CurrentHP;
        public int Mana;
        public float CurrentMana;
        public int Attack;
        public int Defense;
        public int SpAtk;
        public int SpDef;
        public int Speed;
        public MoveType[] Moves;

        public GooflingData()
        {
            GooflingType = GooflingType.Unknown;
            Name = "Unknown";
            PrimaryType = Types.None;
            SecondaryType = Types.None;
            Level = 1;
            Exp = 0;
            ExpRequirement = ExpRequirement.Fast;
            HP = 11;
            CurrentHP = 1f;
            Mana = 100;
            CurrentMana = 1f;
            Attack = 1;
            Defense = 1;
            SpAtk = 1;
            SpDef = 1;
            Speed = 1;
            Moves = new MoveType[4]
            {
                MoveType.Unknown,
                MoveType.Unknown,
                MoveType.Unknown,
                MoveType.Unknown
            };
        }
    }

    public class Goofling
    {
        public GooflingType GooflingType { get; private set; }
        public string Name { get; private set; }
        public Types PrimaryType { get; private set; }
        public Types SecondaryType { get; private set; }
        public int Level { get; private set; }
        public int Exp { get; private set; }
        public ExpRequirement ExpRequirement { get; private set; }
        public int MaxHP { get; private set; }
        public int HP { get; private set; }
        public int MaxMana { get; private set; }
        public int Mana { get; set; }
        public int Attack { get; private set; }
        public int Defense { get; private set; }
        public int SpAtk { get; private set; }
        public int SpDef { get; private set; }
        public int Speed { get; private set; }
        public MoveType[] Moves { get; private set; }

        #region Events

        public event Action<float> OnExpEarned;
        public event Action<int> OnLevelUp;

        public event Action<int> OnReceiveHealing;
        public event Action<int> OnTakeDamage;
        public event Action OnFaint;
        
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
            MaxHP = Helpers.CalculateHpByLevel(data.HP, data.Level);
            HP = (int)Math.Round(MaxHP * data.CurrentHP);
            MaxMana = Helpers.CalculateStatByLevel(data.Mana, data.Level);
            Mana = (int)Math.Round(MaxMana * data.CurrentMana);
            Attack = Helpers.CalculateStatByLevel(data.Attack, data.Level);
            Defense = Helpers.CalculateStatByLevel(data.Defense, data.Level);
            SpAtk = Helpers.CalculateStatByLevel(data.SpAtk, data.Level);
            SpDef = Helpers.CalculateStatByLevel(data.SpDef, data.Level);
            Speed = Helpers.CalculateStatByLevel(data.Speed, data.Level);
        }

        public override string ToString()
        {
            int requiredExp = ExpRequirement.GetExpRequired(Level);
            return $" Goofling Name: {Name}\n Types: " + (SecondaryType == Types.None ? PrimaryType : (PrimaryType + " - " + SecondaryType)) + $"\n Level: {Level}  Level progession: {Exp}/{requiredExp}\n\n Hp: {HP}/{MaxHP}\n Mana: {Mana}/{MaxMana}\n\n Attack: {Attack}\n Defense: {Defense}\n Sp.Atk: {SpAtk}\n Sp.Def: {SpDef}\n Speed: {Speed}";
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
            OnFaint?.Invoke();
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
