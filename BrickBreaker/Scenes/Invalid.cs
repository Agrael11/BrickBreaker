using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker.Scenes
{
    class Invalid
    {

        public void Init()
        {
        }

        public void Update()
        {
            if (ConsoleKeyboard.KeyAvailable)
            {
                switch (ConsoleKeyboard.PressedKey)
                {
                    case ConsoleKey.Enter:
                        Program.Game.SwitchScene(Game.SceneNames.LOADGAME);
                        break;
                }
            }
        }
        

        public void Draw()
        {
            Renderer.DrawWindow(new Rectangle(27, 8, 26, 7), "SLOT NOT FREE", Game.WindowFG, Game.WindowBG, Game.WindowFN);
            Renderer.DrawButton(new Rectangle(36, 10, 8, 3), "OK", Game.ButtonBGS, Game.ButtonFNS);
        }
    }
}
