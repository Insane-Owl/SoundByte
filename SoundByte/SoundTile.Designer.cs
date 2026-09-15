namespace SoundByte
{
    partial class SoundTile
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblClipName = new Label();
            pnlPlayingIndicator = new Panel();
            lblHotkey = new Label();
            btnEdit = new Button();
            SuspendLayout();
            // 
            // lblClipName
            // 
            lblClipName.Anchor = AnchorStyles.None;
            lblClipName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblClipName.ForeColor = SystemColors.ControlText;
            lblClipName.Location = new Point(8, 22);
            lblClipName.Name = "lblClipName";
            lblClipName.Size = new Size(135, 23);
            lblClipName.TabIndex = 1;
            lblClipName.Text = "Sound Name";
            lblClipName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlPlayingIndicator
            // 
            pnlPlayingIndicator.BackColor = Color.LimeGreen;
            pnlPlayingIndicator.Dock = DockStyle.Left;
            pnlPlayingIndicator.Location = new Point(0, 0);
            pnlPlayingIndicator.Name = "pnlPlayingIndicator";
            pnlPlayingIndicator.Size = new Size(5, 80);
            pnlPlayingIndicator.TabIndex = 0;
            pnlPlayingIndicator.Visible = false;
            // 
            // lblHotkey
            // 
            lblHotkey.Anchor = AnchorStyles.None;
            lblHotkey.Font = new Font("Segoe UI", 8F);
            lblHotkey.ForeColor = SystemColors.ControlText;
            lblHotkey.Location = new Point(8, 43);
            lblHotkey.Name = "lblHotkey";
            lblHotkey.Size = new Size(135, 19);
            lblHotkey.TabIndex = 2;
            lblHotkey.Text = "None";
            lblHotkey.TextAlign = ContentAlignment.MiddleCenter;
            lblHotkey.Visible = false;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.BackColor = Color.Transparent;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 10F);
            btnEdit.Location = new Point(126, -5);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(24, 24);
            btnEdit.TabIndex = 5;
            btnEdit.Text = "⋯";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += BtnEdit_Click;
            // 
            // SoundTile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(btnEdit);
            Controls.Add(lblHotkey);
            Controls.Add(lblClipName);
            Controls.Add(pnlPlayingIndicator);
            Name = "SoundTile";
            Size = new Size(150, 80);
            Paint += SoundTile_Paint;
            ResumeLayout(false);
        }

        #endregion
        private Label lblClipName;
        private Panel pnlPlayingIndicator;
        private Label lblHotkey;
        private Button btnEdit;
    }
}
