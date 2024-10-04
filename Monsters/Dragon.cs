namespace Monster_Battle.Monsters
{
    class Dragon : Monster
    {
        public Dragon() : base("Spyro, o dragão", 100, 30, 10)
        {
        }

        public override void specialAbility(Monster opponent)
        {
            Console.WriteLine($"{name} usou sua habilidade especial: Sopro Flamejante!");
            opponent.health -= 40;
            Console.WriteLine($"{opponent.name} sofreu 40 de dano!");
        }
    }
}
