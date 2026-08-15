using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using Renci.SshNet;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Numerics;
using System.Reflection;

namespace CameraDevice
{
    public partial class FormMain : System.Windows.Forms.Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        string videoFolder, driverPath;
        int countFiles, counterItems, countVideos = 0;
        bool setBold = false;
        public static bool checkFolder = false;
        string copyToVideoFolder, selectedFolder, selectedVideo, listAllVideos, password, checkString, connString;
        public static string selectedStoragePath;
        int setChoice, showMotionValue1, showMotionValue2, showDetectionValue;
        public static int selectedStorage = 1;
        List<string> videoFiles = new List<string>();

        void readFolder(string setFolder)
        {
            listBoxVideos.Items.Clear();
            comboBoxFolders.Items.Clear();
            comboBoxFolders.Text = "";
            try
            {
                videoFolder = setFolder;
                string[] folders = Directory.GetDirectories(videoFolder);
                foreach (string folder in folders)
                {
                    var folder2 = new DirectoryInfo(folder);
                    comboBoxFolders.Items.Add(folder2.Name);
                }
            }
            catch (Exception info)
            {
                MessageBox.Show("The path to video recordings is not available");
            }
            deleteVideosToolStripMenuItem.Enabled = listBoxVideos.SelectedItems.Count > 0;
            deleteVideosToolStripMenuItem3.Enabled = listBoxVideos.SelectedItems.Count > 0;
            copyVideosToolStripMenuItem.Enabled = listBoxVideos.SelectedItems.Count > 0;
            copyVideosToolStripMenuItem2.Enabled = listBoxVideos.SelectedItems.Count > 0;
        }

        void showSensorValue()
        {
            connString = HomeAssistant.Properties.Settings.Default.Database;
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();
                checkString = "select * from settings;";
                Clipboard.SetText(checkString);
                MySqlCommand command = new MySqlCommand(checkString, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    showMotionValue1 = reader.GetInt32("motionchoice1");
                    showMotionValue2 = reader.GetInt32("motionchoice2");
                    showDetectionValue = reader.GetInt32("openstatus");
                }
                conn.Close();
            }
            catch (Exception i)
            {
                MessageBox.Show("Error:" + i.Message);
            }


            if (showMotionValue1 == 1)
            {
                labelSensor.Text = "Motion sensor 1 is enabled";
                labelSensor.ForeColor = Color.Green;
            }
            else
            {
                labelSensor.Text = "Motion sensor 1 is disabled";
                labelSensor.ForeColor = Color.Red;
            }

            if (showMotionValue2 == 1)
            {
                labelSensor2.Text = "Motion sensor 2 is enabled";
                labelSensor2.ForeColor = Color.Green;
            }
            else
            {
                labelSensor2.Text = "Motion sensor 2 is disabled";
                labelSensor2.ForeColor = Color.Red;
            }

            if (showDetectionValue == 1)
            {
                labelDetection.Text = "Door sensor 1 is enabled";
                labelDetection.ForeColor = Color.Green;
            }
            else
            {
                labelDetection.Text = "Door sensor 1 is disabled";
                labelDetection.ForeColor = Color.Red;
            }

