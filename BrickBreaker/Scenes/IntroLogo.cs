using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker.Scenes
{
    class IntroLogo
    {
        int timer = 0;
        Sprite spr1;
        Sprite spr2;
        Sprite spr3;

        public void Init()
        {
            spr1 = Sprite.Load("Sprites\\TG1.SPR");
            spr2 = Sprite.Load("Sprites\\TG2.SPR");
            spr3 = Sprite.Load("Sprites\\TG3.SPR");
        }

        public void Update()
        {
            if (NotePlayer.Stopped)
            {
                timer++;
                if (timer == 60) Program.Game.SwitchScene(Game.SceneNames.MENU);
            }
        }

        public void DrawLogo()
        {


            //Circle
            Renderer.DrawRectangle(new Rectangle(2, 7, 2, 9), ConsoleColor.White);
            Renderer.DrawRectangle(new Rectangle(4, 6, 2, 1), ConsoleColor.White);
            Renderer.DrawRectangle(new Rectangle(4, 16, 2, 1), ConsoleColor.White);
            Renderer.DrawRectangle(new Rectangle(6, 5, 42, 1), ConsoleColor.White);
            Renderer.DrawRectangle(new Rectangle(6, 17, 42, 1), ConsoleColor.White);
            Renderer.DrawRectangle(new Rectangle(48, 6, 2, 1), ConsoleColor.White);
            Renderer.DrawRectangle(new Rectangle(48, 16, 2, 1), ConsoleColor.White);
            Renderer.DrawRectangle(new Rectangle(50, 7, 2, 9), ConsoleColor.White);

            //T
            Renderer.DrawRectangle(new Rectangle(5, 8, 44, 1), ConsoleColor.Cyan);
            Renderer.DrawRectangle(new Rectangle(8, 9, 1, 7), ConsoleColor.Cyan);

            //-
            Renderer.DrawRectangle(new Rectangle(10, 12, 2, 1), ConsoleColor.Cyan);

            //G
            Renderer.DrawRectangle(new Rectangle(13, 10, 1, 6), ConsoleColor.Cyan);
            Renderer.DrawRectangle(new Rectangle(14, 10, 3, 1), ConsoleColor.Cyan);
            Renderer.DrawRectangle(new Rectangle(14, 15, 3, 1), ConsoleColor.Cyan);
            Renderer.DrawRectangle(new Rectangle(16, 13, 1, 2), ConsoleColor.Cyan);
            Renderer.DrawPoint(new Vector2(15, 13), ConsoleColor.Cyan);

            //A
            Renderer.DrawRectangle(new Rectangle(18, 10, 1, 6), ConsoleColor.Cyan);
            Renderer.DrawRectangle(new Rectangle(19, 10, 2, 1), ConsoleColor.Cyan);
            Renderer.DrawRectangle(new Rectangle(19, 12, 2, 1), ConsoleColor.Cyan);
            Renderer.DrawRectangle(new Rectangle(21, 10, 1, 6), ConsoleColor.Cyan);

            //M
            Renderer.DrawRectangle(new Rectangle(23, 10, 1, 6), ConsoleColor.Cyan);
            Renderer.DrawPoint(new Vector2(24, 11), ConsoleColor.Cyan);
            Renderer.DrawPoint(new Vector2(25, 12), ConsoleColor.Cyan);
            Renderer.DrawPoint(new Vector2(26, 11), ConsoleColor.Cyan);
            Renderer.DrawRectangle(new Rectangle(27, 10, 1, 6), ConsoleColor.Cyan);

            //E
            Renderer.DrawRectangle(new Rectangle(29, 10, 1, 6), ConsoleColor.Cyan);
            Renderer.DrawRectangle(new Rectangle(30, 10, 2, 1), ConsoleColor.Cyan);
            Renderer.DrawRectangle(new Rectangle(30, 15, 2, 1), ConsoleColor.Cyan);
            Renderer.DrawPoint(new Vector2(30, 12), ConsoleColor.Cyan);

            //S
            Renderer.DrawRectangle(new Rectangle(33, 10, 1, 3), ConsoleColor.Cyan);
            Renderer.DrawRectangle(new Rectangle(34, 10, 2, 1), ConsoleColor.Cyan);
            Renderer.DrawPoint(new Vector2(34, 12), ConsoleColor.Cyan);
            Renderer.DrawRectangle(new Rectangle(35, 13, 1, 3), ConsoleColor.Cyan);
            Renderer.DrawRectangle(new Rectangle(33, 15, 2, 1), ConsoleColor.Cyan);

            //C
            Renderer.DrawPoint(new Vector2(38, 13), ConsoleColor.Green);
            Renderer.DrawPoint(new Vector2(37, 14), ConsoleColor.Green);
            Renderer.DrawPoint(new Vector2(38, 15), ConsoleColor.Green);

            //O
            Renderer.DrawPoint(new Vector2(41, 13), ConsoleColor.Green);
            Renderer.DrawPoint(new Vector2(40, 14), ConsoleColor.Green);
            Renderer.DrawPoint(new Vector2(41, 15), ConsoleColor.Green);
            Renderer.DrawPoint(new Vector2(42, 14), ConsoleColor.Green);

            //O
            Renderer.DrawRectangle(new Rectangle(44, 13, 1, 3), ConsoleColor.Green);
            Renderer.DrawPoint(new Vector2(45, 13), ConsoleColor.Green);
            Renderer.DrawRectangle(new Rectangle(46, 14, 1, 2), ConsoleColor.Green);
        }

        public void Draw()
        {
            Renderer.Clean();
            Renderer.DrawSprite(new Vector2(0, 0), spr1);
            Renderer.DrawSprite(new Vector2(32, 0), spr2);
            Renderer.DrawSprite(new Vector2(64, 0), spr3);

            string infoStrNameBlue = "T-Games";
            string infoStrNameGreen = "Console";
            string infoStrMB = "Made using CGU.NET technology.";
            string infoStrWB = "www.tgames.sk";
            Renderer.DrawString(infoStrNameBlue, new Vector2(40 - (infoStrNameBlue.Length + 1 + infoStrNameGreen.Length) / 2, 14), ConsoleColor.Cyan);
            Renderer.DrawString(infoStrNameGreen, new Vector2(40 - ((infoStrNameBlue.Length + 1 + infoStrNameGreen.Length) / 2) + 1 + infoStrNameBlue.Length, 14), ConsoleColor.Green);
            Renderer.DrawString(infoStrMB, new Vector2(80 - infoStrMB.Length, 23), ConsoleColor.Gray);
            Renderer.DrawString(infoStrWB, new Vector2(1, 23), ConsoleColor.Gray);
        }

        public void PlayMusic()
        {
            NotePlayer.PlayTune(new Tunes.LogoTune());
        }
    }
}
