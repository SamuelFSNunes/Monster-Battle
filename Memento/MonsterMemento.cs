namespace Monster_Battle.Memento
{
    // Design Pattern: Memento
    public class MonsterMemento
    {
        public string Name { get; }
        public int Health { get; }
        public int AttackPoints { get; }
        public int DefensePoints { get; }

        public MonsterMemento(string name, int health, int attackPoints, int defensePoints)
        {
            Name = name;
            Health = health;
            AttackPoints = attackPoints;
            DefensePoints = defensePoints;
        }
    }
}
