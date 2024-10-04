using Monster_Battle.Monsters;
using Monster_Battle;

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

// Computador escolhe um monstro aleatório (Zumbi neste caso)
Monster inimigo = MonsterFactory.CreateMonster("Zumbi");

// Instância do jogo PvE (Singleton)
PVEGame jogo = PVEGame.GetInstance();

// Configura os monstros para a batalha
jogo.SetMonsters(jogador, inimigo);

// Inicia o combate entre o jogador e o inimigo
jogo.StartBattle();