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
            double defaultDamage = mAttackStat - otherMonster.mDefenseStat;
            int comparativeAdvantage = DetermineComparactiveAdvantage(ElementType, otherMonster);
            double finalDamage;

            switch (comparativeAdvantage)
            {
                case -1:
                    finalDamage = defaultDamage * 0.5;
                    finalDamage = finalDamage < 1 ? 1 : finalDamage;
                    otherMonster.mHealth = otherMonster.mHealth - (int)finalDamage;
                    otherMonster.mHealth = otherMonster.mHealth < 0 ? 0 : otherMonster.mHealth;
                    break;

                case 0:
                    finalDamage = defaultDamage;
                    finalDamage = finalDamage < 1 ? 1 : finalDamage;
                    otherMonster.mHealth = otherMonster.mHealth - (int)finalDamage;
                    otherMonster.mHealth = otherMonster.mHealth < 0 ? 0 : otherMonster.mHealth;
                    break;

                case 1:
                    finalDamage = defaultDamage * 1.5;
                    finalDamage = finalDamage < 1 ? 1 : finalDamage;
                    otherMonster.mHealth = otherMonster.mHealth - (int)finalDamage;
                    otherMonster.mHealth = otherMonster.mHealth < 0 ? 0 : otherMonster.mHealth;
                    break;
            }
        }

        public int DetermineComparactiveAdvantage(EElementType elementType, Monster otherMonster)
        {
            const int WEAK = -1;
            const int EQUAL = 0;
            const int STRONG = 1;

            switch (elementType)
            {
                case EElementType.Fire:
                    if (otherMonster.ElementType == EElementType.Wind)
                    {
                        return STRONG;
                    }

                    else if (otherMonster.ElementType == EElementType.Fire)
                    {
                        return EQUAL;
                    }

                    return WEAK;

                case EElementType.Water:
                    if (otherMonster.ElementType == EElementType.Fire)
                    {
                        return STRONG;
                    }
                    else if (otherMonster.ElementType == EElementType.Wind)
                    {
                        return WEAK;
                    }
                    else
                    {
                        return EQUAL;
                    }

                case EElementType.Earth:
                    if (otherMonster.ElementType == EElementType.Fire)
                    {
                        return STRONG;
                    }
                    else if (otherMonster.ElementType == EElementType.Wind)
                    {
                        return WEAK;
                    }
                    else
                    {
                        return EQUAL;
                    }

                case EElementType.Wind:
                    if (otherMonster.ElementType == EElementType.Fire)
                    {
                        return WEAK;
                    }

                    else if (otherMonster.ElementType == EElementType.Wind)
                    {
                        return EQUAL;
                    }

                    return STRONG;

                default:
                    Debug.Assert(false);
                    break;
            }

            return EQUAL;
        }
    }
}
