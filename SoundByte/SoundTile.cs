using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SoundByte
{
    public partial class SoundTile : UserControl
    {
        // I used properties here instead of just variables so I can use getters and setters.
        private string clipName = "";
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ClipName
        {
            get { return clipName; }
            set
            {
                clipName = value;
                lblClipName.Text = value;
            }
        }
        private string filePath = "";
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }
        private int volume = 100;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Volume
        {
            get { return volume;  }
            set
            {
                if (value >= 0 && value <= 100)
                    volume = value;
            }
        }
        private string hotkey = "";
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Hotkey
        {
            get { return hotkey; }
            set
            {
                hotkey = value;

                if (value == "")
                {
                    lblClipName.Location = new Point(8, 29);
                    lblHotkey.Visible = false;
                }
                else
                {
                    lblClipName.Location = new Point(8, 22);
                    lblHotkey.Visible = true;
                    lblHotkey.Text = value;
                }
            }
        }


        public event EventHandler EditRequested;

        public SoundTile()
        {
            InitializeComponent();
        }

        private void SoundTile_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.FromArgb(215, 215, 215), ButtonBorderStyle.Solid);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EditRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
