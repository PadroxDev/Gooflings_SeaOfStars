using System;
using System.Collections.Generic;
using System.Linq;

namespace Gooflings.Moves
{
    public class Croustifesses : Move
    {
        public Croustifesses()
        {
            MoveType = MoveType.Croustifesses;
            Name = "Test";
            AtkType = Types.Food;
            Power = 50;
            ManaCost = 25;
        }

        ~Croustifesses()
        {}

        public override void OnAction(Goofling attacker, Goofling target)
        {
            int dmg = Helpers.CalculateDamageToDeal(attacker, target, this);
            Console.WriteLine($"{attacker.HP} / {attacker.MaxHP}");
            Console.WriteLine("Deal damage to " + target.Name + ": " + dmg);
            target.TakeDamage(dmg);
        }
    }
}
