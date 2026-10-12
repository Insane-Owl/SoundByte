using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using NAudio.Wave;

namespace SoundByte
{
    public class AudioSound : IPlayable
    {
        public string ClipName { get; set; }
        public string FilePath { get; set; }
        public int VolumeLevel { get; set; }
        public bool IsActive { get; set; }

        private List<WaveOut> _activePlayers = new List<WaveOut>();
        public event EventHandler PlaybackEnded;

        public AudioSound()
        {
            VolumeLevel = 100;
            IsActive = false;
        }

        public AudioSound(string name, string path)
        {
            ClipName = name;
            FilePath = path;
            VolumeLevel = 100;
            IsActive = false;
        }

        public virtual async Task PlaySoundAsync(int masterVolume)
        {
            if (!File.Exists(FilePath)) return;

            IsActive = true;
            AudioFileReader audioReader = new AudioFileReader(FilePath);
            audioReader.Volume = (float)((VolumeLevel / 100.0) * (masterVolume / 100.0));
            WaveOut player = new WaveOut();
            player.Init(audioReader);
            _activePlayers.Add(player);

            player.PlaybackStopped += (s, e) =>
            {
                _activePlayers.Remove(player);
                player.Dispose();
                audioReader.Dispose();
                if (_activePlayers.Count == 0)
                {
                    IsActive = false;
                    PlaybackEnded?.Invoke(this, EventArgs.Empty);
                }
            };

            player.Play();
            await Task.CompletedTask;
        }

        public virtual void StopSound()
        {
            foreach (var player in _activePlayers.ToList())
            {
                player.Stop();
            }
        }
    }
}
