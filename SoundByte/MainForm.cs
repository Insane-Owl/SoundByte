namespace SoundByte
{
    public partial class MainForm : Form
    {
        private SoundTile _currentlyEditingTile = null;

        public MainForm()
        {
            InitializeComponent();

            TestInit();
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
            SoundTile newTile = new SoundTile();
            newTile.ClipName = name;
            newTile.FilePath = filePath;
            newTile.Volume = volume;
            newTile.Hotkey = hotkey;
            newTile.EditRequested += SoundTile_EditRequested;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteTile(_currentlyEditingTile);
            _currentlyEditingTile = null;
            ClearForm();
        }

        private void DeleteTile(SoundTile tile)
        {
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
            lblMasterVolumeLevel.Text = trkMasterVolume.Value + "%";
        }

        private void TrkVolume_ValueChanged(object sender, EventArgs e)
        {
            lblVolumeLevel.Text = trkVolume.Value + "%";
        }

        private void btnCloseApp_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSaveProfile_Click(object sender, EventArgs e)
        {
            SaveProfile();
        }

        private void SaveProfile()
        {
            if (!ValidateInput())
                return;

            SendStatus("Profile \"profile.sbp\" saved successfully");
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
    }
}
