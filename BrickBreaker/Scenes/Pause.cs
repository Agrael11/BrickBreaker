using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker.Scenes
{
    class Pause
    {
        bool _selected = true;

        public void Init()
        {
            _selected = true;
        }

        public void Update()
        {
            if (ConsoleKeyboard.KeyAvailable)
            {
                switch (ConsoleKeyboard.PressedKey)
                {
                    case ConsoleKey.S:
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                    case ConsoleKey.DownArrow:
                        _selected = !_selected;
                        break;
                    case ConsoleKey.Enter:
                        if (_selected) Program.Game.SwitchScene(Game.SceneNames.INGAME, false);
                        else Program.Game.SwitchScene(Game.SceneNames.MENU);
                        break;
                }
            }
        }
        

        public void Draw()
        {
            Renderer.DrawWindow(new Rectangle(28, 6, 24, 11), "PAUSE MENU", Game.WindowFG, Game.WindowBG, Game.WindowFN);
            Renderer.DrawButton(new Rectangle(31, 8, 18, 3), "RETURN TO GAME", (_selected) ? Game.ButtonBGS : Game.ButtonBG, (_selected) ? Game.ButtonFNS : Game.ButtonFN);
            Renderer.DrawButton(new Rectangle(31, 12, 18, 3), "EXIT TO MENU", (!_selected) ? Game.ButtonBGS : Game.ButtonBG, (!_selected) ? Game.ButtonFNS : Game.ButtonFN);
        }
    }
}
