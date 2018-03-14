using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker.Scenes
{
    class MenuScene
    {
        Sprite spr1;
        Sprite spr2;
        
        int _SelectedValue = 0;

        int _Selected
        {
            get { return _SelectedValue; }
            set
            {
                _SelectedValue = value;
                while (_SelectedValue < 0) _SelectedValue +=4;
                _SelectedValue %= 4;
            }
        }
        public void Init()
        {
            spr1 = Sprite.Load("Sprites\\BB1.SPR");
            spr2 = Sprite.Load("Sprites\\BB2.SPR");
        }

        public void Update()
        {
            if (ConsoleKeyboard.KeyAvailable)
            {
                switch (ConsoleKeyboard.PressedKey)
                {
                    case ConsoleKey.D:
                    case ConsoleKey.S:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.DownArrow: _Selected++;break;
                    case ConsoleKey.A:
                    case ConsoleKey.W:
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.UpArrow: _Selected--;break;
                    case ConsoleKey.Enter: switch (_Selected)
                        {
                            case 0: Program.Game.SwitchScene(Game.SceneNames.NEWGAME); break;
                            case 1: Program.Game.SwitchScene(Game.SceneNames.LOADGAME);break;
                            case 2: Program.Game.SwitchScene(Game.SceneNames.HIGHSCORE); break;
                            case 3: Program.Game.SwitchScene(Game.SceneNames.EXIT); break;
                        }break;
                }
            }
        }

        public void Draw()
        {
            Renderer.Clean();
            Renderer.DrawSprite(new Vector2(15, 1), spr1);
            Renderer.DrawSprite(new Vector2(32+15, 1), spr2);
            Renderer.DrawWindow(new Rectangle(2, 15, 77, 7), "MAIN MENU", Game.WindowFG, Game.WindowBG, Game.WindowFN);
            Renderer.DrawButton(new Rectangle(4, 17, 18, 3), "NEW GAME",  (_Selected == 0) ? Game.ButtonBGS : Game.ButtonBG, (_Selected == 0) ? Game.ButtonFNS : Game.ButtonFN);
            Renderer.DrawButton(new Rectangle(23, 17, 17, 3), "LOAD GAME", (_Selected == 1) ? Game.ButtonBGS : Game.ButtonBG, (_Selected == 1) ? Game.ButtonFNS : Game.ButtonFN);
            Renderer.DrawButton(new Rectangle(41, 17, 17, 3), "HIGH SCORES", (_Selected == 2) ? Game.ButtonBGS : Game.ButtonBG, (_Selected == 2) ? Game.ButtonFNS : Game.ButtonFN);
            Renderer.DrawButton(new Rectangle(59, 17, 18, 3), "EXIT", (_Selected == 3) ? Game.ButtonBGS : Game.ButtonBG, (_Selected == 3) ? Game.ButtonFNS : Game.ButtonFN);
            Renderer.DrawString("BrickBreaker 1.0", new Vector2(0, 23), ConsoleColor.Gray);
            Renderer.DrawString("by Tachi23 (C)2016", new Vector2(0, 24), ConsoleColor.Gray);
            string[] TT = Renderer.GetVerInfo().Split('\n');
            for (int i = 0; i < TT.Length; i++)
            {
                Renderer.DrawString(TT[i], new Vector2(80-TT[i].Length, 25-TT.Length+i), ConsoleColor.Gray);
            }
        }

        Tunes.MiniTune mini = new Tunes.MiniTune();
        
        public void PlayMusic()
        {
            NotePlayer.PlayTune(mini);
        }
    }
}
