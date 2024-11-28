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
            DiceFacade diceFacade = new DiceFacade();
            int roll = diceFacade.Roll(20);
            if (roll == 1)
            {
                Console.WriteLine($"{attacker.name} atacou {target.name} mas a ataque falhou!");
                return;
            }
            else if (roll == 20)
            {
                int damage = 2 * (attacker.attackPoints - target.defensePoints);
                target.ReceiveDamage(damage);
                Console.WriteLine($"{attacker.name} atacou {target.name} causando acerto critico! Dando assim {damage} de dano!");
            }
            else
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
}

