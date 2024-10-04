using Monster_Battle.Observer;
using Monster_Battle.Memento;
using Monster_Battle.Action;
using System.Collections.Generic;

namespace Monster_Battle.Monsters
{
    public class Monster
    {
        public string name;
        public int health;
        public int attackPoints;
        public int defensePoints;
        public int specialAttackPoints;

        private IAction actionStrategy;

        // Construtor para inicializar o monstro
        public Monster(string name, int health, int attackPoints, int defensePoints, int specialAttackPoints)
        {
            this.name = name;
            this.health = health;
            this.attackPoints = attackPoints;
            this.defensePoints = defensePoints;
            this.specialAttackPoints = specialAttackPoints;
        }

        // Definindo a estratégia de ação (Strategy Pattern)
        public void SetAction(IAction newAction)
        {
            actionStrategy = newAction;
        }

        // Executando a ação baseada na estratégia definida
        public void PerformAction(Monster target)
        {
            if (actionStrategy != null)
            {
                actionStrategy.Execute(this, target);
            }
            else
            {
                Console.WriteLine($"{name} doesn't have an action strategy set!");
            }
        }

        // Implementação do padrão Observer
        private List<IObserver> observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        // Método para notificar todos os observadores
        private void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(this);
            }
        }

        // Atualizar a saúde e notificar os observadores
        public void ReceiveDamage(int damage)
        {
            health -= damage;
            NotifyObservers();
        }

        // Método que será sobrescrito pelas subclasses (como Dragon e Zombie)
        public virtual void SpecialAbility(Monster opponent)
        {
            Console.WriteLine($"{name} used its special ability!");
        }

        // Novo método para receber cura e notificar os observadores
        public void ReceiveHealing(int healingPoints)
        {
            health += healingPoints;
            NotifyObservers(); // Notifica sobre a mudança no estado do monstro
        }

        // Implementação do padrão Memento para salvar o estado do monstro
        public MonsterMemento SaveState()
        {
            return new MonsterMemento(name, health, attackPoints, defensePoints);
        }

        // Restaurando o estado do monstro usando o Memento
        public void RestoreState(MonsterMemento memento)
        {
            name = memento.Name;
            health = memento.Health;
            attackPoints = memento.AttackPoints;
            defensePoints = memento.DefensePoints;
            NotifyObservers(); // Notifica os observadores após a restauração do estado
        }
    }
}
