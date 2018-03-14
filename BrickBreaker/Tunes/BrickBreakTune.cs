using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker.Tunes
{
    class BrickBreakTune : Tune
    {
        public BrickBreakTune()
        {
            string noteTr
                    = "82D 82F";
            notes = generateFromText(noteTr, 100);
        }
    }
}
