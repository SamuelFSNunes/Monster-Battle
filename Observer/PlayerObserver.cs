using Monster_Battle.Monsters;

namespace Monster_Battle.Observer
{
    public class PlayerObserver : IObserver
    {
        void IObserver.Update(Monster monster)
        {
            Console.WriteLine($"Update: {monster.name} possui {monster.health} pontos de vida.");
        }
    }
}
