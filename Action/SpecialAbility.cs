using Monster_Battle.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Battle.Action
{
    // Special ability action implementation
    public class SpecialAbility : IAction
    {
        public void Execute(Monster attacker, Monster target)
        {
            Console.WriteLine($"{attacker.name} uses special ability on {target.name}!");
            target.health -= attacker.specialAttackPoints; // Applies special damage
        }
    }
}
