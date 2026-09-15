namespace SoundByte
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tlpMenuBar = new TableLayoutPanel();
            btnNewSound = new Button();
            flpProfileControls = new FlowLayoutPanel();
            btnSaveProfile = new Button();
            btnLoadProfile = new Button();
            btnStopAll = new Button();
            tlpMasterVolumeControls = new TableLayoutPanel();
            lblMasterVolumeLevel = new Label();
            lblMasterVolume = new Label();
            trkMasterVolume = new TrackBar();
            pnlStatusBar = new Panel();
            label1 = new Label();
            pnlEditor = new Panel();
            pnlEditorContents = new Panel();
            flpEditorContents = new FlowLayoutPanel();
            pnlClipName = new Panel();
            lblClipName = new Label();
            txtClipName = new TextBox();
            pnlFilePath = new Panel();
            lblFilePath = new Label();
            btnBrowse = new Button();
            txtFilePath = new TextBox();
            pnlVolume = new Panel();
            lblVolumeLevel = new Label();
            trkVolume = new TrackBar();
            lblVolume = new Label();
            pnlHotkey = new Panel();
            lblHotkey = new Label();
            txtHotkey = new TextBox();
            btnDelete = new Button();
            lblEditorSeperator = new Label();
            pnlEditorHeader = new Panel();
            btnEditorClose = new Button();
            lblEditorLabel = new Label();
            flpSoundGrid = new FlowLayoutPanel();
            soundTile1 = new SoundTile();
            soundTile2 = new SoundTile();
            soundTile3 = new SoundTile();
            soundTile4 = new SoundTile();
            soundTile5 = new SoundTile();
            soundTile6 = new SoundTile();
            soundTile7 = new SoundTile();
            soundTile8 = new SoundTile();
            soundTile9 = new SoundTile();
            soundTile10 = new SoundTile();
            soundTile11 = new SoundTile();
            soundTile12 = new SoundTile();
            tlpMenuBar.SuspendLayout();
            flpProfileControls.SuspendLayout();
            tlpMasterVolumeControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trkMasterVolume).BeginInit();
            pnlStatusBar.SuspendLayout();
            pnlEditor.SuspendLayout();
            pnlEditorContents.SuspendLayout();
            flpEditorContents.SuspendLayout();
            pnlClipName.SuspendLayout();
            pnlFilePath.SuspendLayout();
            pnlVolume.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trkVolume).BeginInit();
            pnlHotkey.SuspendLayout();
            pnlEditorHeader.SuspendLayout();
            flpSoundGrid.SuspendLayout();
            SuspendLayout();
            // 
            // tlpMenuBar
            // 
            tlpMenuBar.BackColor = Color.White;
            tlpMenuBar.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlpMenuBar.ColumnCount = 5;
            tlpMenuBar.ColumnStyles.Add(new ColumnStyle());
            tlpMenuBar.ColumnStyles.Add(new ColumnStyle());
            tlpMenuBar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMenuBar.ColumnStyles.Add(new ColumnStyle());
            tlpMenuBar.ColumnStyles.Add(new ColumnStyle());
            tlpMenuBar.Controls.Add(btnNewSound, 0, 0);
            tlpMenuBar.Controls.Add(flpProfileControls, 1, 0);
            tlpMenuBar.Controls.Add(btnStopAll, 3, 0);
            tlpMenuBar.Controls.Add(tlpMasterVolumeControls, 2, 0);
            tlpMenuBar.Dock = DockStyle.Top;
            tlpMenuBar.Location = new Point(0, 0);
            tlpMenuBar.Name = "tlpMenuBar";
            tlpMenuBar.RowCount = 1;
            tlpMenuBar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMenuBar.Size = new Size(670, 36);
            tlpMenuBar.TabIndex = 0;
            // 
            // btnNewSound
            // 
            btnNewSound.Anchor = AnchorStyles.None;
            btnNewSound.FlatAppearance.BorderSize = 0;
            btnNewSound.Location = new Point(4, 4);
            btnNewSound.Name = "btnNewSound";
            btnNewSound.Size = new Size(80, 28);
            btnNewSound.TabIndex = 1;
            btnNewSound.Text = "New Sound";
            btnNewSound.UseVisualStyleBackColor = false;
            // 
            // flpProfileControls
            // 
            flpProfileControls.AutoSize = true;
            flpProfileControls.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpProfileControls.Controls.Add(btnSaveProfile);
            flpProfileControls.Controls.Add(btnLoadProfile);
            flpProfileControls.Dock = DockStyle.Fill;
            flpProfileControls.Location = new Point(91, 4);
            flpProfileControls.Name = "flpProfileControls";
            flpProfileControls.Size = new Size(160, 28);
            flpProfileControls.TabIndex = 2;
            flpProfileControls.WrapContents = false;
            // 
            // btnSaveProfile
            // 
            btnSaveProfile.Anchor = AnchorStyles.None;
            btnSaveProfile.Location = new Point(0, 0);
            btnSaveProfile.Margin = new Padding(0);
            btnSaveProfile.Name = "btnSaveProfile";
            btnSaveProfile.Size = new Size(80, 28);
            btnSaveProfile.TabIndex = 2;
            btnSaveProfile.Text = "Save Profile";
            btnSaveProfile.UseVisualStyleBackColor = false;
            // 
            // btnLoadProfile
            // 
            btnLoadProfile.Anchor = AnchorStyles.None;
            btnLoadProfile.Location = new Point(80, 0);
            btnLoadProfile.Margin = new Padding(0);
            btnLoadProfile.Name = "btnLoadProfile";
            btnLoadProfile.Size = new Size(80, 28);
            btnLoadProfile.TabIndex = 3;
            btnLoadProfile.Text = "Load Profile";
            btnLoadProfile.UseVisualStyleBackColor = false;
            // 
            // btnStopAll
            // 
            btnStopAll.Anchor = AnchorStyles.None;
            btnStopAll.FlatAppearance.BorderColor = Color.DarkRed;
            btnStopAll.FlatAppearance.BorderSize = 0;
            btnStopAll.Location = new Point(569, 4);
            btnStopAll.Name = "btnStopAll";
            btnStopAll.Size = new Size(96, 28);
            btnStopAll.TabIndex = 5;
            btnStopAll.Text = "Stop All (F12)";
            btnStopAll.UseVisualStyleBackColor = false;
            // 
            // tlpMasterVolumeControls
            // 
            tlpMasterVolumeControls.ColumnCount = 3;
            tlpMasterVolumeControls.ColumnStyles.Add(new ColumnStyle());
            tlpMasterVolumeControls.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMasterVolumeControls.ColumnStyles.Add(new ColumnStyle());
            tlpMasterVolumeControls.Controls.Add(lblMasterVolumeLevel, 2, 0);
            tlpMasterVolumeControls.Controls.Add(lblMasterVolume, 0, 0);
            tlpMasterVolumeControls.Controls.Add(trkMasterVolume, 1, 0);
            tlpMasterVolumeControls.Dock = DockStyle.Fill;
            tlpMasterVolumeControls.Location = new Point(258, 4);
            tlpMasterVolumeControls.Name = "tlpMasterVolumeControls";
            tlpMasterVolumeControls.RowCount = 1;
            tlpMasterVolumeControls.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMasterVolumeControls.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpMasterVolumeControls.Size = new Size(304, 28);
            tlpMasterVolumeControls.TabIndex = 3;
            // 
            // lblMasterVolumeLevel
            // 
            lblMasterVolumeLevel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lblMasterVolumeLevel.Location = new Point(266, 0);
            lblMasterVolumeLevel.Name = "lblMasterVolumeLevel";
            lblMasterVolumeLevel.Size = new Size(35, 28);
            lblMasterVolumeLevel.TabIndex = 4;
            lblMasterVolumeLevel.Text = "100%";
            lblMasterVolumeLevel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMasterVolume
            // 
            lblMasterVolume.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lblMasterVolume.Font = new Font("Segoe UI", 8F);
            lblMasterVolume.Location = new Point(3, 0);
            lblMasterVolume.Name = "lblMasterVolume";
            lblMasterVolume.Size = new Size(49, 28);
            lblMasterVolume.TabIndex = 0;
            lblMasterVolume.Text = "Master\r\nVolume";
            lblMasterVolume.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // trkMasterVolume
            // 
            trkMasterVolume.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            trkMasterVolume.AutoSize = false;
            trkMasterVolume.LargeChange = 20;
            trkMasterVolume.Location = new Point(58, 3);
            trkMasterVolume.Maximum = 100;
            trkMasterVolume.Name = "trkMasterVolume";
            trkMasterVolume.Size = new Size(202, 22);
            trkMasterVolume.SmallChange = 10;
            trkMasterVolume.TabIndex = 4;
            trkMasterVolume.TickFrequency = 10;
            trkMasterVolume.TickStyle = TickStyle.None;
            trkMasterVolume.Value = 100;
            // 
            // pnlStatusBar
            // 
            pnlStatusBar.BorderStyle = BorderStyle.FixedSingle;
            pnlStatusBar.Controls.Add(label1);
            pnlStatusBar.Dock = DockStyle.Bottom;
            pnlStatusBar.Location = new Point(0, 403);
            pnlStatusBar.Name = "pnlStatusBar";
            pnlStatusBar.Size = new Size(470, 28);
            pnlStatusBar.TabIndex = 1;
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(468, 26);
            label1.TabIndex = 0;
            label1.Text = "Status: Profile \"test_profile1.sbp\" saved";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlEditor
            // 
            pnlEditor.BackColor = Color.White;
            pnlEditor.BorderStyle = BorderStyle.FixedSingle;
            pnlEditor.Controls.Add(pnlEditorContents);
            pnlEditor.Controls.Add(lblEditorSeperator);
            pnlEditor.Controls.Add(pnlEditorHeader);
            pnlEditor.Dock = DockStyle.Right;
            pnlEditor.Location = new Point(470, 36);
            pnlEditor.Name = "pnlEditor";
            pnlEditor.Size = new Size(200, 395);
            pnlEditor.TabIndex = 2;
            // 
            // pnlEditorContents
            // 
            pnlEditorContents.Controls.Add(flpEditorContents);
            pnlEditorContents.Controls.Add(btnDelete);
            pnlEditorContents.Dock = DockStyle.Fill;
            pnlEditorContents.Location = new Point(0, 30);
            pnlEditorContents.Name = "pnlEditorContents";
            pnlEditorContents.Padding = new Padding(5);
            pnlEditorContents.Size = new Size(198, 363);
            pnlEditorContents.TabIndex = 1;
            // 
            // flpEditorContents
            // 
            flpEditorContents.Controls.Add(pnlClipName);
            flpEditorContents.Controls.Add(pnlFilePath);
            flpEditorContents.Controls.Add(pnlVolume);
            flpEditorContents.Controls.Add(pnlHotkey);
            flpEditorContents.Dock = DockStyle.Fill;
            flpEditorContents.FlowDirection = FlowDirection.TopDown;
            flpEditorContents.Location = new Point(5, 5);
            flpEditorContents.Name = "flpEditorContents";
            flpEditorContents.Size = new Size(188, 325);
            flpEditorContents.TabIndex = 0;
            // 
            // pnlClipName
            // 
            pnlClipName.Controls.Add(lblClipName);
            pnlClipName.Controls.Add(txtClipName);
            pnlClipName.Location = new Point(3, 3);
            pnlClipName.Name = "pnlClipName";
            pnlClipName.Padding = new Padding(0, 0, 0, 50);
            pnlClipName.Size = new Size(182, 50);
            pnlClipName.TabIndex = 5;
            // 
            // lblClipName
            // 
            lblClipName.AutoSize = true;
            lblClipName.Location = new Point(0, 6);
            lblClipName.Name = "lblClipName";
            lblClipName.Size = new Size(63, 15);
            lblClipName.TabIndex = 4;
            lblClipName.Text = "Clip Name";
            // 
            // txtClipName
            // 
            txtClipName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtClipName.Location = new Point(0, 24);
            txtClipName.Name = "txtClipName";
            txtClipName.Size = new Size(182, 23);
            txtClipName.TabIndex = 2;
            // 
            // pnlFilePath
            // 
            pnlFilePath.Controls.Add(lblFilePath);
            pnlFilePath.Controls.Add(btnBrowse);
            pnlFilePath.Controls.Add(txtFilePath);
            pnlFilePath.Location = new Point(3, 59);
            pnlFilePath.Name = "pnlFilePath";
            pnlFilePath.Padding = new Padding(0, 0, 0, 20);
            pnlFilePath.Size = new Size(182, 50);
            pnlFilePath.TabIndex = 6;
            // 
            // lblFilePath
            // 
            lblFilePath.AutoSize = true;
            lblFilePath.Location = new Point(0, 6);
            lblFilePath.Name = "lblFilePath";
            lblFilePath.Size = new Size(52, 15);
            lblFilePath.TabIndex = 4;
            lblFilePath.Text = "File Path";
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(117, 24);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(65, 23);
            btnBrowse.TabIndex = 3;
            btnBrowse.Text = "Browse...";
            btnBrowse.UseVisualStyleBackColor = false;
            // 
            // txtFilePath
            // 
            txtFilePath.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtFilePath.Location = new Point(0, 24);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.Size = new Size(111, 23);
            txtFilePath.TabIndex = 2;
            // 
            // pnlVolume
            // 
            pnlVolume.Controls.Add(lblVolumeLevel);
            pnlVolume.Controls.Add(trkVolume);
            pnlVolume.Controls.Add(lblVolume);
            pnlVolume.Location = new Point(3, 115);
            pnlVolume.Name = "pnlVolume";
            pnlVolume.Padding = new Padding(0, 0, 0, 20);
            pnlVolume.Size = new Size(182, 50);
            pnlVolume.TabIndex = 7;
            // 
            // lblVolumeLevel
            // 
            lblVolumeLevel.Location = new Point(144, 2);
            lblVolumeLevel.Name = "lblVolumeLevel";
            lblVolumeLevel.Size = new Size(38, 23);
            lblVolumeLevel.TabIndex = 6;
            lblVolumeLevel.Text = "100%";
            lblVolumeLevel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // trkVolume
            // 
            trkVolume.AutoSize = false;
            trkVolume.LargeChange = 20;
            trkVolume.Location = new Point(-3, 23);
            trkVolume.Maximum = 100;
            trkVolume.Name = "trkVolume";
            trkVolume.Size = new Size(185, 27);
            trkVolume.SmallChange = 10;
            trkVolume.TabIndex = 5;
            trkVolume.TickFrequency = 10;
            trkVolume.TickStyle = TickStyle.None;
            trkVolume.Value = 100;
            // 
            // lblVolume
            // 
            lblVolume.AutoSize = true;
            lblVolume.Location = new Point(0, 6);
            lblVolume.Name = "lblVolume";
            lblVolume.Size = new Size(47, 15);
            lblVolume.TabIndex = 4;
            lblVolume.Text = "Volume";
            // 
            // pnlHotkey
            // 
            pnlHotkey.Controls.Add(lblHotkey);
            pnlHotkey.Controls.Add(txtHotkey);
            pnlHotkey.Location = new Point(3, 171);
            pnlHotkey.Name = "pnlHotkey";
            pnlHotkey.Padding = new Padding(0, 0, 0, 20);
            pnlHotkey.Size = new Size(182, 50);
            pnlHotkey.TabIndex = 8;
            // 
            // lblHotkey
            // 
            lblHotkey.AutoSize = true;
            lblHotkey.Location = new Point(0, 6);
            lblHotkey.Name = "lblHotkey";
            lblHotkey.Size = new Size(45, 15);
            lblHotkey.TabIndex = 4;
            lblHotkey.Text = "Hotkey";
            // 
            // txtHotkey
            // 
            txtHotkey.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            txtHotkey.Location = new Point(0, 24);
            txtHotkey.Name = "txtHotkey";
            txtHotkey.Size = new Size(182, 23);
            txtHotkey.TabIndex = 2;
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Bottom;
            btnDelete.Location = new Point(5, 330);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(188, 28);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // lblEditorSeperator
            // 
            lblEditorSeperator.BorderStyle = BorderStyle.Fixed3D;
            lblEditorSeperator.Dock = DockStyle.Top;
            lblEditorSeperator.Location = new Point(0, 28);
            lblEditorSeperator.Name = "lblEditorSeperator";
            lblEditorSeperator.Size = new Size(198, 2);
            lblEditorSeperator.TabIndex = 2;
            // 
            // pnlEditorHeader
            // 
            pnlEditorHeader.Controls.Add(btnEditorClose);
            pnlEditorHeader.Controls.Add(lblEditorLabel);
            pnlEditorHeader.Dock = DockStyle.Top;
            pnlEditorHeader.Location = new Point(0, 0);
            pnlEditorHeader.Name = "pnlEditorHeader";
            pnlEditorHeader.Size = new Size(198, 28);
            pnlEditorHeader.TabIndex = 0;
            // 
            // btnEditorClose
            // 
            btnEditorClose.Dock = DockStyle.Right;
            btnEditorClose.FlatAppearance.BorderSize = 0;
            btnEditorClose.FlatStyle = FlatStyle.Flat;
            btnEditorClose.Location = new Point(170, 0);
            btnEditorClose.Name = "btnEditorClose";
            btnEditorClose.Size = new Size(28, 28);
            btnEditorClose.TabIndex = 1;
            btnEditorClose.Text = "✕";
            btnEditorClose.UseVisualStyleBackColor = true;
            btnEditorClose.Click += BtnEditorClose_Click;
            // 
            // lblEditorLabel
            // 
            lblEditorLabel.Dock = DockStyle.Left;
            lblEditorLabel.Location = new Point(0, 0);
            lblEditorLabel.Name = "lblEditorLabel";
            lblEditorLabel.Size = new Size(79, 28);
            lblEditorLabel.TabIndex = 0;
            lblEditorLabel.Text = "Sound Editor";
            lblEditorLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // flpSoundGrid
            // 
            flpSoundGrid.AutoScroll = true;
            flpSoundGrid.BorderStyle = BorderStyle.FixedSingle;
            flpSoundGrid.Controls.Add(soundTile1);
            flpSoundGrid.Controls.Add(soundTile2);
            flpSoundGrid.Controls.Add(soundTile3);
            flpSoundGrid.Controls.Add(soundTile4);
            flpSoundGrid.Controls.Add(soundTile5);
            flpSoundGrid.Controls.Add(soundTile6);
            flpSoundGrid.Controls.Add(soundTile7);
            flpSoundGrid.Controls.Add(soundTile8);
            flpSoundGrid.Controls.Add(soundTile9);
            flpSoundGrid.Controls.Add(soundTile10);
            flpSoundGrid.Controls.Add(soundTile11);
            flpSoundGrid.Controls.Add(soundTile12);
            flpSoundGrid.Dock = DockStyle.Fill;
            flpSoundGrid.Location = new Point(0, 36);
            flpSoundGrid.Name = "flpSoundGrid";
            flpSoundGrid.Size = new Size(470, 367);
            flpSoundGrid.TabIndex = 3;
            // 
            // soundTile1
            // 
            soundTile1.BackColor = SystemColors.ControlLightLight;
            soundTile1.Location = new Point(3, 3);
            soundTile1.Name = "soundTile1";
            soundTile1.Size = new Size(150, 80);
            soundTile1.TabIndex = 0;
            // 
            // soundTile2
            // 
            soundTile2.BackColor = SystemColors.ControlLightLight;
            soundTile2.Location = new Point(159, 3);
            soundTile2.Name = "soundTile2";
            soundTile2.Size = new Size(150, 80);
            soundTile2.TabIndex = 1;
            // 
            // soundTile3
            // 
            soundTile3.BackColor = SystemColors.ControlLightLight;
            soundTile3.Location = new Point(315, 3);
            soundTile3.Name = "soundTile3";
            soundTile3.Size = new Size(150, 80);
            soundTile3.TabIndex = 2;
            // 
            // soundTile4
            // 
            soundTile4.BackColor = SystemColors.ControlLightLight;
            soundTile4.Location = new Point(3, 89);
            soundTile4.Name = "soundTile4";
            soundTile4.Size = new Size(150, 80);
            soundTile4.TabIndex = 3;
            // 
            // soundTile5
            // 
            soundTile5.BackColor = SystemColors.ControlLightLight;
            soundTile5.Location = new Point(159, 89);
            soundTile5.Name = "soundTile5";
            soundTile5.Size = new Size(150, 80);
            soundTile5.TabIndex = 4;
            // 
            // soundTile6
            // 
            soundTile6.BackColor = SystemColors.ControlLightLight;
            soundTile6.Location = new Point(315, 89);
            soundTile6.Name = "soundTile6";
            soundTile6.Size = new Size(150, 80);
            soundTile6.TabIndex = 5;
            // 
            // soundTile7
            // 
            soundTile7.BackColor = SystemColors.ControlLightLight;
            soundTile7.Location = new Point(3, 175);
            soundTile7.Name = "soundTile7";
            soundTile7.Size = new Size(150, 80);
            soundTile7.TabIndex = 6;
            // 
            // soundTile8
            // 
            soundTile8.BackColor = SystemColors.ControlLightLight;
            soundTile8.Location = new Point(159, 175);
            soundTile8.Name = "soundTile8";
            soundTile8.Size = new Size(150, 80);
            soundTile8.TabIndex = 7;
            // 
            // soundTile9
            // 
            soundTile9.BackColor = SystemColors.ControlLightLight;
            soundTile9.Location = new Point(315, 175);
            soundTile9.Name = "soundTile9";
            soundTile9.Size = new Size(150, 80);
            soundTile9.TabIndex = 8;
            // 
            // soundTile10
            // 
            soundTile10.BackColor = SystemColors.ControlLightLight;
            soundTile10.Location = new Point(3, 261);
            soundTile10.Name = "soundTile10";
            soundTile10.Size = new Size(150, 80);
            soundTile10.TabIndex = 9;
            // 
            // soundTile11
            // 
            soundTile11.BackColor = SystemColors.ControlLightLight;
            soundTile11.Location = new Point(159, 261);
            soundTile11.Name = "soundTile11";
            soundTile11.Size = new Size(150, 80);
            soundTile11.TabIndex = 10;
            // 
            // soundTile12
            // 
            soundTile12.BackColor = SystemColors.ControlLightLight;
            soundTile12.Location = new Point(315, 261);
            soundTile12.Name = "soundTile12";
            soundTile12.Size = new Size(150, 80);
            soundTile12.TabIndex = 11;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(670, 431);
            Controls.Add(flpSoundGrid);
            Controls.Add(pnlStatusBar);
            Controls.Add(pnlEditor);
            Controls.Add(tlpMenuBar);
            ForeColor = SystemColors.ControlText;
            MinimumSize = new Size(530, 380);
            Name = "MainForm";
            Text = "SoundByte";
            tlpMenuBar.ResumeLayout(false);
            tlpMenuBar.PerformLayout();
            flpProfileControls.ResumeLayout(false);
            tlpMasterVolumeControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)trkMasterVolume).EndInit();
            pnlStatusBar.ResumeLayout(false);
            pnlEditor.ResumeLayout(false);
            pnlEditorContents.ResumeLayout(false);
            flpEditorContents.ResumeLayout(false);
            pnlClipName.ResumeLayout(false);
            pnlClipName.PerformLayout();
            pnlFilePath.ResumeLayout(false);
            pnlFilePath.PerformLayout();
            pnlVolume.ResumeLayout(false);
            pnlVolume.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trkVolume).EndInit();
            pnlHotkey.ResumeLayout(false);
            pnlHotkey.PerformLayout();
            pnlEditorHeader.ResumeLayout(false);
            flpSoundGrid.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlStatusBar;
        private Panel pnlEditor;
        private TableLayoutPanel tlpMenuBar;
        private FlowLayoutPanel flpSoundGrid;
        private Button btnLoadProfile;
        private FlowLayoutPanel flpProfileControls;
        private Button btnSaveProfile;
        private Button btnNewSound;
        private Label lblMasterVolume;
        private TableLayoutPanel tlpMasterVolumeControls;
        private Label lblMasterVolumeLevel;
        private TrackBar trkMasterVolume;
        private Button btnStopAll;
        private Panel pnlEditorContents;
        private Panel pnlEditorHeader;
        private Label lblEditorLabel;
        private Label lblEditorSeperator;
        private FlowLayoutPanel flpEditorContents;
        private TextBox txtFilePath;
        private Panel pnlClipName;
        private Label lblClipName;
        private TextBox txtClipName;
        private Panel pnlFilePath;
        private Label lblFilePath;
        private Button btnBrowse;
        private Label label1;
        private Button btnEditorClose;
        private Panel pnlVolume;
        private Label lblVolume;
        private Label lblVolumeLevel;
        private TrackBar trkVolume;
        private Panel pnlHotkey;
        private Label lblHotkey;
        private TextBox txtHotkey;
        private Button btnDelete;
        private SoundTile soundTile1;
        private SoundTile soundTile2;
        private SoundTile soundTile3;
        private SoundTile soundTile4;
        private SoundTile soundTile5;
        private SoundTile soundTile6;
        private SoundTile soundTile7;
        private SoundTile soundTile8;
        private SoundTile soundTile9;
        private SoundTile soundTile10;
        private SoundTile soundTile11;
        private SoundTile soundTile12;
    }
}
