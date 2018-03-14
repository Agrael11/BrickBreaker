using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker.Internals
{
    class Powerup
    {
        public TYPES type;
        public string Symbol;
        public ConsoleColor color;
        public Vector2 pos;
        public float half = 0;

        public enum TYPES { LIVEUP, LIVEDOWN, BIGGER, SMALLER, GLUE}

        public static Powerup Build(TYPES type)
        {
            Powerup pu = new Powerup();
            pu.type = type;

            switch (type)
            {
                case TYPES.BIGGER: pu.Symbol = "<  >"; pu.color = ConsoleColor.Green; break;
                case TYPES.LIVEUP: pu.Symbol = "++++"; pu.color = ConsoleColor.Green; break;
                case TYPES.GLUE: pu.Symbol = "~~~~"; pu.color = ConsoleColor.Green; break;
                case TYPES.SMALLER: pu.Symbol = ">  <"; pu.color = ConsoleColor.Red; break;
                case TYPES.LIVEDOWN: pu.Symbol = "----"; pu.color = ConsoleColor.Red; break;
            }
            return pu;
        }

        public static Powerup BuildRandom()
        {
            int typ = Program.Random.Next(0, Enum.GetNames(typeof(TYPES)).Length);
            TYPES type = (TYPES)typ;
            return Build(type);
        }
    }
}
