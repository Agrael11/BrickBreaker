using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker.Tunes
{
    class BrickNormTune : Tune
    {
        public BrickNormTune()
        {
            string noteTr
                    = "42D";
            notes = generateFromText(noteTr, 100);
        }
    }
}
