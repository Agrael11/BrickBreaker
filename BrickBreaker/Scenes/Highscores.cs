using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker.Scenes
{
    public class Highscores
    {
        int slot = -1;
        Internals.Highscores scores;

        public void Init()
        {
            slot = -1;
            scores = Internals.Highscores.Load("Scores.hsc");
        }

        public void Update()
        {
            if (Program.Game.Return != -1)
            {
                slot = scores.TryPut(Program.Game.ReturnInf, "");
                Program.Game.Return = -1;
                scores.Put(Program.Game.ReturnInf, "");
                Renderer.DrawBegin();
                Draw();
                Renderer.DrawEnd();
                Renderer.StopDrawing = true;
                while (!Renderer.DrawEnded) ;
                Console.CursorLeft = 14;
                Console.CursorTop = 3 + (slot * 2);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Blue;
                string nm = Console.ReadLine();
                Renderer.StopDrawing = false;
                scores = Internals.Highscores.Load("Scores.hsc");
                scores.Put(Program.Game.ReturnInf, nm);
                Internals.Highscores.Save("Scores.hsc", scores);
            }

            if (ConsoleKeyboard.KeyAvailable)
            {
                switch (ConsoleKeyboard.PressedKey)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Escape:
                        Program.Game.SwitchScene(Game.SceneNames.MENU);
                        break;
                }
            }
        }

        public void Draw()
        {
            Renderer.Clean();
            Renderer.DrawWindow(new Rectangle(8, 1, 64, 23), "HIGHSCORE TABLE", Game.WindowFG, Game.WindowBG, Game.WindowFN);
            for (int i = 0; i< 10; i++)
            {
                Renderer.DrawRectangle(new Rectangle(10, 3+(i*2), 60, 1), (slot == i) ? ConsoleColor.Green : ConsoleColor.Black);
                string name = (i + 1).ToString() + ". " + scores.Names[i];
                string score = scores.Scores[i].ToString();
                Renderer.DrawString(name, new Vector2(11, 3 + (i * 2)), (slot == i) ? ConsoleColor.Black : ConsoleColor.White);
                Renderer.DrawString(score, new Vector2(69 - score.Length, 3 + (i * 2)), (slot == i) ? ConsoleColor.Black : ConsoleColor.White);
            }
        }

        public void PlayMusic()
        {
            NotePlayer.Stop = true;
        }
    }
}
