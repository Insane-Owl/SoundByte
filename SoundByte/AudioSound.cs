using System;
using System.Collections.Generic;
using System.Text;

namespace SoundByte
{
    internal class AudioSound
    {
        public string ClipName { get; set; }
        public string FilePath { get; set; }
        public int VolumeLevel { get; set; }
        public bool IsActive { get; set; }

        public AudioSound(string name, string path)
        {
            ClipName = name;
            FilePath = path;
            VolumeLevel = 100;
            IsActive = false;
        }

        public virtual void PlaySound()
        {
            // Audio engine logic will go here later
        }

        public virtual void StopSound()
        {
            // Audio engine logic will go here later
        }
    }
}
