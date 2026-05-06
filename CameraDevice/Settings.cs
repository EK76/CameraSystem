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


        string[] videoFolder2 = File.ReadAllLines("settings.txt");
        string videoFolder;
        string checkString, connString;
        string drive, emailAlert, alertText, emailAdress, emailAdress2, streamVideo, streamVideo2, setFolder;
        int checkState = 0;
        bool checkChanges = false, checkEmail, noneEmail;
        private void FormSettings_Load(object sender, EventArgs e)
        {
            connString = Properties.Settings.Default.Database;
            try
            {
                labelFolder.Text = "Video folder: " + videoFolder2[0];
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
                    streamVideo = reader.GetInt32("stream").ToString();
                    streamVideo2 = reader.GetInt32("stream").ToString();
                    emailAdress2 = reader.GetString("sendemail");
                }
                conn.Close();
                if (emailAlert == "True")
                {
                    checkBoxEmail.Checked = true;
                    textBoxEmailadress.Enabled = true;
                    labelText.ForeColor = Color.Black;
                    noneEmail = true;
                }
                else
                {
                    checkBoxEmail.Checked = false;
                    textBoxEmailadress.Enabled = false;
                    labelText.ForeColor = Color.DimGray;
                    noneEmail = false;
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
                emailAdress = textBoxEmailadress.Text;
            }
            else
            {
                emailAlert = "False";
                emailAdress = emailAdress2;
            }
            alertText = textBoxAlerttext.Text;
            streamVideo = textBoxStream.Text;

            try
            {
                if (streamVideo != streamVideo2)
                {
                    MySqlConnection conn = new MySqlConnection(connString);
                    conn.Open();
                    checkString = "insert into cameralogs(logtext) values('Camera recording value was changed to " + streamVideo.ToString() + " seconds.');";
                //   MessageBox.Show(checkString);
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


            string[] lines = File.ReadAllLines("settings.txt");
            lines[0] = setFolder;
            File.WriteAllLines("settings.txt", lines);

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
                labelText.ForeColor = Color.Black;
                if ((textBoxAlerttext.Text.Length > 0) && (textBoxStream.Text.Length > 0) && (textBoxEmailadress.Text.Length > 0))
                {
                    buttonOk.Enabled = true;
                }
                else
                {
                    buttonOk.Enabled = false;
                }
                if (textBoxEmailadress.Text.Length > 0)
                {
                    noneEmail = false;
                }
                else
                {
                    noneEmail = true;
                }
            }
            else
            {
                textBoxEmailadress.Enabled = false;
                labelText.ForeColor = Color.Silver;
                noneEmail = false;

                if ((textBoxAlerttext.Text.Length > 0) && (textBoxStream.Text.Length > 0))
                {
                    buttonOk.Enabled = true;
                }
            }

        }

        private void buttonFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogVideo.ShowDialog() == DialogResult.OK)
            {
                labelFolder.Text = labelFolder.Text = "Video folder: " + folderBrowserDialogVideo.SelectedPath;
                setFolder = folderBrowserDialogVideo.SelectedPath;
                Main.checkFolder = true;
            }
        }

        private void textBoxStream_TextChanged(object sender, EventArgs e)
        {
            if ((textBoxAlerttext.Text.Length > 0) && (textBoxStream.Text.Length > 0) && (noneEmail == false))
            {
                buttonOk.Enabled = true;
            }
            else
            {
                buttonOk.Enabled = false;
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

            if (textBoxEmailadress.Text.Length > 0)
            {
                noneEmail = false;
            }
            else
            {
                noneEmail = true;
            }
        }

        private void textBoxAlerttext_TextChanged(object sender, EventArgs e)
        {
            if ((textBoxAlerttext.Text.Length > 0) && (textBoxStream.Text.Length > 0) && (noneEmail == false))
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

        private void checkBoxDrive_Click(object sender, EventArgs e)
        {
            buttonOk.Enabled = true;
        }

        private void textBoxAlerttext_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsLetter(e.KeyChar)) && (!char.IsWhiteSpace(e.KeyChar)) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled |= true;
            }
        }
    }
}
