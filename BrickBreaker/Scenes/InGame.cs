using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker.Scenes
{
    class InGame
    {
        public int padPosition;
        public Vector2 ballPosition;
        public Vector2 lastPosition;
        public int padSize;
        public Vector2 ballVelocity;
        bool _started = false;

        bool glue = false;

        List<Internals.Powerup> powerups = new List<Internals.Powerup>();

        Tunes.BrickNormTune brickNormTune;
        Tunes.BrickSteelTune brickSteelTune;
        Tunes.BrickBreakTune brickDestTune;
        Tunes.WinTune winTune;
        Tunes.MainTune mainTune;
        Tunes.EndTune endTune;

        public Internals.Brick[,] brickMap = new Internals.Brick[15, 10];

        public void Init()
        {
            brickNormTune = new Tunes.BrickNormTune();
            brickSteelTune = new Tunes.BrickSteelTune();
            brickDestTune = new Tunes.BrickBreakTune();
            winTune = new Tunes.WinTune();
            mainTune = new Tunes.MainTune();
            endTune = new Tunes.EndTune();
            padPosition = 35;
            ballPosition = new Vector2(padPosition + 4, 21);
            lastPosition = ballPosition;
            ballVelocity = new Vector2(2, -1);
            padSize = 2;
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 15; x++)
                {
                    brickMap[x, y] = Internals.Brick.Build(Internals.Brick.TYPES.EMPTY);
                }
            }
            ResetLevel(Program.Game.SaveSlot.Level);
        }

        public void ResetLevel(int level)
        {
            powerups.Clear();
            Internals.Slot.Save("slot" + Program.Game.SaveSlotID + ".slt", Program.Game.SaveSlot);
            NotePlayer.PlayTuneSec(winTune);
            padPosition = 23;
            ballPosition = new Vector2(padPosition + (20/padSize)/2-1, 21);
            lastPosition = ballPosition;
            ballVelocity = new Vector2(2, -1);
            glue = false;
            padSize = 2;
            int ysize = level;
            int stlch = level;
            int emtch = 10-level;
            if (level < 3) ysize = 3;
            if (level > 8) ysize = 8;
            if (emtch < 0) emtch = 0;
            if (stlch > 7) stlch = 7;
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 15; x++)
                {
                    if (y < ysize)
                        //brickMap[x, y] = Internals.Brick.Build(Internals.Brick.TYPES.GOLD);
                        brickMap[x, y] = Internals.Brick.BuildRandom(emtch, stlch);
                    else
                        brickMap[x, y] = Internals.Brick.Build(Internals.Brick.TYPES.EMPTY);
                }
            }
        }

        int timer = 0;
        int timerMax = 3;

        public void Update()
        {
            bool dead = false;
            if (!_started) ballPosition = new Vector2(padPosition + (20 / padSize) / 2 - 1, 21);
            Console.Title = "Lives: " + Program.Game.SaveSlot.Lives;
            Console.Title += ", Level: " + Program.Game.SaveSlot.Level;
            Console.Title += ", Score: " + Program.Game.SaveSlot.Score;
            if (ConsoleKeyboard.KeyAvailable)
            {
                switch (ConsoleKeyboard.PressedKey)
                {
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        padPosition -= 2;
                        if (padPosition <= 1)
                            padPosition = 1;
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        padPosition += 2;
                        if (padPosition >= 54 - (20 / padSize))
                            padPosition = 54 - (20 / padSize);
                        break;
                    case ConsoleKey.Spacebar:
                        if (!_started) _started = true;break;
                    case ConsoleKey.Escape:
                        Program.Game.SwitchScene(Game.SceneNames.PAUSE);break;
                }
            }
            if (_started)
            {


                timer++;

                if (timer == timerMax)
                {
                    if ((ballPosition.X <= 1) && (ballVelocity.X < 0))
                    {
                        ballVelocity.X *= -1;
                        ballPosition.X = 1;
                    }
                    else if ((ballPosition.X >= 51) && (ballVelocity.X > 0))
                    {
                        ballPosition.X = 51;
                        ballVelocity.X *= -1;
                    }
                    if ((ballPosition.Y <= 1) && (ballVelocity.Y < 0))
                    {
                        ballVelocity.Y *= -1;
                        ballPosition.Y = 1;
                    }
                    else if ((ballPosition.Y >= 24) && (ballVelocity.Y > 0))
                    {
                        //ballPosition.Y = 24;
                        //ballVelocity.Y *= -1;
                        dead = true;
                    }
                    Rectangle fakeRectangleBall = new Rectangle(ballPosition, 2, 2);

                    Rectangle padFakeRectangleLeft = new Rectangle(padPosition, 23, (20 / padSize / 2), 1);
                    Rectangle padFakeRectangleRight = new Rectangle(padPosition + (20 / padSize / 2), 23, (20 / padSize / 2), 1);
                    int r = 0;
                    if (fakeRectangleBall.Intersects(padFakeRectangleLeft))
                    {
                        if (ballVelocity.X > 0) ballVelocity.X *= -1;
                        ballVelocity.Y *= -1;
                        r++;
                        if (glue) _started = false;
                    }
                    if (fakeRectangleBall.Intersects(padFakeRectangleRight))
                    {
                        r++;
                        if (ballVelocity.X < 0) ballVelocity.X *= -1;
                        if (r != 2) ballVelocity.Y *= -1;
                        if (glue) _started = false;
                    }

                    for (int x = 0; x < 10; x++)
                    {
                        for (int y = 0; y < 10; y++)
                        {
                            if (!brickMap[x, y].Empty)
                            {
                                Rectangle fakeRectangleBrick = new Rectangle(3 + x * 5, 2 + y * 2, 4, 1);
                                if (fakeRectangleBall.Intersects(fakeRectangleBrick))
                                {
                                    Program.Game.SaveSlot.Score += 10;
                                    bool dst = brickMap[x, y].DoDemage();
                                    if (dst)
                                    {
                                        brickMap[x, y].Empty = true; Program.Game.SaveSlot.Score += 90;
                                        NotePlayer.PlayTuneSec(brickDestTune);
                                        int chn = Program.Random.Next(0, 4);
                                        if (chn == 1)
                                        {
                                            Internals.Powerup pu = Internals.Powerup.BuildRandom();
                                            pu.pos = new Vector2(x, y * 2);
                                            powerups.Add(pu);
                                        }
                                    }
                                    else
                                    {
                                        if (brickMap[x, y].MaxHP == -1) NotePlayer.PlayTuneSec(brickSteelTune);
                                        else NotePlayer.PlayTuneSec(brickNormTune);
                                    }
                                    if ((!dst || (brickMap[x, y].DestroyBehavior != Internals.Brick.DESTBEH.NONE)))
                                    {
                                        Rectangle fakeRectangleBallHorOnl = new Rectangle(new Vector2(ballPosition.X, lastPosition.Y), 2, 2);
                                        if (fakeRectangleBallHorOnl.Intersects(fakeRectangleBrick))
                                        {
                                            ballVelocity.X *= -1;
                                        }
                                        else
                                        {
                                            ballVelocity.Y *= -1;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    lastPosition = new Vector2(ballPosition.X, ballPosition.Y);
                    ballPosition += ballVelocity;
                    foreach (Internals.Powerup pu in powerups)
                    {
                        if (pu.pos.Y < 30)
                        {
                            pu.half += 0.4f;
                            if (pu.half > 1)
                            {
                                pu.pos.Y++;
                                pu.half = 0;
                            }
                            Rectangle padFakeRectangle = new Rectangle(padPosition, 23, 20 / padSize, 1);
                            Rectangle powerupRectangle = new Rectangle(3 + pu.pos.X * 5, 2 + pu.pos.Y, 4, 1);
                            if (padFakeRectangle.Intersects(powerupRectangle))
                            {
                                switch (pu.type)
                                {
                                    case Internals.Powerup.TYPES.BIGGER: padSize = 1; break;
                                    case Internals.Powerup.TYPES.GLUE: glue = true; break;
                                    case Internals.Powerup.TYPES.LIVEDOWN: dead = true; break;
                                    case Internals.Powerup.TYPES.LIVEUP: Program.Game.SaveSlot.Lives++; break;
                                    case Internals.Powerup.TYPES.SMALLER: padSize = 3; break;
                                }
                                pu.pos.Y += 30;
                            }
                        }
                    }

                    if (dead)
                    {
                        Program.Game.SaveSlot.Lives--;
                        if (Program.Game.SaveSlot.Lives < 1)
                        {
                            NotePlayer.PlayTuneSec(endTune);
                            while (NotePlayer.Paused) ;
                            Program.Game.ReturnInf = Program.Game.SaveSlot.Score;
                            Program.Game.Return = 0;
                            Program.Game.SwitchScene(Game.SceneNames.HIGHSCORE);
                        }
                        else ResetLevel(Program.Game.SaveSlot.Level);
                    }

                    timer = 0;
                    
                    bool empty = true;
                    for (int y = 0; y < 10; y++)
                    {
                        for (int x = 0; x < 10; x++)
                        {
                            if ((brickMap[x, y].Empty) || (brickMap[x, y].MaxHP == -1)) ;
                            else empty = false;
                        }
                    }
                    if (empty)
                    {
                        Program.Game.SaveSlot.Level++;
                        ResetLevel(Program.Game.SaveSlot.Level+1);
                    }
                }
            }
        }

        public void Draw()
        {
            Renderer.Clean(ConsoleColor.Gray);

            Renderer.DrawWindow(new Rectangle(0, 0, 55, 26), "BRICK BREAKER", ConsoleColor.Gray, ConsoleColor.DarkGray, ConsoleColor.Black);

            Renderer.DrawString("BRICK", new Vector2(64, 2), ConsoleColor.Black);
            Renderer.DrawString("  BREAKER", new Vector2(64, 3), ConsoleColor.Black);

            Renderer.DrawString("LEVEL: " + Program.Game.SaveSlot.Level.ToString(), new Vector2(56, 10), ConsoleColor.Black);
            Renderer.DrawString("LIVES:", new Vector2(56, 12), ConsoleColor.Black);
            if (Program.Game.SaveSlot.Lives <= 8)
            {
                for (int i = 0; i < Program.Game.SaveSlot.Lives; i++)
                {
                    Renderer.DrawPoint(new Vector2(63 + (i * 2), 12), ConsoleColor.Red);
                }
            }
            else Renderer.DrawString(Program.Game.SaveSlot.Lives.ToString(), new Vector2(63, 12), ConsoleColor.Black);
            Renderer.DrawString("SCORE: " + Program.Game.SaveSlot.Score.ToString(), new Vector2(56, 14), ConsoleColor.Black);

            Renderer.DrawRectangle(new Rectangle(padPosition, 23, 20 / padSize, 1), (glue)? ConsoleColor.Cyan : ConsoleColor.Blue);
            Renderer.DrawString("▒░".PadRight(20/padSize-2,' ') + "░▒", new Vector2(padPosition, 23), ConsoleColor.Black);

            Renderer.DrawRectangle(new Rectangle(ballPosition, 2, 1), ConsoleColor.Red);
            Renderer.DrawString("░░", ballPosition, ConsoleColor.Black);

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (!brickMap[x, y].Empty)
                        if (brickMap[x, y].MaxHP < 0)
                        {
                            Renderer.DrawRectangle(new Rectangle(3 + x * 5, 2 + y * 2, 4, 1), ConsoleColor.Red);
                            Renderer.DrawString("▓▓▓▓", new Vector2(3 + x * 5, 2 + y * 2), brickMap[x, y].Color);
                        }
                        else
                        {
                            Renderer.DrawRectangle(new Rectangle(3 + x * 5, 2 + y * 2, 4, 1), brickMap[x, y].Color);
                            switch (brickMap[x, y].State)
                            {
                                case 1: Renderer.DrawString("▓▓▓▓", new Vector2(3 + x * 5, 2 + y * 2), ConsoleColor.Black); break;
                                case 2: Renderer.DrawString("▒▓▒▓", new Vector2(3 + x * 5, 2 + y * 2), ConsoleColor.Black); break;
                                case 3: Renderer.DrawString("▒▒▒▒", new Vector2(3 + x * 5, 2 + y * 2), ConsoleColor.Black); break;
                            }
                        }
                }
            }

            foreach(Internals.Powerup pu in powerups)
            {
                Renderer.DrawRectangle(new Rectangle(3 + pu.pos.X * 5, 2 + pu.pos.Y, 4, 1), pu.color);
                Renderer.DrawString(pu.Symbol, new Vector2(3 + pu.pos.X * 5, 2 + pu.pos.Y), ConsoleColor.Black);
            }
        }

        public void PlayMusic()
        {
            NotePlayer.PlayTune(mainTune);
        }
    }
}
