using Monster_Battle.Action;
using Monster_Battle.Memento;
using Monster_Battle.Monsters;
using System;

public class PVPGame
{
    private static PVPGame instance;
    public Monster Player1 { get; private set; }
    public Monster Player2 { get; private set; }
    private Caretaker caretaker;

    private PVPGame(Monster player1, Monster player2)
    {
        Player1 = player1;
        Player2 = player2;
        caretaker = new Caretaker();
    }

    // Implementação do Singleton
    public static PVPGame GetInstance(Monster player1, Monster player2)
    {
        if (instance == null)
        {
            instance = new PVPGame(player1, player2);
        }
        return instance;
    }

    // Iniciar a batalha
    public void StartBattle()
    {
        Console.WriteLine("Iniciando Batalha PvP\n");

        // Salvar estado inicial dos monstros
        caretaker.SaveMemento(Player1.SaveState());
        caretaker.SaveMemento(Player2.SaveState());

        bool isPlayer1Turn = true;

        while (Player1.health > 0 && Player2.health > 0)
        {
            if (isPlayer1Turn)
            {
                PlayerTurn(Player1, Player2);
            }
            else
            {
                PlayerTurn(Player2, Player1);
            }

            // Alterna a vez do jogador
            isPlayer1Turn = !isPlayer1Turn;
        }

        // Verificar vencedor
        DeclareWinner();
    }

    // Método que realiza o turno de um jogador
    private void PlayerTurn(Monster attacker, Monster target)
    {
        Console.WriteLine($"{attacker.name}, é a sua vez!");

        // Salvar estado antes da ação
        caretaker.SaveMemento(attacker.SaveState());

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

        if (choose == "1")
        {
            attacker.SetAction(new Attack());
            attacker.PerformAction(target);
            Console.WriteLine($"{target.name} recebeu dano!");
        }
        else if (choose == "2")
        {
            attacker.SetAction(new SpecialAbility());
            attacker.PerformAction(target);
            Console.WriteLine($"{target.name} recebeu dano!");
        }

        // Verifica condição de vitória
        if (target.health <= 0)
        {
            Console.WriteLine($"{target.name} foi derrotado!");
        }
    }

    // Declara o vencedor com base em quem ficou com pontos de vida restantes
    private void DeclareWinner()
    {
        if (Player1.health > 0)
        {
            Console.WriteLine($"{Player1.name} é o vencedor com {Player1.health} pontos de vida restantes!");
        }
        else if (Player2.health > 0)
        {
            Console.WriteLine($"{Player2.name} é o vencedor com {Player2.health} pontos de vida restantes!");
        }
        else
        {
            Console.WriteLine("Ambos os monstros caíram, é um empate!");
        }
    }
}
