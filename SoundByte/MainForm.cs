using System.Text.Json;

namespace SoundByte
{
    public partial class MainForm : Form
    {
        private SoundTile _currentlyEditingTile = null;
        private SoundManager _soundManager;
        private ProfileManager _profileManager;

        public MainForm()
        {
            InitializeComponent();
            _soundManager = new SoundManager();
            _profileManager = new ProfileManager();
            //TestInit();
        }

        private void BtnEditorClose_Click(object sender, EventArgs e)
        {
            CloseEditor();
        }

        private void CloseEditor()
        {
            pnlEditor.Visible = false;
        }

        private void CreateTile(string name, string filePath, int volume, string hotkey)
        {
            HotkeySound newSound = new HotkeySound(name, filePath, hotkey, 0);
            newSound.VolumeLevel = volume;
            _soundManager.AddSound(newSound);

            SoundTile newTile = new SoundTile();
            newTile.ClipName = name;
            newTile.FilePath = filePath;
            newTile.Volume = volume;
            newTile.Hotkey = hotkey;
            newTile.Tag = newSound;
            newTile.EditRequested += SoundTile_EditRequested;

            newTile.PlayRequested += async (s, e) =>
            {
                if (newTile.Tag is AudioSound sound)
                {
                    await sound.PlaySoundAsync();
                }
            };

            flpSoundGrid.Controls.Add(newTile);
        }

        private void SoundTile_EditRequested(object sender, EventArgs e)
        {
            _currentlyEditingTile = (SoundTile)sender;

            pnlEditor.Visible = true;

            txtClipName.Text = _currentlyEditingTile.ClipName;
            txtFilePath.Text = _currentlyEditingTile.FilePath;
            trkVolume.Value = _currentlyEditingTile.Volume;
            txtHotkey.Text = _currentlyEditingTile.Hotkey;
        }

        private void TestInit()
        {
            for (int i = 0; i < 5; i++)
                CreateTile("Test Sound " + (i + 1), "example_sound.mp3", 100, "");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteTile(_currentlyEditingTile);
            _currentlyEditingTile = null;
            ClearForm();
            CloseEditor();
        }

        private void DeleteTile(SoundTile tile)
        {
            if (tile.Tag is AudioSound sound)
            {
                _soundManager.RemoveSound(sound);
            }
            flpSoundGrid.Controls.Remove(tile);
            SendStatus($"Deleted tile \"{tile.ClipName}\" sucessfully");
        }

        private void ClearForm()
        {
            txtClipName.Text = "";
            txtFilePath.Text = "";
            trkVolume.Value = 100;
            txtHotkey.Text = "";
        }

        private void TrkMasterVolume_ValueChanged(object sender, EventArgs e)
        {
            _soundManager.MasterVolume = trkMasterVolume.Value;
            lblMasterVolumeLevel.Text = trkMasterVolume.Value + "%";
        }

        private void TrkVolume_ValueChanged(object sender, EventArgs e)
        {
            lblVolumeLevel.Text = trkVolume.Value + "%";
        }

        private void BtnSaveProfile_Click(object sender, EventArgs e)
        {
            SaveProfile();
        }

        private void SaveProfile()
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Soundbyte Profile|*.sbp" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    _profileManager.SaveProfile(_soundManager.SoundList, sfd.FileName);
                    SendStatus($"Profile saved to {sfd.FileName}");
                }
            }
            ;
        }

        private void SendStatus(string message, bool isError = false)
        {
            if (isError)
            {
                lblStatus.ForeColor = Color.OrangeRed;
                lblStatus.Text = "Error: " + message;
            }
            else
            {
                lblStatus.ForeColor = Color.Black;
                lblStatus.Text = "Status: " + message;
            }
        }

        private void BtnNewSound_Click(object sender, EventArgs e)
        {
            CreateTile("Test", "example_sound.mp3", 100, "");
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtClipName.Text))
            {
                SendStatus("Clip Name cannot be blank", true);
                txtClipName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFilePath.Text))
            {
                SendStatus("File Path cannot be blank", true);
                txtFilePath.Focus();
                return false;
            }

            return true;
        }

        private void RunBackendTests()
        {
            // Test constructors
            HotkeySound testSound = new HotkeySound("Laser", "laser.wav", "F", 70);
            SoundManager manager = new SoundManager();

            // Test adding a sound to the manager
            manager.AddSound(testSound);

            // Test methods
            testSound.AssignHotkey("G", 71);

            // Validate expected results
            if (manager.SoundList.Count != 1 || testSound.HotkeyText != "G" || testSound.VolumeLevel != 100)
            {
                SendStatus("Backend classes failed testing", true);
                return;
            }

            SendStatus("Backend classes passed testing");
        }

        private void BtnLoadProfile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "SoundByte Profile|*.sbp" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    flpSoundGrid.Controls.Clear();
                    _soundManager.SoundList.Clear();

                    var loadedSounds = _profileManager.LoadProfile(ofd.FileName);
                    foreach (var sound in loadedSounds)
                    {
                        if (sound is HotkeySound hs)
                        {
                            CreateTile(hs.ClipName, hs.FilePath, hs.VolumeLevel, hs.HotkeyText);
                        }
                    }
                    SendStatus($"Profile loaded from {ofd.FileName}");
                }
            }
        }

        private void SaveEditorChanges()
        {
            if (!ValidateInput() || _currentlyEditingTile == null) return;

            // update UI tile
            _currentlyEditingTile.ClipName = txtClipName.Text;
            _currentlyEditingTile.FilePath = txtFilePath.Text;
            _currentlyEditingTile.Volume = trkVolume.Value;
            _currentlyEditingTile.Hotkey = txtHotkey.Text;

            // update backend
            if (_currentlyEditingTile.Tag is HotkeySound sound)
            {
                sound.ClipName = txtClipName.Text;
                sound.FilePath = txtFilePath.Text;
                sound.VolumeLevel = trkVolume.Value;
                sound.AssignHotkey(txtHotkey.Text, 0);
            }

            SendStatus($"Updated \"{txtClipName.Text}\" successfully");
        }
    }
}
