using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker
{
    public class Game
    {                                                                                               //
        public enum SceneNames { INTRO, MENU, NEWGAME, LOADGAME, OVERWRITE, PAUSE, EXIT, HIGHSCORE, INGAME, INVALID}

        public static Random random;
        public SceneNames Scene = SceneNames.INTRO;

        public int SaveSlotID;
        public Internals.Slot SaveSlot;

        public static ConsoleColor WindowBG = ConsoleColor.Gray;
        public static ConsoleColor WindowFG = ConsoleColor.Blue;
        public static ConsoleColor WindowFN = ConsoleColor.White;
        public static ConsoleColor ButtonBG = ConsoleColor.DarkGray;
        public static ConsoleColor ButtonBGS = ConsoleColor.Cyan;
        public static ConsoleColor ButtonFN = ConsoleColor.White;
        public static ConsoleColor ButtonFNS = ConsoleColor.Black;


        Scenes.IntroLogo logoScene = new Scenes.IntroLogo();
        Scenes.MenuScene menuScene = new Scenes.MenuScene();
        Scenes.NewGame newScene = new Scenes.NewGame();
        Scenes.Overwrite overScene = new Scenes.Overwrite();
        Scenes.LoadGame loadScene = new Scenes.LoadGame();
        Scenes.Invalid invalidScene = new Scenes.Invalid();
        Scenes.Highscores highscoreScene = new Scenes.Highscores();
        Scenes.ExitQuest exitScene = new Scenes.ExitQuest();
        Scenes.InGame ingameScene = new Scenes.InGame();
        Scenes.Pause pauseSceene = new Scenes.Pause();

        public int Return = -1;
        public int ReturnInf = -1;

        public void SwitchScene(SceneNames scn, bool reinit = true)
        {
            Scene = scn;
            if (reinit)
            {
                switch (scn)
                {
                    case SceneNames.INTRO: logoScene.Init(); break;
                    case SceneNames.MENU: menuScene.Init(); break;
                    case SceneNames.NEWGAME: newScene.Init(); break;
                    case SceneNames.OVERWRITE: overScene.Init(); break;
                    case SceneNames.LOADGAME: loadScene.Init(); break;
                    case SceneNames.INVALID: invalidScene.Init(); break;
                    case SceneNames.HIGHSCORE: highscoreScene.Init(); break;
                    case SceneNames.EXIT: exitScene.Init(); break;
                    case SceneNames.INGAME: ingameScene.Init(); break;
                    case SceneNames.PAUSE: pauseSceene.Init(); break;
                }
            }
            PlayMusic();
        }

        public void Init()
        {
            SwitchScene(SceneNames.MENU);
        }

        public void Update()
        {
            switch (Scene)
            {
                case SceneNames.INTRO: logoScene.Update(); break;
                case SceneNames.MENU: menuScene.Update(); break;
                case SceneNames.NEWGAME: newScene.Update(); break;
                case SceneNames.OVERWRITE: overScene.Update(); break;
                case SceneNames.LOADGAME: loadScene.Update(); break;
                case SceneNames.INVALID: invalidScene.Update(); break;
                case SceneNames.HIGHSCORE: highscoreScene.Update(); break;
                case SceneNames.EXIT: exitScene.Update(); break;
                case SceneNames.INGAME: ingameScene.Update(); break;
                case SceneNames.PAUSE: pauseSceene.Update(); break;
            }
        }

        public void Draw()
        {
            Renderer.DrawBegin();
            switch (Scene)
            {
                case SceneNames.INTRO: logoScene.Draw(); break;
                case SceneNames.MENU: menuScene.Draw(); break;
                case SceneNames.NEWGAME: menuScene.Draw(); newScene.Draw(); break;
                case SceneNames.OVERWRITE: menuScene.Draw(); newScene.Draw(); overScene.Draw(); break;
                case SceneNames.LOADGAME: menuScene.Draw(); loadScene.Draw(); break;
                case SceneNames.INVALID: menuScene.Draw(); loadScene.Draw(); invalidScene.Draw(); break;
                case SceneNames.HIGHSCORE: highscoreScene.Draw(); break;
                case SceneNames.EXIT: menuScene.Draw(); exitScene.Draw(); break;
                case SceneNames.INGAME: ingameScene.Draw(); break;
                case SceneNames.PAUSE: ingameScene.Draw(); pauseSceene.Draw(); break;
            }
            Renderer.DrawEnd();
        }

        public void PlayMusic()
        {
            switch (Scene)
            {
                case SceneNames.INTRO: logoScene.PlayMusic(); break;
                case SceneNames.MENU: menuScene.PlayMusic(); break;
                case SceneNames.HIGHSCORE: highscoreScene.PlayMusic(); break;
                case SceneNames.INGAME: ingameScene.PlayMusic(); break;
            }
        }
    }
}
