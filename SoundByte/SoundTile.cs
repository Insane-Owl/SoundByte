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
        public SoundTile()
        {
            InitializeComponent();
        }

        private void SoundTile_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.FromArgb(215, 215, 215), ButtonBorderStyle.Solid);
        }
    }
}
