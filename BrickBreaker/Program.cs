using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BrickBreaker
{
    class Program
    {
        public static Game Game;
        public static bool Running = true;
        public static Random Random;

        private static Thread _keyThread;
        private static Thread _render;

        private static void Main(string[] args)
        {
            Random = new Random();
            Renderer.Init();
            Renderer.WindowSize = new Vector2(80, 25);
            NotePlayer.Init();
            Game = new Game();
            Game.Init();
            _keyThread = new Thread(ConsoleKeyboard.CheckKey);
            _render = new Thread(RenderDraw);
            _keyThread.Start();
            _render.Start();
            while (Running)
            {
                Thread.Sleep(33);
                Game.Update();
                Game.Draw();
            }
            NotePlayer.Stop = true;
            _keyThread.Abort();
            _render.Abort();
        }

        private static void RenderDraw()
        {
            while (Running)
            {
                Renderer.Draw();
            }
        }
    }
}
