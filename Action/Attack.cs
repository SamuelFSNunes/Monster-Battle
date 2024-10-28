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
            int damage = attacker.attackPoints - target.defensePoints;
            if (damage > 0)
            {
                target.ReceiveDamage(damage);
                Console.WriteLine($"{attacker.name} atacou {target.name} causando {damage} de dano!");
            }
            else
            {
                Console.WriteLine($"{attacker.name} atacou {target.name}, mas não causou dano.");
            }
        }
    }
}

