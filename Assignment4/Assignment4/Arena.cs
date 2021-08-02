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
        public Monster[] Monsters { get; private set; }

        public void LoadMonsters(string filepath)
        {
            const int MONSTER_DATAS = 5;
            try
            {
                string[] loadMonsterText = File.ReadAllLines(filepath);
                string[] currentMonsterInfo = new string[MONSTER_DATAS];
                Monsters = new Monster[loadMonsterText.Length];

                for (int i = 0; i < loadMonsterText.Length; ++i)
                {
                    if (MonsterCount == Capacity)
                    {
                        break;
                    }

                    currentMonsterInfo = loadMonsterText[i].Split(',');
                    string name = currentMonsterInfo[0];
                    EElementType elementType = (EElementType)Enum.Parse(typeof(EElementType), currentMonsterInfo[1]);
                    int health = int.Parse(currentMonsterInfo[2]);
                    int attackStat = int.Parse(currentMonsterInfo[3]);
                    int defenseStat = int.Parse(currentMonsterInfo[4]);

                    Monsters[i] = new Monster(name, elementType, health, attackStat, defenseStat);
                    ++MonsterCount;
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File Not Found Exception");
                Console.WriteLine(e);
            }
        }

        public void GoToNextTurn()
        {
            for (int i = 0; i < MonsterCount; ++i)
            {
                if (Monsters[i].Health == 0)
                {
                    --MonsterCount;
                    ++i;
                }

                if (i == MonsterCount - 1)
                {
                    Monsters[i].Attack(Monsters[0]);
                }

                else
                {
                    Monsters[i].Attack(Monsters[i + 1]);
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

            Monster bestMonster = Monsters[0];

            for (int i = 1; i < Monsters.Length; ++i)
            {
                if (bestMonster.Health < Monsters[i].Health)
                {
                    bestMonster = Monsters[i];
                }
            }

            return bestMonster;
        }
    }
}
