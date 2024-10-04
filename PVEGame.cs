using Monster_Battle.Monsters;
using System.Threading;

// Singleton do Jogo (para gerenciar estado)
namespace Monster_Battle
{
    class PVEGame
    {
        private static PVEGame instance;
        public Monster Player { get; private set; }
        public Monster Enemy { get; private set; }

        private PVEGame() { }

        public static PVEGame GetInstance()
        {
            if(instance == null)
            {
                instance = new PVEGame();
            }
            return instance;
        }

        public void StartBattle()
        {
            Console.WriteLine("Iniciando Combate\n");

            while (Player.health > 0 && Enemy.health > 0)
            {
                PlayerChance();
                if (Enemy.health <= 0) break;
                EnemyChance();
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
        public void PlayerChance()
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

            // Executa a ação escolhida pelo jogador
            if (choose == "1")
            {
                Player.Attack(Enemy);
            }
            else if (choose == "2")
            {
                Player.specialAbility(Enemy);
            }
        }
        public void EnemyChance() 
        {
            Console.WriteLine("\nTurno do inimigo!");
            
            Random random = new Random();

            int enemyTurn = random.Next(1, 3);

            if (enemyTurn == 1) 
            { 
               Enemy.Attack(Player);
            }
            else
            {
                Enemy.specialAbility(Player);
            }
            Console.WriteLine($"{Player.name} agora tem {Player.health} pontos de vida.");
        }

        public void SetMonsters(Monster player, Monster enemy)
        {
            Player = player;
            Enemy = enemy;
        }
    }
}
