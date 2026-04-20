using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
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
        string drive, emailAlert, alertText, emailAdress, streamVideo;
        int setLocation;
        bool checkChanges = false, checkStream = false, checkEmail;
        private void FormSettings_Load(object sender, EventArgs e)
        {
            connString = Properties.Settings.Default.Database;
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
                    drive = reader.GetString("drive");
                    emailAlert = reader.GetString("email");
                    checkEmail = reader.GetBoolean("email");
                    textBoxEmailadress.Text = reader.GetString("sendemail");
                    textBoxAlerttext.Text = reader.GetString("alerttext");
                    textBoxStream.Text = reader.GetInt32("stream").ToString();
                    setLocation = reader.GetInt32("location");
                }
                conn.Close();
                labelFolder.Text = Properties.Settings.Default.Folder;

                if (emailAlert == "True")
                {
                    checkBoxEmail.Checked = true;
                    textBoxAlerttext.Enabled = true;
                    textBoxEmailadress.Enabled = true;
                    textBoxAlerttext.ForeColor = Color.Black;
                    textBoxEmailadress.ForeColor = Color.Black;
                    labelText.ForeColor = Color.Black;
                    labelText2.ForeColor = Color.Black;
                }
                else
                {
                    checkBoxEmail.Checked = false;
                    textBoxAlerttext.Enabled = false;
                    textBoxEmailadress.Enabled = false;
                    textBoxAlerttext.ForeColor = Color.Silver;
                    textBoxEmailadress.ForeColor = Color.Silver;
                    labelText.ForeColor = Color.DimGray;
                    labelText2.ForeColor = Color.DimGray;
                }

                if (drive == "True")
                {
                    checkBoxDrive.Checked = true;
                }
                else
                {
                    checkBoxDrive.Checked = false;
                }
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (checkBoxDrive.Checked)
            {
                drive = "True";
            }
            else
            {
                drive = "False";
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
                if (checkStream == true)
                {
                    MySqlConnection conn = new MySqlConnection(connString);
                    conn.Open();
                    checkString = "insert into cameralogs(logtext) values('Camera recording value was changed to " + streamVideo.ToString()+" seconds.');";
                    Clipboard.SetText(checkString);
                    MySqlCommand command = new MySqlCommand(checkString, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    conn.Close();
                }
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
            }

            try
            {
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                checkString = "update settings set drive='" + drive + "', email ='" + emailAlert + "', sendemail = '" + emailAdress + "', alerttext = '" + alertText + "', stream = '" + streamVideo + "' where id = 1;";
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
                startInfo.Arguments = "/C ssh camerauser@cameradevice sudo systemctl restart camerastystem.service";
                process.StartInfo = startInfo;
                process.Start();
            }
            catch
            {
                MessageBox.Show("The Camera device is down!", "Camera Device");
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
                if ((textBoxAlerttext.Text.Length > 0) && (textBoxStream.Text.Length > 0) && (textBoxEmailadress.Text.Length > 0))
                {
                    buttonOk.Enabled = true;
                }
                else
                {
                    buttonOk.Enabled = false;
                }
            }
            else
            {
                textBoxEmailadress.Enabled = false;
                textBoxAlerttext.Enabled = false;
                textBoxAlerttext.ForeColor = Color.Silver;
                textBoxEmailadress.ForeColor = Color.Silver;
                if (textBoxStream.Text.Length > 0)
                {
                    buttonOk.Enabled = true;
                }
                else
                {
                    buttonOk.Enabled = false;
                }
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

        private void textBoxStream_TextChanged(object sender, EventArgs e)
        {
            if (textBoxStream.Text != streamVideo)
            {
                checkStream = true;
            }
            else
            {
                checkStream = false;
            }

            if (checkEmail == true)
            {
                if ((textBoxAlerttext.Text.Length > 0) && (textBoxStream.Text.Length > 0) && (textBoxEmailadress.Text.Length > 0))
                {
                    buttonOk.Enabled = true;
                }
                else
                {
                    buttonOk.Enabled = false;
                }
            }
            else
            {
                if (textBoxStream.Text.Length > 0)
                {
                    buttonOk.Enabled = true;
                }
                else
                {
                    buttonOk.Enabled = false;
                }
            }
        }

        private void textBoxEmailadress_TextChanged(object sender, EventArgs e)
        {
            if ((textBoxAlerttext.Text.Length > 0) && (textBoxStream.Text.Length > 0) && (textBoxEmailadress.Text.Length > 0))
            {
                buttonOk.Enabled = true;
            }
            else
            {
                buttonOk.Enabled = false;
            }
        }

        private void textBoxAlerttext_TextChanged(object sender, EventArgs e)
        {
            if ((textBoxAlerttext.Text.Length > 0) && (textBoxStream.Text.Length > 0) && (textBoxEmailadress.Text.Length > 0))
            {
                buttonOk.Enabled = true;
            }
            else
            {
                buttonOk.Enabled = false;
            }
        }

        private void textBoxStream_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
