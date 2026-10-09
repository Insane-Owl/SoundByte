using System;
using System.Collections.Generic;
using System.Text;

namespace SoundByte
{
    public class ProfileManager
    {
        private string saveDirectory;

        public ProfileManager()
        {
            saveDirectory = "Profiles\\";
        }

        public void SaveProfile(List<AudioSound> sounds, string name)
        {
            // Save logic will go here later
        }

        public List<AudioSound> LoadProfile(string name)
        {
            // Load logic will go here later
            return new List<AudioSound>();
        }
    }
}
