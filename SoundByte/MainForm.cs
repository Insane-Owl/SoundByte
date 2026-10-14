using System.Text.Json;

namespace SoundByte
{
    public partial class MainForm : Form
    {
        private SoundTile? _currentlyEditingTile = null;
        private bool _isCreatingNew = false;
        private SoundManager _soundManager;
        private ProfileManager _profileManager;

        // for global hotkeys, that work even when the window isn't focused
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        private System.Windows.Forms.Timer _globalHotkeyTimer;
        private Dictionary<Keys, bool> _keyStates = new Dictionary<Keys, bool>();

        public MainForm()
        {
            InitializeComponent();
            _soundManager = new SoundManager();
            _profileManager = new ProfileManager();
            _globalHotkeyTimer = new System.Windows.Forms.Timer { Interval = 20 }; // 20ms polling rate
            _globalHotkeyTimer.Tick += GlobalHotkeyTimer_Tick;
            _globalHotkeyTimer.Start();
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

        private void CreateTile(string name, string filePath, int volume, string hotkey, int keyCode = 0)
        {
            HotkeySound newSound = new HotkeySound(name, filePath, hotkey, keyCode);
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
                    if (!File.Exists(sound.FilePath)) { SendStatus($"File \"{sound.FilePath}\" missing", true); return; }
                    newTile.ToggleIndicator(true);
                    await sound.PlaySoundAsync(trkMasterVolume.Value);
                }
            };

            newSound.PlaybackEnded += (s, e) => newTile.ToggleIndicator(false);

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
            if (_currentlyEditingTile == null) return;

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
            _isCreatingNew = true;
            _currentlyEditingTile = null;
            ClearForm();
            pnlEditor.Visible = true;
            txtClipName.Focus();
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
            if (!ValidateInput()) return;

            int keyCode = txtHotkey.Tag != null ? (int)txtHotkey.Tag : 0;

            if (_isCreatingNew)
            {
                CreateTile(txtClipName.Text, txtFilePath.Text, trkVolume.Value, txtHotkey.Text, keyCode);
                _isCreatingNew = false;
                SendStatus($"Created \"{txtClipName.Text}\" successfully");
            }
            else if (_currentlyEditingTile != null)
            {
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
                    sound.AssignHotkey(txtHotkey.Text, keyCode);
                }
                SendStatus($"Updated \"{txtClipName.Text}\" successfully");
            }
            CloseEditor();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveEditorChanges();
        }

        private void btnStopAll_Click(object sender, EventArgs e)
        {
            _soundManager.StopAll();
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Audio Files|*.wav;*.mp3;*.m4a;*.aac;*.wma;*.flac" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = ofd.FileName;
                }
            }
        }

        private void GlobalHotkeyTimer_Tick(object sender, EventArgs e)
        {
            CheckHotkeyCombo(Keys.F12, () => _soundManager.StopAll());

            foreach (Control control in flpSoundGrid.Controls)
            {
                if (control is SoundTile tile && tile.Tag is HotkeySound hs && hs.RawKeyCode != 0)
                {
                    CheckHotkeyCombo((Keys)hs.RawKeyCode, async () =>
                    {
                        if (File.Exists(hs.FilePath))
                        {
                            tile.ToggleIndicator(true);
                            await hs.PlaySoundAsync(_soundManager.MasterVolume);
                        }
                    });
                }
            }
        }

        private void CheckHotkeyCombo(Keys keyData, Action action)
        {
            Keys baseKey = keyData & Keys.KeyCode;
            if (baseKey == Keys.None) return;

            // check which (if any) modifiers are used
            bool reqCtrl = (keyData & Keys.Control) == Keys.Control;
            bool reqAlt = (keyData & Keys.Alt) == Keys.Alt;
            bool reqShift = (keyData & Keys.Shift) == Keys.Shift;

            // check what keys are being pressed
            bool isBasePressed = (GetAsyncKeyState(baseKey) & 0x8000) != 0;
            bool isCtrlPressed = (GetAsyncKeyState(Keys.ControlKey) & 0x8000) != 0;
            bool isAltPressed = (GetAsyncKeyState(Keys.Menu) & 0x8000) != 0;
            bool isShiftPressed = (GetAsyncKeyState(Keys.ShiftKey) & 0x8000) != 0;

            bool isPressed = isBasePressed && (reqCtrl == isCtrlPressed) && (reqAlt == isAltPressed) && (reqShift == isShiftPressed);

            // only trigger if the key was pressed this tick and not last tick
            if (isPressed && (!_keyStates.ContainsKey(keyData) || !_keyStates[keyData]))
            {
                action.Invoke();
            }

            _keyStates[keyData] = isPressed;
        }

        private void TxtHotkey_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;

            // clear the hotkey
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                txtHotkey.Text = "";
                txtHotkey.Tag = 0;
                return;
            }

            // don't allow binding modifier keys (CTRL, ALT, SHIGT) by themselves, wait for another key
            if (e.KeyCode == Keys.ControlKey || e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Menu)
            {
                return;
            }

            // store the full key combo
            txtHotkey.Text = e.KeyData.ToString();
            txtHotkey.Tag = (int)e.KeyData;
        }
    }
}
