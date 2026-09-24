using System;
using System.Collections.Generic;
using System.Text;

namespace SoundByte
{
    internal class HotkeySound : AudioSound
    {
        public string HotkeyText { get; set; }
        public int RawKeyCode { get; set; }

        public HotkeySound(string name, string path, string keyText, int keyCode) : base(name, path)
        {
            HotkeyText = keyText;
            RawKeyCode = keyCode;
        }

        public void AssignHotkey(string keyText, int keyCode)
        {
            HotkeyText = keyText;
            RawKeyCode = keyCode;
        }
    }
}
