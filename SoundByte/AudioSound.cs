using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.CoreAudioApi;

namespace SoundByte
{
    public class AudioSound : IPlayable, IDisposable, ISampleProvider
    {
        public string ClipName { get; set; }
        public string FilePath { get; set; }
        public int VolumeLevel { get; set; }
        public bool IsActive { get; set; }

        public WaveFormat WaveFormat { get; private set; }

        private float[] _audioSamples;
        private int _position;
        private WasapiPlayer _player;
        private int _currentMasterVolume = 100;

        private float _currentFade = 0f;
        private bool _isRestarting = false;
        private bool _isStopping = false;
        
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
                    WaveFormat = reader.WaveFormat;
                    List<float> samplesList = new List<float>((int)(reader.Length / 4));
                    var readBuffer = new float[WaveFormat.SampleRate * WaveFormat.Channels];

                    ISampleProvider sampleProvider = reader;
                    int samplesRead;
                    while ((samplesRead = sampleProvider.Read(readBuffer)) > 0)
                    {
                        for (int i = 0; i < samplesRead; i++)
                        {
                            samplesList.Add(readBuffer[i]);
                        }
                    }
                    _audioSamples = samplesList.ToArray();
                }

                _player = new WasapiPlayerBuilder().WithEventSync().WithLatency(50).Build(); ; // initializes WASAPI in shared mode (which lets multiple audios play at once) with a 50ms latency target
                _player.Init(this);
                _player.Play();
            }
        }

        // I'm using the ISampleProvider interface now, so I have to implement this manually
        // (╯°□°)╯︵ ┻━┻
        public int Read(float[] buffer, int offset, int count)
        {
            return Read(new Span<float>(buffer, offset, count));
        }

        // This too
        public int Read(Span<float> buffer)
        {
            if (_audioSamples == null)
            {
                buffer.Clear();
                return buffer.Length;
            }

            float volume = (float)((VolumeLevel / 100.0) * (_currentMasterVolume / 100.0));
            float fadeStep = 1f / (WaveFormat.SampleRate * WaveFormat.Channels * 0.01f);

            for (int i = 0; i < buffer.Length; i++)
            {
                if (_isStopping || _isRestarting)
                {
                    // fade sound out if stopping or restarting to fix the popping/crackling sound
                    _currentFade = Math.Max(0f, _currentFade - fadeStep);
                    if (_currentFade == 0f)
                    {
                        if (_isRestarting)
                        {
                            _position = 0;
                            _isRestarting = false;
                            IsActive = true;
                        }
                        else
                        {
                            IsActive = false;
                            _isStopping = false;
                        }
                    }
                }
                else if (IsActive)
                {
                    _currentFade = Math.Min(1f, _currentFade + fadeStep);
                }

                if (IsActive && _position < _audioSamples.Length)
                {
                    buffer[i] = _audioSamples[_position] * volume * _currentFade;
                    _position++;
                }
                else
                {
                    buffer[i] = 0f;
                    if (IsActive && _position >= _audioSamples.Length && !_isStopping)
                    {
                        _isStopping = true;
                        Task.Run(() =>
                        {
                            PlaybackEnded?.Invoke(this, EventArgs.Empty);
                        });
                    }
                }
            }

            return buffer.Length;
        }

        public virtual async Task PlaySoundAsync(int masterVolume)
        {
            if (_audioSamples == null) return;
            _currentMasterVolume = masterVolume;

            if (IsActive)
            {
                _isRestarting = true;
            }
            else
            {
                _position = 0;
                IsActive = true;
            }

            await Task.CompletedTask;
        }

        public virtual void StopSound()
        {
            _isStopping = true;
        }

        public void Dispose()
        {
            if (_player != null)
            {
                _player.Stop();
                _player.Dispose();
            }
        }
    }
}
