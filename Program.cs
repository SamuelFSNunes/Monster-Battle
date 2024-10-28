using Monster_Battle.Monsters;
using Monster_Battle;
using Monster_Battle.Observer;

Console.WriteLine("Bem-vindo à Batalha de Monstros!");

// Solicita que o jogador escolha um monstro
Console.WriteLine("Escolha seu monstro: 1) Dragão 2) Zumbi");
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

// Adiciona o HealthObserver para ambos os monstros
HealthObserver healthObserver = new HealthObserver();
jogador.AddObserver(healthObserver);
inimigo.AddObserver(healthObserver);

// Inicia o combate entre o jogador e o inimigo
jogo.StartBattle();
