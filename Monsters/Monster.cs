namespace Monster_Battle.Monsters
{
    abstract class Monster
    {
        public string name { get; set; }
        public int health { get; set; }
        public int attackPower { get; set; }
        public int defense {  get; set; }
        public Monster(string name, int health, int attackPower, int defense) {
            this.name = name;
            this.health = health;
            this.attackPower = attackPower;
            this.defense = defense;
        }

        public virtual void Attack(Monster opponent) { 
            int demage = attackPower - opponent.defense;
            if (demage > 0)
            {
                opponent.health -= demage;
                Console.WriteLine($"{name} atacou {opponent.name} e causou {demage} de dano.");
            }
            else
            {
                Console.WriteLine($"{name} atacou {opponent.name}, mas não conseguiu superar a defesa");
            }
        }

        public abstract void specialAbility(Monster opponent);
    }
}
