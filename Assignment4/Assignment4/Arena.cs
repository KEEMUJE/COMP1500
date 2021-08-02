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
        public Monster objectName { get; private set; }

        public void LoadMonsters(string filePath)
        {
            const int monsterDatas = 5;
            string[] readText = File.ReadAllLines(filePath);
            string[][] monstersInfo = new string[Capacity][];

            for (int i = 0; i < readText.Length; ++i)
            {
                monstersInfo[i] = new string[monsterDatas];
                monstersInfo[i] = readText[i].Split(',');

                string monsterName = monstersInfo[i][0];
                EElementType elementType = (EElementType)Enum.Parse(typeof(EElementType), monstersInfo[i][1]);
                int health = int.Parse(monstersInfo[i][2]);
                int attackStat = int.Parse(monstersInfo[i][3]);
                int defenseStat = int.Parse(monstersInfo[i][4]);

                // 여기서 이름 없는 오브젝트의 정보를 어떻게 조회하는지 알면 다른 함수 구현은 쉬움.
                new Monster(monsterName, elementType, health, attackStat, defenseStat);
                ++MonsterCount;
            }
        }

        public void GoToNextTurn()
        {
        }

        public Monster GetHealthiest()
        {
            if (MonsterCount == 0)
            {
                return null;
            }

            return null;
        }
    }
}
