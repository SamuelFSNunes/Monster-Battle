using Monster_Battle.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Battle.Action
{   // Design Pattern: Strategy 
    // Interface for combat actions
    public interface IAction
    {
        void Execute(Monster attacker, Monster target);
    }
}