            if ((showMotionValue1 == 0) && (showMotionValue2 == 0) && (showDetectionValue == 0))
            {
                labelAllSensors.Visible = true;
                labelSensor.Visible = false;
                labelSensor2.Visible = false;
                labelDetection.Visible = false;
            }
            else
            {
                labelAllSensors.Visible = false;
                labelSensor.Visible = true;
                labelSensor2.Visible = true;
                labelDetection.Visible = true;
            }
        }

        void playVideo()
        {
            var playVideo = new ProcessStartInfo(selectedVideo)
            {
                UseShellExecute = true
            };
            Process.Start(playVideo);
        }

        void copyVideos()
        {
            if (MessageBox.Show("Copy selected videos?", "Camera Device", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var folderDialog = new FolderBrowserDialog();
                DialogResult result = folderDialog.ShowDialog();
                folderDialog.ShowNewFolderButton = true;
                if (result == DialogResult.OK)
                {
                    foreach (object copyValue in listBoxVideos.SelectedItems)
                    {
                        string sourceFile = videoFolder + "\\" + selectedFolder + "\\" + copyValue.ToString();
                        string destFile = Path.Combine(folderDialog.SelectedPath, copyValue.ToString());
                        File.Copy(sourceFile, destFile, true);
                    }
                    MessageBox.Show("Selected videos have been copied.", "Camera Device");
                }
            }

        }
        void deleteVideos()
        {
            if (MessageBox.Show("Delete selected videos?", "Camera Device", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                counterItems = 0;
                foreach (object deleteValue in listBoxVideos.SelectedItems)
                {
                    File.Delete(videoFolder + "\\" + selectedFolder + "\\" + deleteValue.ToString());
                }

                listBoxVideos.Items.Clear();
                countFiles = 0;
                DirectoryInfo info = new DirectoryInfo(listAllVideos);
                FileInfo[] files = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();
                foreach (FileInfo file in files)
                {
                    if (file.Extension == ".mp4")
                    {
                        listBoxVideos.Items.Add(file.Name);
                        countFiles++;
                    }
                  /*  else
                    {
                        MessageBox.Show(file.Name);
                    }*/
                }
                listBoxVideos.Update();
                labelFileCount.Text = "Number of videos: " + countFiles.ToString();
                MessageBox.Show("Selected videos have been deleted.", "Camera Device");
                deleteVideosToolStripMenuItem.Enabled = false;
                deleteVideosToolStripMenuItem3.Enabled = false;
                copyVideosToolStripMenuItem.Enabled = false;
                copyVideosToolStripMenuItem2.Enabled = false;
                playVideoToolStripMenuItem.Enabled = false;
                playVideoToolStripMenuItem2.Enabled = false;
            }
        }
        

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            showSensorValue();
            selectedStoragePath = "\\\\cameradevice\\camerasystem";
            readFolder(selectedStoragePath);
        }

        private void comboBoxFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            listAllVideos = videoFolder + "\\" + comboBoxFolders.Text;
            listBoxVideos.Items.Clear();
            countFiles = 0;

            listBoxVideos.Items.Clear();
            DirectoryInfo info = new DirectoryInfo(listAllVideos);
            FileInfo[] files = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();
            foreach (FileInfo file in files)
            {
                if (file.Extension == ".mp4")
                {
                    listBoxVideos.Items.Add(file.Name);
                    countFiles++;
                }
                else
                {
                    MessageBox.Show(file.Name);
                }
            }

            listBoxVideos.Update();
            labelFileCount.Text = "Number of videos: " + countFiles.ToString();
            selectedFolder = comboBoxFolders.Text;
            playVideoToolStripMenuItem.Enabled = false;
            playVideoToolStripMenuItem2.Enabled = false;
        }
        private void refreshVideosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (selectedStorage)
            {
                case 1:
                    readFolder("\\\\cameradevice\\camerasystem");
                    break;
                case 2:
                    readFolder(driverPath);
                    break;
            }
            playVideoToolStripMenuItem.Enabled = false;
            playVideoToolStripMenuItem2.Enabled = false;
        }

        private void listBoxVideos_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteVideosToolStripMenuItem.Enabled = listBoxVideos.SelectedItems.Count > 0;
            deleteVideosToolStripMenuItem3.Enabled = listBoxVideos.SelectedItems.Count > 0;
            copyVideosToolStripMenuItem.Enabled = listBoxVideos.SelectedItems.Count > 0;
            copyVideosToolStripMenuItem2.Enabled = listBoxVideos.SelectedItems.Count > 0;
        }

        private void showVideoDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (showVideoDetailsToolStripMenuItem.Checked)
            {
                labelFileDate.Visible = false;
                labelFileSize.Visible = false;
                showVideoDetailsToolStripMenuItem.Checked = false;
            }
            else
            {
                labelFileDate.Visible = true;
                labelFileSize.Visible = true;
                showVideoDetailsToolStripMenuItem.Checked = true;
            }
        }

        private void boldTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!boldTextToolStripMenuItem.Checked)
            {
                boldTextToolStripMenuItem.Checked = true;
                listBoxVideos.Font = new Font(listBoxVideos.Font, FontStyle.Bold);
                setBold = true;
            }
            else
            {
                boldTextToolStripMenuItem.Checked = false;
                listBoxVideos.Font = new Font(listBoxVideos.Font, FontStyle.Regular);
                setBold = false;
            }
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            smallToolStripMenuItem.Checked = false;
            mediumToolStripMenuItem.Checked = true;
            largeToolStripMenuItem.Checked = false;
            if (setBold)
            {
                listBoxVideos.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            }
            else
            {
                listBoxVideos.Font = new Font("Segoe UI", 14, FontStyle.Regular);
            }
        }


        private void smallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            smallToolStripMenuItem.Checked = true;
            mediumToolStripMenuItem.Checked = false;
            largeToolStripMenuItem.Checked = false;
            if (setBold)
            {
                listBoxVideos.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }
            else
            {
                listBoxVideos.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            }
        }

        private void largeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            smallToolStripMenuItem.Checked = false;
            mediumToolStripMenuItem.Checked = false;
            largeToolStripMenuItem.Checked = true;
            if (setBold)
            {
                listBoxVideos.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            }
            else
            {
                listBoxVideos.Font = new Font("Segoe UI", 18, FontStyle.Regular);
            }
        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLogs logs = new FormLogs();
            logs.ShowDialog();
        }

        private void saveVideosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteVideosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            deleteVideos();
        }
        private void listBoxVideos_DoubleClick(object sender, EventArgs e)
        {
            playVideo();
        }

        private void playVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            playVideo();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout about = new FormAbout();
            about.ShowDialog();
        }

        private void clearLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConfirm confirm = new FormConfirm();
            confirm.ShowDialog();
        }

        private void listBoxVideos_Click(object sender, EventArgs e)
        {
            if (listBoxVideos.SelectedItem != null)
            {
                countVideos = listBoxVideos.SelectedItems.Count;
                if (countVideos == 1)
                {
                    playVideoToolStripMenuItem.Enabled = true;
                    playVideoToolStripMenuItem2.Enabled = true;

                    FileInfo fileDate = new FileInfo(videoFolder + "\\" + comboBoxFolders.Text + "\\" + listBoxVideos.SelectedItem);
                    DateTime getDate = fileDate.CreationTime;
                    labelFileDate.Text = "Video creation date: " + getDate.ToString();

                    FileInfo fileSize = new FileInfo(videoFolder + "\\" + comboBoxFolders.Text + "\\" + listBoxVideos.SelectedItem);
                    var getSize = fileSize.Length / 1024;
                    labelFileSize.Text = "Video size: " + getSize + " KB";
                }
                else
                {
                    playVideoToolStripMenuItem.Enabled = false;
                    playVideoToolStripMenuItem2.Enabled = false;
                    labelFileDate.Text = "Video creation date: ";
                    labelFileSize.Text = "Video size: ";
                }

                axWindowsMediaPlayer1.URL = videoFolder + "\\" + comboBoxFolders.Text + "\\" + listBoxVideos.SelectedItem;
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                selectedVideo = videoFolder + "\\" + comboBoxFolders.Text + "\\" + listBoxVideos.SelectedItem;
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings settings = new FormSettings();
            settings.ShowDialog();
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            if (FormSettings.checkSensors == true)
            {
                showSensorValue();
                readFolder("\\\\cameradevice\\camerasystem");
            }
            FormSettings.checkSensors = false;
        }

        private void shutdownDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            password = HomeAssistant.Properties.Settings.Default.Password;
            DialogResult dialogResult = MessageBox.Show("Are you sure to shutdown the device", "Camera Device", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C ssh camerauser@cameradevice sudo /home/camerauser/camerasystem/camerashutdown.sh";
                process.StartInfo = startInfo;
                process.Start();
                MessageBox.Show("Device is shutdown, wait a minute before disconnecting the power!", "Camera Device");
            }
        }
        private void localStorageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedStoragePath = "\\\\cameradevice\\camerasystem";
            readFolder(selectedStoragePath);
            labelStorage.Text = "Storage type: Local Storage";
            cloudStorageToolStripMenuItem.Checked = false;
            localStorageToolStripMenuItem.Checked = true;
            selectedStorage = 1;
        }

        private void cloudStorageToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string[] lines = File.ReadAllLines("settings.txt");
            bool checkDrive = false;

            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo drives in allDrives)
            {
                if (drives.IsReady)
                {
                    if (drives.VolumeLabel == lines[0])
                    {
                        selectedStoragePath = drives.Name + lines[1];
                        readFolder(selectedStoragePath);
                        labelStorage.Text = "Storage type: Cloud Storage";
                        cloudStorageToolStripMenuItem.Checked = true;
                        localStorageToolStripMenuItem.Checked = false;
                        selectedStorage = 2;
                        checkDrive = true;
                    }
                }
            }
            if (!checkDrive)
            {
                MessageBox.Show("Cloud storage is not available, please check the connection", "Camera Device");
            }
        }

        private void copyVideosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyVideos();
        }

        private void motionSensorStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                connString = HomeAssistant.Properties.Settings.Default.Database;
                password = HomeAssistant.Properties.Settings.Default.Password;
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                checkString = "select * from settings;";
                Clipboard.SetText(checkString);
                MySqlCommand command = new MySqlCommand(checkString, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    setChoice = reader.GetInt32("motionchoice");

                }
                conn.Close();

                switch (setChoice)
                {
                    case 1:
                        MessageBox.Show("Motion sensor 1 is enabled", "Camera Device");
                        break;

                    case 2:
                        MessageBox.Show("Motion sensor 2 is emabled", "Camera Device");
                        break;

                    case 3:
                        MessageBox.Show("Both motion sensora are enabled", "Camera Device");
                        break;
                }
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
            }
        }

        private void deleteFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(videoFolder + "\\" + selectedFolder);
            if (MessageBox.Show("Delete selected folder " + videoFolder + "\\" + selectedFolder + "?", "Camera Device", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Directory.Delete(videoFolder + "\\" + selectedFolder, true);
                readFolder(selectedStoragePath);
            }
        }

        private void deleteVideostoolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormVideoFolders videofolder = new FormVideoFolders();
            videofolder.ShowDialog();
        }

        private void restartDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            password = HomeAssistant.Properties.Settings.Default.Password;
            DialogResult dialogResult = MessageBox.Show("Are you sure to restart the device", "Camera Device", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C ssh camerauser@cameradevice sudo /home/camerauser/camerasystem/camerarestart.sh";
                process.StartInfo = startInfo;
                process.Start();
                MessageBox.Show("Device has been restarted", "Camera Device");
            }
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void deleteVideosToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            deleteVideos();
        }

        private void copyVideosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            copyVideos();
        }
    }
}
