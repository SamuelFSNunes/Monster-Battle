using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Battle.Memento
{
    // Design Pattern: Memento
    // Caretaker class to manage mementos
    public class Caretaker
    {
        private List<MonsterMemento> mementos = new List<MonsterMemento>();

        public void SaveMemento(MonsterMemento memento)
        {
            mementos.Add(memento);
        }

        public MonsterMemento RetrieveMemento(int index)
        {
            if (index >= 0 && index < mementos.Count)
            {
                return mementos[index];
            }
            return null;
        }
    }
}
