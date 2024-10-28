using Monster_Battle.Monsters;
using Monster_Battle.Memento;
using Monster_Battle.Action;
using System;

namespace Monster_Battle
{
    // Singleton do Jogo (para gerenciar estado)
    public class PVEGame
    {
        private static PVEGame instance;
        public Monster Player { get; private set; }
        public Monster Enemy { get; private set; }
        private Caretaker caretaker;

        private PVEGame()
        {
            caretaker = new Caretaker();
        }

        // Implementação do Singleton
        public static PVEGame GetInstance()
        {
            if (instance == null)
            {
                instance = new PVEGame();
            }
            return instance;
        }

        // Iniciar a batalha
        public void StartBattle()
        {
            Console.WriteLine("Iniciando Combate\n");

            // Salvar estado inicial dos monstros
            caretaker.SaveMemento(Player.SaveState());
            caretaker.SaveMemento(Enemy.SaveState());

            while (Player.health > 0 && Enemy.health > 0)
            {
                PlayerTurn();
                if (Enemy.health <= 0) break;

                EnemyTurn();
            }

            // Verificar vencedor
            if (Player.health > 0)
            {
                Console.WriteLine("Você Venceu!");
            }
            else
            {
                Console.WriteLine("Você Perdeu!");
            }
        }

        // Turno do jogador
        public void PlayerTurn()
        {
            string choose = "";

            // Loop para garantir que o usuário digite apenas '1' ou '2'
            while (choose != "1" && choose != "2")
            {
                Console.WriteLine("\nEscolha sua ação: 1) Atacar 2) Usar Habilidade Especial");
                choose = Console.ReadLine();

                if (choose != "1" && choose != "2")
                {
                    Console.WriteLine("Opção inválida! Por favor, escolha 1 ou 2.");
                }
            }

            // Salvar estado antes da ação
            caretaker.SaveMemento(Player.SaveState());

            // Definir e executar a ação com o padrão Strategy
            if (choose == "1")
            {
                Player.SetAction(new Attack());
            }
            else if (choose == "2")
            {
                Player.SetAction(new SpecialAbility());
            }

            Player.PerformAction(Enemy);

            // Notificar e verificar a condição do inimigo
            if (Enemy.health <= 0)
            {
                Console.WriteLine($"{Enemy.name} foi derrotado!");
            }
        }

        // Turno do inimigo
        public void EnemyTurn()
        {
            Console.WriteLine("\nTurno do inimigo!");

            Random random = new Random();
            int enemyTurn = random.Next(1, 3);

            // Salvar estado antes da ação
            caretaker.SaveMemento(Enemy.SaveState());

            // Definir ação aleatória e executá-la
            if (enemyTurn == 1)
            {
                Enemy.SetAction(new Attack());
            }
            else
            {
                Enemy.SetAction(new SpecialAbility());
            }

            Enemy.PerformAction(Player);

            // Notificar e verificar a condição do jogador
            if (Player.health <= 0)
            {
                Console.WriteLine($"{Player.name} foi derrotado!");
            }
        }

        // Método para desfazer (Undo) o estado de ambos os monstros, voltando uma ação
        public void UndoLastAction()
        {
            Console.WriteLine("Restaurando estado anterior...");
            if (caretaker.RetrieveMemento(caretaker.MementosCount - 2) != null)
            {
                Player.RestoreState(caretaker.RetrieveMemento(caretaker.MementosCount - 2));
                Enemy.RestoreState(caretaker.RetrieveMemento(caretaker.MementosCount - 1));
                Console.WriteLine("Estado restaurado.");
            }
            else
            {
                Console.WriteLine("Nenhum estado salvo para restaurar.");
            }
        }

        // Método para definir os monstros
        public void SetMonsters(Monster player, Monster enemy)
        {
            Player = player;
            Enemy = enemy;
        }
    }
}
