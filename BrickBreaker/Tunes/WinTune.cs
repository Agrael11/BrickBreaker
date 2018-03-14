using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker.Tunes
{
    class WinTune : Tune
    {
        public WinTune()
        {
            string noteTr
                    = "84C 84E 84G 25H#";
            notes = generateFromText(noteTr, 125);
        }
    }
}
