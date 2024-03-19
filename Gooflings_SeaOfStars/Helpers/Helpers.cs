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

    public enum Type
    {
        None,
        Food,
        Caillou,
        Code,
        Yordle
    }

    public static class Helpers
    {
        public const int MAX_LEVEL = 100;
        public const double EXP_EXPONENTIAL_TRIM = 0.7;
        public const double EXP_EXPONENTIAL_OFFSET = 20;

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
    }
}
