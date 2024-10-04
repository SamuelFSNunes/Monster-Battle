﻿namespace Monster_Battle.Monsters
{
    class MonsterFactory
    {
        public static Monster CreateMonster(string type)
        {
            return type switch
            {
                "Dragao" => new Dragon(),
                "Zumbi" => new Zombie(),
                _ => null
            };
        }
    }
}