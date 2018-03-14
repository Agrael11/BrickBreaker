using System;
using System.Collections.Generic;
using ConsoleGameUtilities;

namespace BrickBreaker.Tunes
{
    public class EndTune : Tune
    {
        public EndTune()
        {
            string noteTr
                    = "44E 44C 43B 44C 44E 44F 44G 44F";
            notes = generateFromText(noteTr, 125);
            Loop = true;
        }
    }
}
