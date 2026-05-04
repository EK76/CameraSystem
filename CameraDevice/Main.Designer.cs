namespace CameraDevice
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            comboBoxFolders = new ComboBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            saveVideosToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            deleteVideosToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            refreshVideosToolStripMenuItem = new ToolStripMenuItem();
            logsToolStripMenuItem = new ToolStripMenuItem();
            showVideoDetailsToolStripMenuItem = new ToolStripMenuItem();
            playVideoToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            clearLogsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            boldTextToolStripMenuItem = new ToolStripMenuItem();
            fontSizeToolStripMenuItem = new ToolStripMenuItem();
            smallToolStripMenuItem = new ToolStripMenuItem();
            mediumToolStripMenuItem = new ToolStripMenuItem();
            largeToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            listBoxVideos = new ListBox();
            labelFileCount = new Label();
            labelFileDate = new Label();
            labelFileSize = new Label();
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            shutdownDeviceToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).BeginInit();
            SuspendLayout();
            // 
            // comboBoxFolders
            // 
            comboBoxFolders.FormattingEnabled = true;
            comboBoxFolders.Location = new Point(12, 57);
            comboBoxFolders.Name = "comboBoxFolders";
            comboBoxFolders.Size = new Size(279, 23);
            comboBoxFolders.TabIndex = 0;
            comboBoxFolders.SelectedIndexChanged += comboBoxFolders_SelectedIndexChanged;
            comboBoxFolders.Click += comboBoxFolders_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, toolStripMenuItem3, viewToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1446, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveVideosToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // saveVideosToolStripMenuItem
            // 
            saveVideosToolStripMenuItem.Enabled = false;
            saveVideosToolStripMenuItem.Name = "saveVideosToolStripMenuItem";
            saveVideosToolStripMenuItem.Size = new Size(136, 22);
            saveVideosToolStripMenuItem.Text = "Save Videos";
            saveVideosToolStripMenuItem.Click += saveVideosToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(136, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.DropDownItems.AddRange(new ToolStripItem[] { deleteVideosToolStripMenuItem });
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(39, 20);
            toolStripMenuItem3.Text = "Edit";
            // 
            // deleteVideosToolStripMenuItem
            // 
            deleteVideosToolStripMenuItem.Enabled = false;
            deleteVideosToolStripMenuItem.Name = "deleteVideosToolStripMenuItem";
            deleteVideosToolStripMenuItem.Size = new Size(145, 22);
            deleteVideosToolStripMenuItem.Text = "Delete Videos";
            deleteVideosToolStripMenuItem.Click += deleteVideosToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { refreshVideosToolStripMenuItem, logsToolStripMenuItem, showVideoDetailsToolStripMenuItem, playVideoToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 20);
            viewToolStripMenuItem.Text = "View";
            // 
            // refreshVideosToolStripMenuItem
            // 
            refreshVideosToolStripMenuItem.Name = "refreshVideosToolStripMenuItem";
            refreshVideosToolStripMenuItem.Size = new Size(174, 22);
            refreshVideosToolStripMenuItem.Text = "Refresh Videos";
            refreshVideosToolStripMenuItem.Click += refreshVideosToolStripMenuItem_Click;
            // 
            // logsToolStripMenuItem
            // 
            logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            logsToolStripMenuItem.Size = new Size(174, 22);
            logsToolStripMenuItem.Text = "Logs";
            logsToolStripMenuItem.Click += logsToolStripMenuItem_Click;
            // 
            // showVideoDetailsToolStripMenuItem
            // 
            showVideoDetailsToolStripMenuItem.Checked = true;
            showVideoDetailsToolStripMenuItem.CheckState = CheckState.Checked;
            showVideoDetailsToolStripMenuItem.Name = "showVideoDetailsToolStripMenuItem";
            showVideoDetailsToolStripMenuItem.Size = new Size(174, 22);
            showVideoDetailsToolStripMenuItem.Text = "Show Video Details";
            showVideoDetailsToolStripMenuItem.Click += showVideoDetailsToolStripMenuItem_Click;
            // 
            // playVideoToolStripMenuItem
            // 
            playVideoToolStripMenuItem.Enabled = false;
            playVideoToolStripMenuItem.Name = "playVideoToolStripMenuItem";
            playVideoToolStripMenuItem.Size = new Size(174, 22);
            playVideoToolStripMenuItem.Text = "Play Video";
            playVideoToolStripMenuItem.Click += playVideoToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clearLogsToolStripMenuItem, toolStripSeparator1, boldTextToolStripMenuItem, fontSizeToolStripMenuItem, settingsToolStripMenuItem, shutdownDeviceToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(47, 20);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // clearLogsToolStripMenuItem
            // 
            clearLogsToolStripMenuItem.Name = "clearLogsToolStripMenuItem";
            clearLogsToolStripMenuItem.Size = new Size(180, 22);
            clearLogsToolStripMenuItem.Text = "Clear Logs";
            clearLogsToolStripMenuItem.Click += clearLogsToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // boldTextToolStripMenuItem
            // 
            boldTextToolStripMenuItem.Name = "boldTextToolStripMenuItem";
            boldTextToolStripMenuItem.Size = new Size(180, 22);
            boldTextToolStripMenuItem.Text = "Bold Text";
            boldTextToolStripMenuItem.Click += boldTextToolStripMenuItem_Click;
            // 
            // fontSizeToolStripMenuItem
            // 
            fontSizeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { smallToolStripMenuItem, mediumToolStripMenuItem, largeToolStripMenuItem });
            fontSizeToolStripMenuItem.Name = "fontSizeToolStripMenuItem";
            fontSizeToolStripMenuItem.Size = new Size(180, 22);
            fontSizeToolStripMenuItem.Text = "Font Size";
            // 
            // smallToolStripMenuItem
            // 
            smallToolStripMenuItem.Name = "smallToolStripMenuItem";
            smallToolStripMenuItem.Size = new Size(119, 22);
            smallToolStripMenuItem.Text = "Small";
            smallToolStripMenuItem.Click += smallToolStripMenuItem_Click;
            // 
            // mediumToolStripMenuItem
            // 
            mediumToolStripMenuItem.Checked = true;
            mediumToolStripMenuItem.CheckState = CheckState.Checked;
            mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            mediumToolStripMenuItem.Size = new Size(119, 22);
            mediumToolStripMenuItem.Text = "Medium";
            mediumToolStripMenuItem.Click += mediumToolStripMenuItem_Click;
            // 
            // largeToolStripMenuItem
            // 
            largeToolStripMenuItem.Name = "largeToolStripMenuItem";
            largeToolStripMenuItem.Size = new Size(119, 22);
            largeToolStripMenuItem.Text = "Large";
            largeToolStripMenuItem.Click += largeToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(180, 22);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(107, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // listBoxVideos
            // 
            listBoxVideos.Font = new Font("Segoe UI", 14F);
            listBoxVideos.FormattingEnabled = true;
            listBoxVideos.Location = new Point(12, 112);
            listBoxVideos.Name = "listBoxVideos";
            listBoxVideos.SelectionMode = SelectionMode.MultiExtended;
            listBoxVideos.Size = new Size(279, 479);
            listBoxVideos.TabIndex = 3;
            listBoxVideos.Click += listBoxVideos_Click;
            listBoxVideos.SelectedIndexChanged += listBoxVideos_SelectedIndexChanged;
            listBoxVideos.DoubleClick += listBoxVideos_DoubleClick;
            // 
            // labelFileCount
            // 
            labelFileCount.AutoSize = true;
            labelFileCount.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelFileCount.Location = new Point(12, 611);
            labelFileCount.Name = "labelFileCount";
            labelFileCount.Size = new Size(133, 17);
            labelFileCount.TabIndex = 4;
            labelFileCount.Text = "Numbers of videos: ";
            // 
            // labelFileDate
            // 
            labelFileDate.AutoSize = true;
            labelFileDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelFileDate.Location = new Point(308, 112);
            labelFileDate.Name = "labelFileDate";
            labelFileDate.Size = new Size(110, 17);
            labelFileDate.TabIndex = 5;
            labelFileDate.Text = "Video creation:  ";
            // 
            // labelFileSize
            // 
            labelFileSize.AutoSize = true;
            labelFileSize.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelFileSize.Location = new Point(308, 156);
            labelFileSize.Name = "labelFileSize";
            labelFileSize.Size = new Size(75, 17);
            labelFileSize.TabIndex = 6;
            labelFileSize.Text = "Video size:";
            // 
            // axWindowsMediaPlayer1
            // 
            axWindowsMediaPlayer1.Enabled = true;
            axWindowsMediaPlayer1.Location = new Point(597, 57);
            axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            axWindowsMediaPlayer1.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            axWindowsMediaPlayer1.Size = new Size(812, 571);
            axWindowsMediaPlayer1.TabIndex = 7;
            // 
            // shutdownDeviceToolStripMenuItem
            // 
            shutdownDeviceToolStripMenuItem.Name = "shutdownDeviceToolStripMenuItem";
            shutdownDeviceToolStripMenuItem.Size = new Size(180, 22);
            shutdownDeviceToolStripMenuItem.Text = "Shutdown device";
            shutdownDeviceToolStripMenuItem.Click += shutdownDeviceToolStripMenuItem_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1446, 646);
            Controls.Add(axWindowsMediaPlayer1);
            Controls.Add(labelFileSize);
            Controls.Add(labelFileDate);
            Controls.Add(labelFileCount);
            Controls.Add(listBoxVideos);
            Controls.Add(comboBoxFolders);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Main";
            ShowIcon = false;
            Text = "Camera Device";
            Activated += FormMain_Activated;
            Load += FormMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxFolders;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem clearLogsToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem logsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ListBox listBoxVideos;
        private ToolStripMenuItem refreshVideosToolStripMenuItem;
        private Label labelFileCount;
        private Label labelFileDate;
        private Label labelFileSize;
        private ToolStripMenuItem saveVideosToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem deleteVideosToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem boldTextToolStripMenuItem;
        private ToolStripMenuItem fontSizeToolStripMenuItem;
        private ToolStripMenuItem smallToolStripMenuItem;
        private ToolStripMenuItem mediumToolStripMenuItem;
        private ToolStripMenuItem largeToolStripMenuItem;
        private ToolStripMenuItem showVideoDetailsToolStripMenuItem;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private ToolStripMenuItem playVideoToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem shutdownDeviceToolStripMenuItem;
    }
}
