using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker.Tunes
{
    class BrickSteelTune : Tune
    {
        public BrickSteelTune()
        {
            string noteTr
                       = "43D";
            notes = generateFromText(noteTr, 100);
        }
    }
}
