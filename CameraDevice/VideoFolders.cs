using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraDevice
{
    public partial class FormVideoFolders : Form
    {
        public FormVideoFolders()
        {
            InitializeComponent();
        }

        int counterItems = 0;
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void VideoFolders_Load(object sender, EventArgs e)
        {
            listBoxVideoFolders.Items.Clear();
            try
            {
                string[] folders = Directory.GetDirectories(FormMain.selectedStoragePath);
                foreach (string folder in folders)
                {
                    var folder2 = new DirectoryInfo(folder);
                    listBoxVideoFolders.Items.Add(folder2.Name);
                    counterItems++;
                }
                if (FormMain.selectedStorage == 1)
                {
                    labelText.Text = "Local storage is selected";
                }
                else
                {
                    labelText.Text = "Cloud storage is selected";
                }
                toolStripStatusLabelNumbers.Text = "Numbers of video folders: " + counterItems.ToString();
            }
            catch (Exception info)
            {
                MessageBox.Show("The path to video recordings is not available");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Delete selected video folders?", "Home Assistant", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                counterItems = 0;
                foreach (object deleteValue in listBoxVideoFolders.SelectedItems)
                {
                    Directory.Delete(FormMain.selectedStoragePath + "\\" + deleteValue.ToString(), true);
                }
                listBoxVideoFolders.Items.Clear();
                string[] folders = Directory.GetDirectories(FormMain.selectedStoragePath);
                foreach (string folder in folders)
                {
                    var folder2 = new DirectoryInfo(folder);
                    listBoxVideoFolders.Items.Add(folder2.Name);
                    counterItems++;
                }
                toolStripStatusLabelNumbers.Text = "Numbers of video folders: " + counterItems.ToString();
                MessageBox.Show("Selected video folders have been deleted.", "Home Assistant");
            }
        }
    }
}


