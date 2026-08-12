namespace CameraDevice
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            comboBoxFolders = new ComboBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openStorageToolStripMenuItem = new ToolStripMenuItem();
            localStorageToolStripMenuItem = new ToolStripMenuItem();
            cloudStorageToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            deleteVideosToolStripMenuItem = new ToolStripMenuItem();
            deleteVideostoolStripMenuItem2 = new ToolStripMenuItem();
            copyVideosToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            refreshVideosToolStripMenuItem = new ToolStripMenuItem();
            logsToolStripMenuItem = new ToolStripMenuItem();
            showVideoDetailsToolStripMenuItem = new ToolStripMenuItem();
            playVideoToolStripMenuItem = new ToolStripMenuItem();
            hardwareInfoToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            clearLogsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            boldTextToolStripMenuItem = new ToolStripMenuItem();
            fontSizeToolStripMenuItem = new ToolStripMenuItem();
            smallToolStripMenuItem = new ToolStripMenuItem();
            mediumToolStripMenuItem = new ToolStripMenuItem();
            largeToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            restartDeviceToolStripMenuItem = new ToolStripMenuItem();
            shutdownDeviceToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            listBoxVideos = new ListBox();
            labelFileCount = new Label();
            labelFileDate = new Label();
            labelFileSize = new Label();
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            labelStorage = new Label();
            labelSensor = new Label();
            labelSensor2 = new Label();
            labelDetection = new Label();
            labelAllSensors = new Label();
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
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openStorageToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // openStorageToolStripMenuItem
            // 
            openStorageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { localStorageToolStripMenuItem, cloudStorageToolStripMenuItem });
            openStorageToolStripMenuItem.Name = "openStorageToolStripMenuItem";
            openStorageToolStripMenuItem.Size = new Size(146, 22);
            openStorageToolStripMenuItem.Text = "Open Storage";
            // 
            // localStorageToolStripMenuItem
            // 
            localStorageToolStripMenuItem.Checked = true;
            localStorageToolStripMenuItem.CheckState = CheckState.Checked;
            localStorageToolStripMenuItem.Name = "localStorageToolStripMenuItem";
            localStorageToolStripMenuItem.Size = new Size(149, 22);
            localStorageToolStripMenuItem.Text = "Local Storage";
            localStorageToolStripMenuItem.Click += localStorageToolStripMenuItem_Click;
            // 
            // cloudStorageToolStripMenuItem
            // 
            cloudStorageToolStripMenuItem.Name = "cloudStorageToolStripMenuItem";
            cloudStorageToolStripMenuItem.Size = new Size(149, 22);
            cloudStorageToolStripMenuItem.Text = "Cloud Storage";
            cloudStorageToolStripMenuItem.Click += cloudStorageToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(146, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.DropDownItems.AddRange(new ToolStripItem[] { deleteVideosToolStripMenuItem, deleteVideostoolStripMenuItem2, copyVideosToolStripMenuItem });
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(39, 20);
            toolStripMenuItem3.Text = "Edit";
            // 
            // deleteVideosToolStripMenuItem
            // 
            deleteVideosToolStripMenuItem.Enabled = false;
            deleteVideosToolStripMenuItem.Name = "deleteVideosToolStripMenuItem";
            deleteVideosToolStripMenuItem.Size = new Size(195, 22);
            deleteVideosToolStripMenuItem.Text = "Delete Videos";
            deleteVideosToolStripMenuItem.Click += deleteVideosToolStripMenuItem_Click;
            // 
            // deleteVideostoolStripMenuItem2
            // 
            deleteVideostoolStripMenuItem2.Name = "deleteVideostoolStripMenuItem2";
            deleteVideostoolStripMenuItem2.Size = new Size(195, 22);
            deleteVideostoolStripMenuItem2.Text = "Delete Multiple Folders";
            deleteVideostoolStripMenuItem2.Click += deleteVideostoolStripMenuItem2_Click;
            // 
            // copyVideosToolStripMenuItem
            // 
            copyVideosToolStripMenuItem.Enabled = false;
            copyVideosToolStripMenuItem.Name = "copyVideosToolStripMenuItem";
            copyVideosToolStripMenuItem.Size = new Size(195, 22);
            copyVideosToolStripMenuItem.Text = "Copy Videos";
            copyVideosToolStripMenuItem.Click += copyVideosToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { refreshVideosToolStripMenuItem, logsToolStripMenuItem, showVideoDetailsToolStripMenuItem, playVideoToolStripMenuItem, hardwareInfoToolStripMenuItem });
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
            // hardwareInfoToolStripMenuItem
            // 
            hardwareInfoToolStripMenuItem.Name = "hardwareInfoToolStripMenuItem";
            hardwareInfoToolStripMenuItem.Size = new Size(174, 22);
            hardwareInfoToolStripMenuItem.Text = "Hardware Info";
            hardwareInfoToolStripMenuItem.Click += hardwareInfoToolStripMenuItem_Click;
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
            aboutToolStripMenuItem.Size = new Size(180, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clearLogsToolStripMenuItem, toolStripSeparator1, boldTextToolStripMenuItem, fontSizeToolStripMenuItem, settingsToolStripMenuItem, toolStripSeparator2, restartDeviceToolStripMenuItem, shutdownDeviceToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(47, 20);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // clearLogsToolStripMenuItem
            // 
            clearLogsToolStripMenuItem.Name = "clearLogsToolStripMenuItem";
            clearLogsToolStripMenuItem.Size = new Size(165, 22);
            clearLogsToolStripMenuItem.Text = "Clear Logs";
            clearLogsToolStripMenuItem.Click += clearLogsToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(162, 6);
            // 
            // boldTextToolStripMenuItem
            // 
            boldTextToolStripMenuItem.Name = "boldTextToolStripMenuItem";
            boldTextToolStripMenuItem.Size = new Size(165, 22);
            boldTextToolStripMenuItem.Text = "Bold Text";
            boldTextToolStripMenuItem.Click += boldTextToolStripMenuItem_Click;
            // 
            // fontSizeToolStripMenuItem
            // 
            fontSizeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { smallToolStripMenuItem, mediumToolStripMenuItem, largeToolStripMenuItem });
            fontSizeToolStripMenuItem.Name = "fontSizeToolStripMenuItem";
            fontSizeToolStripMenuItem.Size = new Size(165, 22);
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
            settingsToolStripMenuItem.Size = new Size(165, 22);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(162, 6);
            // 
            // restartDeviceToolStripMenuItem
            // 
            restartDeviceToolStripMenuItem.Name = "restartDeviceToolStripMenuItem";
            restartDeviceToolStripMenuItem.Size = new Size(165, 22);
            restartDeviceToolStripMenuItem.Text = "Restart device";
            restartDeviceToolStripMenuItem.Click += restartDeviceToolStripMenuItem_Click;
            // 
            // shutdownDeviceToolStripMenuItem
            // 
            shutdownDeviceToolStripMenuItem.Name = "shutdownDeviceToolStripMenuItem";
            shutdownDeviceToolStripMenuItem.Size = new Size(165, 22);
            shutdownDeviceToolStripMenuItem.Text = "Shutdown device";
            shutdownDeviceToolStripMenuItem.Click += shutdownDeviceToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(192, 6);
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
            labelFileSize.Location = new Point(308, 144);
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
            // labelStorage
            // 
            labelStorage.AutoSize = true;
            labelStorage.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelStorage.Location = new Point(301, 615);
            labelStorage.Name = "labelStorage";
            labelStorage.Size = new Size(177, 17);
            labelStorage.TabIndex = 8;
            labelStorage.Text = "Storage type: Local Storage";
            // 
            // labelSensor
            // 
            labelSensor.AutoSize = true;
            labelSensor.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelSensor.Location = new Point(323, 489);
            labelSensor.Name = "labelSensor";
            labelSensor.Size = new Size(79, 17);
            labelSensor.TabIndex = 9;
            labelSensor.Text = "labelSensor";
            // 
            // labelSensor2
            // 
            labelSensor2.AutoSize = true;
            labelSensor2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelSensor2.Location = new Point(323, 519);
            labelSensor2.Name = "labelSensor2";
            labelSensor2.Size = new Size(86, 17);
            labelSensor2.TabIndex = 10;
            labelSensor2.Text = "labelSensor2";
            // 
            // labelDetection
            // 
            labelDetection.AutoSize = true;
            labelDetection.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelDetection.Location = new Point(323, 546);
            labelDetection.Name = "labelDetection";
            labelDetection.Size = new Size(45, 17);
            labelDetection.TabIndex = 11;
            labelDetection.Text = "label1";
            // 
            // labelAllSensors
            // 
            labelAllSensors.AutoSize = true;
            labelAllSensors.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelAllSensors.ForeColor = Color.Red;
            labelAllSensors.Location = new Point(323, 576);
            labelAllSensors.Name = "labelAllSensors";
            labelAllSensors.Size = new Size(158, 17);
            labelAllSensors.TabIndex = 12;
            labelAllSensors.Text = "All sensors are disabled.";
            labelAllSensors.Visible = false;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1446, 646);
            Controls.Add(labelAllSensors);
            Controls.Add(labelDetection);
            Controls.Add(labelSensor2);
            Controls.Add(labelSensor);
            Controls.Add(labelStorage);
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
            Name = "FormMain";
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
        private ToolStripMenuItem hardwareInfoToolStripMenuItem;
        private Label labelStorage;
        private ToolStripMenuItem openStorageToolStripMenuItem;
        private ToolStripMenuItem localStorageToolStripMenuItem;
        private ToolStripMenuItem cloudStorageToolStripMenuItem;
        private ToolStripMenuItem copyVideosToolStripMenuItem;
        private Label labelSensor;
        private Label labelSensor2;
        private Label labelDetection;
        private ToolStripMenuItem deleteFolderToolStripMenuItem;
        private ToolStripMenuItem deleteVideostoolStripMenuItem2;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem restartDeviceToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private Label labelAllSensors;
    }
}
