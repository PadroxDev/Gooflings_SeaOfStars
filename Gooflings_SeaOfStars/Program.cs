using System;

namespace Gooflings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Resources resources = new Resources();
            GooflingData grayanData = resources.GetGooflingData(GooflingType.Grayan);
            GooflingData danyData = resources.GetGooflingData(GooflingType.Radany);
            Goofling grayan = new(grayanData);
            Goofling dany = new(danyData);
        }
    }
}