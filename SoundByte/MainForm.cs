namespace SoundByte
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnEditorClose_Click(object sender, EventArgs e)
        {
            CloseEditor();
        }

        private void CloseEditor()
        {
            pnlEditor.Visible = false;
        }
    }
}
