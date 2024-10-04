namespace Monster_Battle.Monsters
{
    public class Dragon : Monster
    {
        public Dragon() : base("Spyro, o dragão", 100, 30, 10, 50) // Inclui o valor do specialAttackPoints
        {
        }

        // Sobrescrevendo a habilidade especial
        public override void SpecialAbility(Monster opponent)
        {
            Console.WriteLine($"{name} usou sua habilidade especial: Sopro Flamejante!");
            opponent.ReceiveDamage(40); // Usar o método ReceiveDamage para aplicar o dano e notificar os observadores
            Console.WriteLine($"{opponent.name} sofreu 40 de dano!");
        }
    }
}
