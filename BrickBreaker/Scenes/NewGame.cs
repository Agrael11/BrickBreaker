using ConsoleGameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickBreaker.Scenes
{
    class NewGame
    {
        Internals.Slot[] slots = new Internals.Slot[3];

        int _selected = 0;

        public void Init()
        {
            slots[0] = Internals.Slot.Load("slot0.slt");
            slots[1] = Internals.Slot.Load("slot1.slt");
            slots[2] = Internals.Slot.Load("slot2.slt");
        }

        public void Update()
        {
            if (Program.Game.Return == 1)
            {
                Program.Game.Return = -1;
                Switch();
            }
            else if (ConsoleKeyboard.KeyAvailable)
            {
                switch (ConsoleKeyboard.PressedKey)
                {
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        _selected++;
                        if (_selected == 3) _selected = 0;
                        break;
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        if (_selected == 0) _selected = 3;
                        _selected--;
                        break;
                    case ConsoleKey.Escape:
                        Program.Game.SwitchScene(Game.SceneNames.MENU);
                        break;
                    case ConsoleKey.Enter:
                        if (slots[_selected].Used)
                        {
                            Program.Game.SwitchScene(Game.SceneNames.OVERWRITE);
                        }
                        else
                        {
                            Switch();
                        }
                        break;
                }
            }
        }

        public void Switch()
        {
            Program.Game.SaveSlotID = _selected;
            Program.Game.SaveSlot = new Internals.Slot() { Used = true };
            Program.Game.SwitchScene(Game.SceneNames.INGAME);
        }

        public void Draw()
        {
            Renderer.DrawWindow(new Rectangle(30, 1, 21, 24), "NEW GAME", Game.WindowFG, Game.WindowBG, Game.WindowFN);
            Renderer.DrawButton(new Rectangle(32, 3, 17, 6), GenerateSlotText(0, slots[0]), (_selected == 0) ? Game.ButtonBGS : Game.ButtonBG, (_selected == 0) ? Game.ButtonFNS : Game.ButtonFN);
            Renderer.DrawButton(new Rectangle(32, 10, 17, 6), GenerateSlotText(1, slots[1]), (_selected == 1) ? Game.ButtonBGS : Game.ButtonBG, (_selected == 1) ? Game.ButtonFNS : Game.ButtonFN);
            Renderer.DrawButton(new Rectangle(32, 17, 17, 6), GenerateSlotText(2, slots[2]), (_selected == 2) ? Game.ButtonBGS : Game.ButtonBG, (_selected == 2) ? Game.ButtonFNS : Game.ButtonFN);
        }

        private string GenerateSlotText(int slotID, Internals.Slot slot)
        {
            if ((slot != null) && (slot.Used))
            {
                return $"SLOT {slotID+1}\nLEVEL: {slot.Level}\nLIVES: {slot.Lives}\nSCORE: {slot.Score}";
            }
            else return $"SLOT {slotID+1}\nFREE";
        }
    }
}
