using Monster_Battle.Monsters;
using System.Threading;
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

        private PVEGame() { }

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

            while (Player.health > 0 && Enemy.health > 0)
            {
                PlayerTurn();
                if (Enemy.health <= 0) break;
                EnemyTurn();
            }

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

            // Definir ação com o padrão Strategy
            if (choose == "1")
            {
                Player.SetAction(new Attack());
            }
            else if (choose == "2")
            {
                Player.SetAction(new SpecialAbility());
            }

            // Executar a ação escolhida
            Player.PerformAction(Enemy);

            // Verificar e notificar a condição do inimigo
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

            // Definir ação aleatória para o inimigo
            if (enemyTurn == 1)
            {
                Enemy.SetAction(new Attack());
            }
            else
            {
                Enemy.SetAction(new SpecialAbility());
            }

            // Executar a ação do inimigo
            Enemy.PerformAction(Player);

            Console.WriteLine($"{Player.name} agora tem {Player.health} pontos de vida.");

            if (Player.health <= 0)
            {
                Console.WriteLine($"{Player.name} foi derrotado!");
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
