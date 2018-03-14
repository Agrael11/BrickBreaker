using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker.Scenes
{
    class Overwrite
    {
        bool _selected = true;

        public void Init()
        {
            _selected = false;
        }

        public void Update()
        {
            if (ConsoleKeyboard.KeyAvailable)
            {
                switch (ConsoleKeyboard.PressedKey)
                {
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        _selected = !_selected;
                        break;
                    case ConsoleKey.Enter:
                        if (_selected) Program.Game.Return = 1;
                        else Program.Game.Return = 0;
                        Program.Game.SwitchScene(Game.SceneNames.NEWGAME);
                        break;
                }
            }
        }
        

        public void Draw()
        {
            Renderer.DrawWindow(new Rectangle(27, 8, 26, 7), "OVERWRITE FILE?", Game.WindowFG, Game.WindowBG, Game.WindowFN);
            Renderer.DrawButton(new Rectangle(30, 10, 9, 3), "YES", (_selected) ? Game.ButtonBGS : Game.ButtonBG, (_selected) ? Game.ButtonFNS : Game.ButtonFN);
            Renderer.DrawButton(new Rectangle(42, 10, 8, 3), "NO", (!_selected) ? Game.ButtonBGS : Game.ButtonBG, (!_selected) ? Game.ButtonFNS : Game.ButtonFN);
        }
    }
}
