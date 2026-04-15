using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CameraDevice
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        string checkString, connString;
        string user = "loguser";
        string password = "Test0880!";
        string host = "cameradevice";
        string gDrive, emailAlert, alertText, emailAdress, streamVideo;
        int setLocation;
        bool checkChanges = false;

        private void FormSettings_Load(object sender, EventArgs e)
        {
            connString = "SERVER = cameradevice; DATABASE = camerasystem; UID = loguser; PASSWORD = Test0880!";
            try
            {
                labelFolder.Text = Properties.Settings.Default.Folder;
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                checkString = "select * from settings;";
                Clipboard.SetText(checkString);
                MySqlCommand command = new MySqlCommand(checkString, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    gDrive = reader.GetString("gdrive");
                    emailAlert = reader.GetString("email");
                    textBoxEmailadress.Text = reader.GetString("sendemail");
                    textBoxAlerttext.Text = reader.GetString("alerttext");
                    textBoxStream.Text = reader.GetInt32("stream").ToString();
                    setLocation = reader.GetInt32("location");
                }
                conn.Close();
                labelFolder.Text = Properties.Settings.Default.Folder;

                if (setLocation == 1)
                {
                    radioButtonLocal.Checked = true;
                    radioButtonGdrive.Checked = false;
                }
                else
                { 
                    radioButtonLocal.Checked = false;
                    radioButtonGdrive.Checked = true;
                }

                if (emailAlert == "True")
                {
                    checkBoxEmail.Checked = true;
                    textBoxAlerttext.Enabled = true;
                    textBoxEmailadress.Enabled = true;
                    textBoxAlerttext.ForeColor = Color.Black;
                    textBoxEmailadress.ForeColor = Color.Black;
                }
                else
                {
                    checkBoxEmail.Checked = false;
                    textBoxAlerttext.Enabled = false;
                    textBoxEmailadress.Enabled = false;
                    textBoxAlerttext.ForeColor = Color.Silver;
                    textBoxEmailadress.ForeColor = Color.Silver;
                }

            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (radioButtonLocal.Checked)
            {
                setLocation = 1;
            }
            else
            {
                setLocation = 2;
            }

            if (checkBoxEmail.Checked)
            {
                emailAlert = "True";
            }
            else
            {
                emailAlert = "False";
            }

            alertText = textBoxAlerttext.Text;
            emailAdress = textBoxEmailadress.Text;
            streamVideo = textBoxStream.Text;

            try
            {
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                checkString = "update settings set location='" + setLocation + "', email ='" + emailAlert + "', sendemail = '" + emailAdress + "', alerttext = '" + alertText + "', stream = '" + streamVideo + "' where id = 1;";
                Clipboard.SetText(checkString);
                MySqlCommand command = new MySqlCommand(checkString, conn);
                MySqlDataReader reader = command.ExecuteReader();
                conn.Close();
                MessageBox.Show("Settings updated.", "Camera Device");
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
            }

            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C ssh camerauser@cameradevíce sudo systemctl restart camerastystem.service";
                process.StartInfo = startInfo;
                process.Start();
            }
            catch
            {
                MessageBox.Show("The Camera device is down!");
            }

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBoxEmail_Click(object sender, EventArgs e)
        {
            if (checkBoxEmail.Checked)
            {
                textBoxEmailadress.Enabled = true;
                textBoxAlerttext.Enabled = true;
                textBoxAlerttext.ForeColor = Color.Black;
                textBoxEmailadress.ForeColor = Color.Black;
            }
            else
            {
                textBoxEmailadress.Enabled = false;
                textBoxAlerttext.Enabled = false;
                textBoxAlerttext.ForeColor = Color.Silver;
                textBoxEmailadress.ForeColor = Color.Silver;
            }
        }

        private void buttonFolder_Click(object sender, EventArgs e)
        {


            if (folderBrowserDialogVideo.ShowDialog() == DialogResult.OK)
            { 
               labelFolder.Text = folderBrowserDialogVideo.SelectedPath;
               Properties.Settings.Default["Folder"] = folderBrowserDialogVideo.SelectedPath;
               Properties.Settings.Default.Save();
            }
        }
    }
}
