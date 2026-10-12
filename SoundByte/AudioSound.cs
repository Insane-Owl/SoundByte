using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using NAudio.CoreAudioApi;

namespace SoundByte
{
    public class AudioSound : IPlayable, IDisposable
    {
        public string ClipName { get; set; }
        public string FilePath { get; set; }
        public int VolumeLevel { get; set; }
        public bool IsActive { get; set; }

        private byte[] _decodedAudioData; // decodes and stores the file in RAM so it doesn't need to be read from disk each time it is played, which causes a large delay
        private WaveFormat _audioFormat;

        private MemoryStream _memoryStream;
        private RawSourceWaveStream _rawStream;
        private VolumeSampleProvider _volumeProvider;
        private WasapiPlayer _player;

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
                using (AudioFileReader reader = new AudioFileReader(FilePath))
                {
                    _audioFormat = reader.WaveFormat;
                    _decodedAudioData = new byte[reader.Length];
                    reader.Read(_decodedAudioData, 0, _decodedAudioData.Length);
                }

                _memoryStream = new MemoryStream(_decodedAudioData);
                _rawStream = new RawSourceWaveStream(_memoryStream, _audioFormat);
                _volumeProvider = new VolumeSampleProvider(_rawStream.ToSampleProvider());

                _player = new WasapiPlayerBuilder().WithEventSync().WithLatency(50).Build(); ; // initializes WASAPI in shared mode (which lets multiple audios play at once) with a 50ms latency target
                _player.Init(_volumeProvider);

                _player.PlaybackStopped += (s, e) =>
                {
                    if (_rawStream.Position >= _rawStream.Length)
                    {
                        IsActive = false;
                        PlaybackEnded?.Invoke(this, EventArgs.Empty);
                    }
                };
            }
        }

        public virtual async Task PlaySoundAsync(int masterVolume)
        {
            if (_player == null) return;

            _volumeProvider.Volume = (float)((VolumeLevel / 100.0) * (masterVolume / 100.0));

            if (_player.PlaybackState != PlaybackState.Playing)
            {
                _player.Stop();
            }

            _rawStream.Position = 0;

            IsActive = true;
            _player.Play();

            await Task.CompletedTask;
        }

        public virtual void StopSound()
        {
            if (_player != null && _player.PlaybackState == PlaybackState.Playing)
            {
                _player.Stop();
            }
        }

        public void Dispose()
        {
            _player?.Dispose();
            _rawStream?.Dispose();
            _memoryStream?.Dispose();
        }
    }
}
