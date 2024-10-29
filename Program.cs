using Monster_Battle.Monsters;
using Monster_Battle;
using Monster_Battle.Observer;

namespace Monster_Battle_Game
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Bem-vindo à Batalha de Monstros!");

            // Solicita que o jogador escolha o modo de jogo
            Console.WriteLine("Escolha o modo de jogo: 1) PvE  2) PvP");
            string modoDeJogo = Console.ReadLine();

            if (modoDeJogo != "1" && modoDeJogo != "2")
            {
                Console.WriteLine("Modo de jogo inválido! O jogo será encerrado.");
                return;
            }

            // Solicita que o jogador escolha seu monstro
            Console.WriteLine("Escolha seu monstro: 1) Dragão  2) Zumbi");
            string escolha = Console.ReadLine();

            Monster jogador = escolha switch
            {
                "1" => MonsterFactory.CreateMonster("Dragao"),  // Cria um Dragão
                "2" => MonsterFactory.CreateMonster("Zumbi"),   // Cria um Zumbi
                _ => null
            };

            if (jogador == null)
            {
                Console.WriteLine("Escolha inválida! O jogo será encerrado.");
                return;
            }

            // Confirmação da escolha do jogador
            Console.WriteLine($"Você escolheu o monstro: {jogador.name}");

            // Adiciona o HealthObserver ao monstro do jogador
            HealthObserver healthObserver = new HealthObserver();
            jogador.AddObserver(healthObserver);

            // Modo PvE
            if (modoDeJogo == "1")
            {
                // Computador escolhe um monstro aleatório
                Random random = new Random();
                Monster inimigo = random.Next(1, 3) switch
                {
                    1 => MonsterFactory.CreateMonster("Dragao"),  // Cria um Dragão aleatório
                    2 => MonsterFactory.CreateMonster("Zumbi"),   // Cria um Zumbi aleatório
                    _ => throw new Exception("Erro ao criar o inimigo.")
                };

                // Confirmação do monstro do inimigo
                Console.WriteLine($"O inimigo será o monstro: {inimigo.name}");

                // Instância do jogo PvE (Singleton)
                PVEGame jogo = PVEGame.GetInstance();

                // Configura os monstros para a batalha
                jogo.SetMonsters(jogador, inimigo);

                // Adiciona o HealthObserver para o monstro inimigo
                inimigo.AddObserver(healthObserver);

                // Inicia o combate entre o jogador e o inimigo
                jogo.StartBattle();
            }
            // Modo PvP
            else if (modoDeJogo == "2")
            {
                // Solicita que o segundo jogador escolha seu monstro
                Console.WriteLine("Jogador 2, escolha seu monstro: 1) Dragão  2) Zumbi");
                string escolhaJogador2 = Console.ReadLine();

                Monster jogador2 = escolhaJogador2 switch
                {
                    "1" => MonsterFactory.CreateMonster("Dragao"),  // Cria um Dragão
                    "2" => MonsterFactory.CreateMonster("Zumbi"),   // Cria um Zumbi
                    _ => null
                };

                if (jogador2 == null)
                {
                    Console.WriteLine("Escolha inválida! O jogo será encerrado.");
                    return;
                }

                // Confirmação da escolha do jogador 2
                Console.WriteLine($"Jogador 2 escolheu o monstro: {jogador2.name}");

                // Adiciona o HealthObserver ao monstro do jogador 2
                jogador2.AddObserver(healthObserver);

                // Cria a instância do jogo PvP
                PVPGame batalhaPvP = PVPGame.GetInstance(jogador, jogador2);

                // Inicia o combate entre os dois jogadores
                batalhaPvP.StartBattle();
            }
        }
    }
}
