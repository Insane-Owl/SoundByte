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
            label1 = new Label();
            panel1 = new Panel();
            label2 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(8, 29);
            label1.Name = "label1";
            label1.Size = new Size(135, 23);
            label1.TabIndex = 1;
            label1.Text = "Sound Name";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LimeGreen;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(5, 80);
            panel1.TabIndex = 0;
            panel1.Visible = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.Font = new Font("Segoe UI", 8F);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(8, 50);
            label2.Name = "label2";
            label2.Size = new Size(135, 19);
            label2.TabIndex = 2;
            label2.Text = "None";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Visible = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F);
            button1.Location = new Point(126, -5);
            button1.Name = "button1";
            button1.Size = new Size(24, 24);
            button1.TabIndex = 5;
            button1.Text = "⋯";
            button1.UseVisualStyleBackColor = false;
            // 
            // SoundTile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "SoundTile";
            Size = new Size(150, 80);
            Paint += SoundTile_Paint;
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Panel panel1;
        private Label label2;
        private Button button1;
    }
}
