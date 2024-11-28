using Monster_Battle.Monsters;

namespace Monster_Battle.Observer
// Design Pattern: Observer
// Interface para o Observer
{
    public interface IObserver
    {
        void Update(Monster monster);
    }
}
