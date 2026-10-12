using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SoundByte
{
    public class AudioSound : IPlayable
    {
        public string ClipName { get; set; }
        public string FilePath { get; set; }
        public int VolumeLevel { get; set; }
        public bool IsActive { get; set; }

        private List<MediaPlayer> _activePlayers = new List<MediaPlayer>();
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
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri(FilePath, UriKind.Absolute));
            player.Volume = (VolumeLevel / 100.0) * (masterVolume / 100.0);
            _activePlayers.Add(player);

            player.MediaEnded += (s, e) =>
            {
                _activePlayers.Remove(player);
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
            foreach (var player in _activePlayers) player.Stop();
            _activePlayers.Clear();
            IsActive = false;
            PlaybackEnded?.Invoke(this, EventArgs.Empty);
        }
    }
}
