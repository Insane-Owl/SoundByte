using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace SoundByte
{
    public class ProfileManager
    {
        private string saveDirectory;

        public ProfileManager()
        {
            saveDirectory = "Profiles\\";
        }

        public void SaveProfile(List<AudioSound> sounds, string filePath)
        {
            var hotkeySounds = new List<HotkeySound>();
            foreach (var sound in sounds)
            {
                if (sound is HotkeySound hs)
                    hotkeySounds.Add(hs);
            }

            string jsonString = JsonSerializer.Serialize(hotkeySounds, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
        }

        public List<AudioSound> LoadProfile(string filePath)
        {
            if (!File.Exists(filePath)) return new List<AudioSound>();

            string jsonString = File.ReadAllText(filePath);
            var loaded = JsonSerializer.Deserialize<List<HotkeySound>>(jsonString) ?? new List<HotkeySound>();
            return new List<AudioSound>(loaded);
        }
    }
}
