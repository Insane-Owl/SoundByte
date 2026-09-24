using System;
using System.Collections.Generic;
using System.Text;

namespace SoundByte
{
    internal class SoundManager
    {
        public string ProfileName { get; set; }
        public int MasterVolume { get; set; }
        public List<AudioSound> SoundList { get; private set; }

        public SoundManager()
        {
            SoundList = new List<AudioSound>();
            MasterVolume = 100;
        }

        public void AddSound(AudioSound sound)
        {
            SoundList.Add(sound);
        }

        public void RemoveSound(AudioSound sound)
        {
            SoundList.Remove(sound);
        }

        public void StopAll()
        {
            // Audio engine logic will go here later
        }
    }
}
