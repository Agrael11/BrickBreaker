using System;
using System.Collections.Generic;
using ConsoleGameUtilities;

namespace BrickBreaker.Tunes
{
    public class LogoTune : Tune
    {
        public LogoTune()
        {
            string noteTr
                    = "84D 84D 24D 84E 84E 24E 23A";
            notes = generateFromText(noteTr, 100);
        }
    }
}
