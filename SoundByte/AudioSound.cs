using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace SoundByte
{
    public class AudioSound : IPlayable
    {
        public string ClipName { get; set; }
        public string FilePath { get; set; }
        public int VolumeLevel { get; set; }
        public bool IsActive { get; set; }

        private List<WaveOut> _activePlayers = new List<WaveOut>();
        private byte[] _cachedAudioData; // stores the file in RAM so it doesn't need to be read from disk each time it is played, which causes a large delay
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

            if (File.Exists(FilePath))
            {
                _cachedAudioData = File.ReadAllBytes(FilePath);
            }
        }

        public virtual async Task PlaySoundAsync(int masterVolume)
        {
            if (_cachedAudioData == null) return;

            IsActive = true;
            MemoryStream memoryStream = new MemoryStream(_cachedAudioData);
            StreamMediaFoundationReader audioReader = new StreamMediaFoundationReader(memoryStream);
            VolumeSampleProvider volumeProvider = new VolumeSampleProvider(audioReader.ToSampleProvider());
            volumeProvider.Volume = (float)((VolumeLevel / 100.0) * (masterVolume / 100.0));
            WaveOut player = new WaveOut();
            player.Init(volumeProvider);
            _activePlayers.Add(player);

            player.PlaybackStopped += (s, e) =>
            {
                _activePlayers.Remove(player);
                player.Dispose();
                audioReader.Dispose();
                memoryStream.Dispose();
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
