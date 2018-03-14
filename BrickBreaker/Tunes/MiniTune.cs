using System;
using System.Collections.Generic;
using ConsoleGameUtilities;

namespace BrickBreaker.Tunes
{
    public class MiniTune : Tune
    {
        public MiniTune()
        {
            string noteTr
                    = "44E 44C 44F 44A 44G 44A 44G 44F";
            notes = generateFromText(noteTr, 125);
        }
    }
}
