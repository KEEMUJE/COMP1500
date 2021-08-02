using System;
using System.IO;
using System.Collections.Generic;

namespace Assignment4
{
    public class Arena
    {
        public Arena(string arenaName, uint capacity)
        {
            ArenaName = arenaName;
            Capacity = capacity;
        }

        public uint Capacity { get; private set; }
        public string ArenaName { get; private set; }
        public uint Turns { get; private set; }
        public uint MonsterCount { get; private set; }
        public Monster ObjectName { get; private set; }
        public Monster[] monsters { get; private set; }

        public void LoadMonsters(string filepath)
        {
            const int MONSTER_DATAS = 5;
            string[] LoadMonsterText = File.ReadAllLines(filepath);
            string[] currentMonsterInfo = new string[MONSTER_DATAS];
            monsters = new Monster[LoadMonsterText.Length];
            
            for (int i = 0; i < LoadMonsterText.Length; ++i)
            {
                if (MonsterCount == Capacity)
                {
                    break;
                }

                currentMonsterInfo = LoadMonsterText[i].Split(',');
                string name = currentMonsterInfo[0];
                EElementType elementType = (EElementType)Enum.Parse(typeof(EElementType), currentMonsterInfo[1]);
                int health = int.Parse(currentMonsterInfo[2]);
                int attackStat = int.Parse(currentMonsterInfo[3]);
                int defenseStat = int.Parse(currentMonsterInfo[4]);

                monsters[i] = new Monster(name, elementType, health, attackStat, defenseStat);
                ++MonsterCount;
            }
        }

        public void GoToNextTurn()
        {
            for (int i = 0; i < MonsterCount; ++i)
            {
                if (monsters[i].Health == 0)
                {
                    --MonsterCount;
                    ++i;
                }

                if (i == MonsterCount - 1)
                {
                    monsters[i].Attack(monsters[0]);
                }

                else
                {
                    monsters[i].Attack(monsters[i + 1]);
                }
            }

            ++Turns;
        }

        public Monster GetHealthiest()
        {
            if (MonsterCount == 0)
            {
                return null;
            }

            Monster bestMonster = monsters[0];

            for (int i = 0; i < monsters.Length; ++i)
            {
                if (bestMonster.Health < monsters[i].Health)
                {
                    bestMonster = monsters[i];
                }
            }

            return bestMonster;
        }
    }
}
