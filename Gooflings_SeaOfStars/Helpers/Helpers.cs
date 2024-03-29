﻿using Gooflings.Moves;

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

    public enum Types
    {
        None,
        Food,
        Caillou,
        Code,
        Yordle
    }

    public struct TrainerGoofling
    {
        public GooflingType GooflingType;
        public int Level;

        public TrainerGoofling()
        {
            GooflingType = GooflingType.Unknown;
            Level = 1;
        }
    }

    public static class Helpers
    {
        public const int MAX_LEVEL = 100;
        public const double EXP_EXPONENTIAL_TRIM = 0.7;
        public const double EXP_EXPONENTIAL_OFFSET = 20;

        public const int DEFAULT_IV = 31;

        public static Random Rand = new();

        private static Dictionary<ExpRequirement, int> _totalExpCoefficient = new();
        private static void EvaluateTotalExp(this ExpRequirement expRequirement)
        {
            double total = 0;
            for (int i = 1; i < (MAX_LEVEL+1); i++)
            {
                total += i * (i * EXP_EXPONENTIAL_TRIM) + EXP_EXPONENTIAL_OFFSET;
            }

            _totalExpCoefficient.Add(expRequirement, (int)Math.Round(total));
        }

        private static int GetTotalExp(this ExpRequirement expRequirement)
        {
            if(_totalExpCoefficient.TryGetValue(expRequirement, out int total))
            {
                return total;
            }

            expRequirement.EvaluateTotalExp();
            return _totalExpCoefficient[expRequirement];
        }

        public static int GetExpRequired(this ExpRequirement expRequirement, int currentLevel)
        {
            int totalExp = expRequirement.GetTotalExp();

            double exp = ((currentLevel * (currentLevel * EXP_EXPONENTIAL_TRIM) + EXP_EXPONENTIAL_OFFSET) / totalExp) * (int)expRequirement;
            return (int)Math.Round(exp);
        }

        public static int CalculateStatByLevel(int baseStat, int level) 
        {
            double updatedStat = ((((2f * baseStat + 31f) * level) / 100f) + 5);
            return (int)Math.Floor(updatedStat);
        }

        public static int CalculateHpByLevel(int baseStat, int level)
        {
            double updatedStat = ((((2f * baseStat + 31f) * level) / 100f) + level + 10);
            return (int)Math.Floor(updatedStat);
        }


        public static int CalculateDamageToDeal(Goofling attacker, Goofling target, Move move)
        {
            float atk = move.MoveCategory == MoveCategory.Physical ? attacker.Attack : attacker.SpAtk;
            float def = move.MoveCategory == MoveCategory.Physical ? target.Defense : target.SpDef;

            float criticalHit = RollCriticalHit(attacker) ? 1.5f : 1f;
            float random = Rand.Next(85, 101) * 0.01f;
            float STAB = attacker.PrimaryType == move.AtkType || attacker.SecondaryType == move.AtkType ? 1.5f : 1f;
            float typeEffectiveness = 2f;

            double rawDamage = (((((2f * attacker.Level) / 5f) + 2f) * move.Power * (atk / def)) / 50f)+2f;

            double damage = rawDamage * criticalHit * random * STAB * typeEffectiveness;

            return (int)Math.Floor(damage);
        }

        public static bool RollCriticalHit(Goofling goofling)
        {
            int baseSpeed = Resources.Instance.GetGooflingData(goofling.GooflingType).Speed;
            float threshold = baseSpeed / 2f;
            int randomByte = Rand.Next(256);
            return randomByte < threshold;
        }
        

        public static void SkipLines(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                Console.WriteLine();
            }
        }
    }
}
