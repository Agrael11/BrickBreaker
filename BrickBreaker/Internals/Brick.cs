using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker.Internals
{
    [Serializable]
    public class Brick
    {
        public int HP = 0;
        public int MaxHP = 0;
        public ConsoleColor Color = ConsoleColor.DarkYellow;
        public DESTBEH DestroyBehavior = DESTBEH.REFLECT;
        public bool Empty = false;
        

        public enum DESTBEH { NONE, REFLECT, EXPLODE}
        public enum TYPES { DIRT, WOOD, STONE, GOLD, METAL, TNT, EMPTY };

        public bool DoDemage(bool doubleDemage=false)
        {
            if (MaxHP > 0)
            {
                HP--;
                if (doubleDemage) HP--;

                if (HP <= 0) return true;
            }
            return false;
        }

        public int State
        {
            get
            {
                float perc = (HP * 4) / (float)MaxHP;
                return (int)perc;
            }
        }

        public static Brick Build(TYPES type)
        {
            Brick brick = new Brick();

            switch (type)
            {
                case TYPES.TNT: brick.HP = 1; brick.MaxHP = 1; brick.Color = ConsoleColor.Red; brick.DestroyBehavior = DESTBEH.EXPLODE; break;
                case TYPES.METAL: brick.HP = -1; brick.MaxHP = -1; brick.Color = ConsoleColor.Cyan; break;
                case TYPES.GOLD: brick.HP = 3; brick.MaxHP = 3; brick.Color = ConsoleColor.Yellow; break;
                case TYPES.STONE: brick.HP = 2; brick.MaxHP = 2; brick.Color = ConsoleColor.Gray; break;
                case TYPES.WOOD: brick.HP = 1; brick.MaxHP = 1; brick.Color = ConsoleColor.Green; break;
                case TYPES.DIRT: brick.HP = 1; brick.MaxHP = 1; brick.Color = ConsoleColor.Blue; brick.DestroyBehavior = DESTBEH.NONE; break;
                case TYPES.EMPTY:
                default: brick.Empty = true; break;
            }
            return brick;
        }

        public static Brick BuildRandom(int emptyChance = 0, int steelChance=1)
        {
            int chance = Program.Random.Next(1, 10);
            int typ = Program.Random.Next(0, Enum.GetNames(typeof(TYPES)).Length);
            TYPES type = (TYPES)typ;
            if (type == TYPES.METAL)
            {
                if ((chance > 0) && (chance < steelChance)) ;
                else type = TYPES.GOLD;
            }
            if (type == TYPES.EMPTY)
            {
                if ((chance > 0) && (chance < emptyChance)) ;
                else type = TYPES.DIRT;
            }
            return Build(type);
        }
    }
}
