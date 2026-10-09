using System;
using System.Collections.Generic;
using System.Text;
using System.Media;
using System.Threading.Tasks;

namespace SoundByte
{
    public class AudioSound : IPlayable
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

        public virtual async Task PlaySoundAsync()
        {
            if (string.IsNullOrWhiteSpace(FilePath)) return;

            IsActive = true;
            await Task.Run(() =>
            {
                using (SoundPlayer player = new SoundPlayer(FilePath))
                {
                    player.PlaySync();
                }
            });
            IsActive = false;
        }

        public virtual void StopSound()
        {
            // Audio engine logic will go here later
        }
    }
}
