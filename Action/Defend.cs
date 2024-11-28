using Monster_Battle.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Battle.Action
{
    // Defend action implementation (can be extended as needed)
    public class Defend : IAction
    {
        public void Execute(Monster attacker, Monster target)
        {
            Console.WriteLine($"{attacker.name} defends!");
            attacker.defensePoints += 10; // Temporarily increases defense
        }
    }
}
