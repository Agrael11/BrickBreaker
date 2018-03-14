using System;
using System.Collections.Generic;
using ConsoleGameUtilities;

namespace BrickBreaker.Tunes
{
    public class MainTune : Tune
    {
        public MainTune()
        {
            string noteTr
                    = "44E 44C 44F 44A 44G 44A 44G 44F 44E 44C 43B 44C 44E 44F 44G 44F";
            noteTr += "44E 44C 44F 44A 44G 44A 44G 44F 44E 44F 44G 44A 44G 44A 44A 44G 44A 44G 44G 44F 44E 44C 44E 44F";
            notes = generateFromText(noteTr, 125);
            Loop = true;
        }
    }
}
