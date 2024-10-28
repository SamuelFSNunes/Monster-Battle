using Monster_Battle.Observer;
using Monster_Battle.Memento;
using Monster_Battle.Action;
using System;
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
        private List<IObserver> observers = new List<IObserver>();
        private Caretaker caretaker = new Caretaker(); // Adicionando o Caretaker para gerenciar o estado

        // Construtor para inicializar o monstro
        public Monster(string name, int health, int attackPoints, int defensePoints, int specialAttackPoints)
        {
            this.name = name;
            this.health = health;
            this.attackPoints = attackPoints;
            this.defensePoints = defensePoints;
            this.specialAttackPoints = specialAttackPoints;
            SaveState(); // Salva o estado inicial do monstro
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
                SaveState(); // Salva o estado antes de realizar a ação
                actionStrategy.Execute(this, target);
                NotifyObservers(); // Notifica após a ação
            }
            else
            {
                Console.WriteLine($"{name} não possui uma estratégia de ação definida!");
            }
        }

        // Implementação do padrão Observer
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

        // Aplica dano ao monstro e notifica os observadores
        public void ReceiveDamage(int damage)
        {
            SaveState(); // Salva o estado antes de aplicar dano
            health -= damage;
            NotifyObservers();
        }

        // Aplica cura ao monstro e notifica os observadores
        public void ReceiveHealing(int healingPoints)
        {
            SaveState(); // Salva o estado antes de aplicar cura
            health += healingPoints;
            NotifyObservers();
        }

        // Salva o estado do monstro no caretaker
        public MonsterMemento SaveState()
        {
            MonsterMemento memento = new MonsterMemento(name, health, attackPoints, defensePoints);
            caretaker.SaveMemento(memento);
            return memento; // Retorna o memento
        }

        // Método para restaurar o estado do monstro e notificar os observadores
        public void Undo(int stepsBack = 1)
        {
            MonsterMemento memento = null;
            for (int i = 0; i < stepsBack; i++)
            {
                memento = caretaker.Undo();
                if (memento == null)
                {
                    Console.WriteLine("Nenhum estado salvo para restaurar.");
                    return;
                }
            }

            if (memento != null)
            {
                RestoreState(memento);
                Console.WriteLine($"{name} foi restaurado para {health} pontos de vida.");
            }
        }

        // Restaura o estado do monstro a partir de um memento específico
        public void RestoreState(MonsterMemento memento)
        {
            name = memento.Name;
            health = memento.Health;
            attackPoints = memento.AttackPoints;
            defensePoints = memento.DefensePoints;
            NotifyObservers();
        }

        // Método que será sobrescrito pelas subclasses (como Dragon e Zombie)
        public virtual void SpecialAbility(Monster opponent)
        {
            Console.WriteLine($"{name} usou sua habilidade especial!");
        }
    }
}
