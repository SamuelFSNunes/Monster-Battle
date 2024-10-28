using System.Collections.Generic;

namespace Monster_Battle.Memento
{
    // Classe Caretaker para gerenciar mementos
    public class Caretaker
    {
        private List<MonsterMemento> mementos = new List<MonsterMemento>();
        private int currentIndex = -1; // Índice atual para gerenciamento de mementos

        // Salva um novo memento e redefine a lista se o índice atual não for o último
        public void SaveMemento(MonsterMemento memento)
        {
            // Remove mementos futuros quando o usuário faz uma nova ação
            if (currentIndex < mementos.Count - 1)
            {
                mementos.RemoveRange(currentIndex + 1, mementos.Count - currentIndex - 1);
            }

            mementos.Add(memento);
            currentIndex = mementos.Count - 1;
        }


        // Desfaz a última ação, retornando o memento anterior se existir
        public MonsterMemento Undo()
        {
            if (currentIndex <= 0)
            {
                return null; // Não há mementos para desfazer
            }

            currentIndex--;
            return mementos[currentIndex];
        }

        // Refaz a ação, retornando o próximo memento se existir
        public MonsterMemento Redo()
        {
            if (currentIndex >= mementos.Count - 1)
            {
                return null; // Não há mementos para refazer
            }

            currentIndex++;
            return mementos[currentIndex];
        }

        // Recupera o memento em um índice específico, se for válido
        public MonsterMemento RetrieveMemento(int index)
        {
            if (index >= 0 && index < mementos.Count)
            {
                return mementos[index];
            }
            return null;
        }
        // Propriedade para contar o número de mementos
        public int MementosCount => mementos.Count; // Adiciona esta linha

        // Método para verificar se há mementos para desfazer
        public bool CanUndo() => currentIndex > 0;

        // Método para verificar se há mementos para refazer
        public bool CanRedo() => currentIndex < mementos.Count - 1;
    }
}
