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
            if (attacker.name == "Zumbi")
            {
                int healingPoints = attacker.specialAttackPoints;
                attacker.ReceiveHealing(healingPoints);
                Console.WriteLine($"{attacker.name} usou sua habilidade especial e se curou em {healingPoints} pontos de vida!");
            }
            else
            {
                int specialDamage = attacker.specialAttackPoints - target.defensePoints;
                if (specialDamage > 0)
                {
                    target.ReceiveDamage(specialDamage);
                    Console.WriteLine($"{attacker.name} usou uma habilidade especial em {target.name} causando {specialDamage} de dano!");
                }
                else
                {
                    Console.WriteLine($"{attacker.name} usou uma habilidade especial em {target.name}, mas não causou dano.");
                }
            }
        }
    }
}
