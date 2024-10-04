namespace Monster_Battle.Monsters
{
    class Zombie : Monster
    {
        public Zombie() : base("Zumbi, o morto-vivo", 120, 20, 10)
        {
        }

        public override void specialAbility(Monster opponent)
        {
            Console.WriteLine($"{name} usou sua habilidade especial: Auto-cura!");
            health += 30;
            Console.WriteLine($"{name} recuperou 30 pontos de vida!");
        }
    }
}
