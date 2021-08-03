using System.Diagnostics;

namespace Assignment4
{
    public class Monster
    {
        private int mHealth;
        private int mAttackStat;
        private int mDefenseStat;

        public Monster(string name, EElementType elementType, int health, int attack, int defense)
        {
            Name = name;
            ElementType = elementType;
            mHealth = health;
            mAttackStat = attack;
            mDefenseStat = defense;
        }

        public Monster(uint capacity)
        {
        }

        public string Name { get; private set; }
        public EElementType ElementType { get; private set; }

        public int Health
        {
            get
            {
                return mHealth;
            }
            private set
            {
                if (mHealth < 0)
                {
                    mHealth = 0;
                }

                Health = mHealth;
            }
        }

        public int AttackStat
        {
            get
            {
                return mAttackStat;
            }
            private set
            {
                if (mAttackStat < 0)
                {
                    mAttackStat = 0;
                }

                AttackStat = mAttackStat;
            }
        }

        public int DefenseStat
        {
            get
            {
                return mDefenseStat;
            }
            private set
            {
                if (mDefenseStat < 0)
                {
                    mDefenseStat = 0;
                }

                DefenseStat = mDefenseStat;
            }
        }

        public void TakeDamage(int amount)
        {
            if (amount < 0)
            {
                return;
            }

            mHealth -= amount;

            if (mHealth < 0)
            {
                mHealth = 0;
            }
        }

        public void Attack(Monster otherMonster)
        {
            double defaultDamage = AttackStat - otherMonster.DefenseStat;
            double finalDamage;
            int advantage = GetAdvantage(otherMonster);

            switch (advantage)
            {
                case -1:
                    finalDamage = defaultDamage * 0.5;

                    if (finalDamage < 1)
                    {
                        finalDamage = 1;
                    }

                    otherMonster.mHealth = otherMonster.mHealth - (int)finalDamage;

                    if (otherMonster.mHealth <= 0)
                    {
                        otherMonster.mHealth = 0;
                    }
                    break;

                case 0:
                    finalDamage = defaultDamage;

                    if (finalDamage < 1)
                    {
                        finalDamage = 1;
                    }

                    otherMonster.mHealth = otherMonster.mHealth - (int)finalDamage;

                    if (otherMonster.mHealth <= 0)
                    {
                        otherMonster.mHealth = 0;
                    }
                    break;

                case 1:
                    finalDamage = defaultDamage * 1.5;

                    if (finalDamage < 1)
                    {
                        finalDamage = 1;
                    }

                    otherMonster.mHealth = otherMonster.mHealth - (int)finalDamage;

                    if (otherMonster.mHealth <= 0)
                    {
                        otherMonster.mHealth = 0;
                    }
                    break;
            }
        }

        public int GetAdvantage(Monster otherMonster)
        {
            const int WRONG = -2;
            const int WEAK = -1;
            const int EQUAL = 0;
            const int STRONG = 1;
            EElementType otherElement = otherMonster.ElementType;

            switch (ElementType)
            {
                case EElementType.Fire:
                    if (otherElement == EElementType.Wind)
                    {
                        return STRONG;
                    }
                    else if (otherElement == EElementType.Fire)
                    {
                        return EQUAL;
                    }
                    else
                    {
                        return WEAK;
                    }

                case EElementType.Water:
                    if (otherElement == EElementType.Fire)
                    {
                        return STRONG;
                    }
                    else if (otherElement == EElementType.Wind)
                    {
                        return WEAK;
                    }
                    else
                    {
                        return EQUAL;
                    }

                case EElementType.Earth:
                    if (otherElement == EElementType.Fire)
                    {
                        return STRONG;
                    }
                    else if (otherElement == EElementType.Wind)
                    {
                        return WEAK;
                    }
                    else
                    {
                        return EQUAL;
                    }

                case EElementType.Wind:
                    if (otherElement == EElementType.Fire)
                    {
                        return WEAK;
                    }
                    else if (otherElement == EElementType.Wind)
                    {
                        return EQUAL;
                    }
                    else
                    {
                        return STRONG;
                    }

                default:
                    Debug.Assert(false);
                    break;
            }

            return WRONG;
        }
    }
}
