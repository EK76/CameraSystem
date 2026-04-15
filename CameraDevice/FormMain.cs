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

        static string videoFolder = Properties.Settings.Default.Folder;
    //    string[] folders = Directory.GetDirectories(videoFolder);
        int countFiles, counterItems, countVideos = 0;
        bool setBold = false, checkFolder = false;
        string copyToVideoFolder, selectedFolder, selectedVideo, listAllVideos;
        List<string> videoFiles = new List<string>();


        void readFolder()
        {
            listBoxVideos.Items.Clear();
            comboBoxFolders.Items.Clear();
            comboBoxFolders.Text = "";
            videoFolder = Properties.Settings.Default.Folder;
            string[] folders = Directory.GetDirectories(videoFolder);
            foreach (string folder in folders)
            {
                var folder2 = new DirectoryInfo(folder);
                comboBoxFolders.Items.Add(folder2.Name);
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
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            readFolder();
        }

        private void comboBoxFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(videoFolder + "\\" + comboBoxFolders.Text);
            listAllVideos = videoFolder + comboBoxFolders.Text;
            listBoxVideos.Items.Clear();

            foreach (string file in files)
            {
                var file2 = new FileInfo(file);
                listBoxVideos.Items.Add(file2.Name);
            }

            DirectoryInfo folder = new DirectoryInfo(videoFolder + "\\" + comboBoxFolders.Text);
            countFiles = folder.GetFiles().Length;
            labelFileCount.Text = "Number of videos: " + countFiles.ToString();
            selectedFolder = comboBoxFolders.Text;
            playVideoToolStripMenuItem.Enabled = false;
        }
        private void refreshVideosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            readFolder();
        }

        private void listBoxVideos_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteVideosToolStripMenuItem.Enabled = listBoxVideos.SelectedItems.Count > 0;
            saveVideosToolStripMenuItem.Enabled = listBoxVideos.SelectedItems.Count > 0;
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
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = true;
            DialogResult result = folderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                copyToVideoFolder = folderDialog.SelectedPath;
                foreach (object copyValue in listBoxVideos.SelectedItems)
                {
                    File.Copy(videoFolder + "\\" + selectedFolder + "\\" + copyValue, copyToVideoFolder + "\\" + copyValue);
                }
                MessageBox.Show("Selected videos have been saved", "Camera Device");
            }
        }

        private void deleteVideosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Delete selected videos?", "Camera Device", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                counterItems = 0;
                foreach (object deleteValue in listBoxVideos.SelectedItems)
                {
                    counterItems++;
                    videoFiles.Add(deleteValue.ToString());
                }

                for (int countCheck = 0; countCheck < counterItems; countCheck++)
                {
                    File.Delete(videoFolder + selectedFolder + "\\" + videoFiles[countCheck]);
                }

                videoFiles.Clear();
                string[] listFiles = Directory.GetFiles(listAllVideos);
                listBoxVideos.Items.Clear();

                foreach (string file in listFiles)
                {
                    var file2 = new FileInfo(file);
                    listBoxVideos.Items.Add(file2.Name);
                }

                listBoxVideos.Update();
                DirectoryInfo folder = new DirectoryInfo(videoFolder +" \\" + comboBoxFolders.Text);
                countFiles = folder.GetFiles().Length;
                labelFileCount.Text = "Number of videos: " + countFiles.ToString();
                MessageBox.Show("Selected videos have been deleted.", "Camera Device");
            }
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
            countVideos = listBoxVideos.SelectedItems.Count;
            if (countVideos == 1)
            {
                playVideoToolStripMenuItem.Enabled = true;
            }
            else
            {
                playVideoToolStripMenuItem.Enabled = false;
            }

            FileInfo fileDate = new FileInfo(videoFolder + "\\" + comboBoxFolders.Text + "\\" + listBoxVideos.SelectedItem);
            DateTime getDate = fileDate.CreationTime;
            labelFileDate.Text = "Video creation date: " + getDate.ToString();

            FileInfo fileSize = new FileInfo(videoFolder + "\\" + comboBoxFolders.Text + "\\" + listBoxVideos.SelectedItem);
            var getSize = fileSize.Length / 1024;
            labelFileSize.Text = "Video creation date: " + getSize + " KB";

            axWindowsMediaPlayer1.URL = videoFolder + "\\" + comboBoxFolders.Text + "\\" + listBoxVideos.SelectedItem;
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            selectedVideo = videoFolder + "\\" + comboBoxFolders.Text + "\\" + listBoxVideos.SelectedItem;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings settings = new FormSettings();
            settings.ShowDialog();
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            readFolder();

        }

        private void comboBoxFolders_Click(object sender, EventArgs e)
        {
           
        }
    }
}
