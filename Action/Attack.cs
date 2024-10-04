using Monster_Battle.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Battle.Action
{
    // Attack action implementation
    public class Attack : IAction
    {
        public void Execute(Monster attacker, Monster target)
        {
            Console.WriteLine($"{attacker.name} attacks {target.name}!");
            target.health -= attacker.attackPoints;
        }
    }
}
