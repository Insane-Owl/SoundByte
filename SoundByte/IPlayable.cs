using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SoundByte
{
    public interface IPlayable
    {
        Task PlaySoundAsync();
        void StopSound();
    }
}
