namespace Monster_Battle.Monsters
{
    public class Zombie : Monster
    {
        public Zombie() : base("Zumbi, o morto-vivo", 120, 20, 10, 0) // Inclui o valor do specialAttackPoints (ajustável se necessário)
        {
        }

        // Sobrescrevendo a habilidade especial
        public override void SpecialAbility(Monster opponent)
        {
            Console.WriteLine($"{name} usou sua habilidade especial: Auto-cura!");
            ReceiveHealing(30); // Usando método para curar e notificar os observadores
            Console.WriteLine($"{name} recuperou 30 pontos de vida!");
        }
    }
}
