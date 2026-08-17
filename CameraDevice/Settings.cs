using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Crypto;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CameraDevice
{
    public partial class FormSettings : Form
    {
        public static bool checkSensors = false;
        public FormSettings()
        {
            InitializeComponent();
        }
        string checkString, connString;
        string drive, emailAlert, emailAdress, emailAdress2, streamVideo, setFolder, rowsOfNumbers, changeDate, openStatus;
        string user = "cameraruser";
        string password;
        string host = "cameradevice";
        int setChoice, setChoice2, setChoice3;
        int checkState = 0;
        bool checkChanges = false, checkEmail, noneEmail;
        private void FormSettings_Load(object sender, EventArgs e)
        {
            connString = HomeAssistant.Properties.Settings.Default.Database;
            password = HomeAssistant.Properties.Settings.Default.Password;
            try
            {
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
                    setChoice = reader.GetInt32("motionchoice1");
                    setChoice2 = reader.GetInt32("motionchoice2");
                    textBoxStream.Text = reader.GetInt32("stream").ToString();
                    streamVideo = reader.GetInt32("stream").ToString();
                    textBoxRows.Text = reader.GetInt32("numberofrows").ToString();
                    emailAdress2 = reader.GetString("sendemail");
                    changeDate = reader.GetDateTime("datechanged").ToString();
                    setChoice3 = reader.GetInt32("openstatus");
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

                if (setChoice == 1)
                {
                    checkBoxMotionSensor1.Checked = true;
                }
                else
                {
                    checkBoxMotionSensor1.Checked = false;
                }

                if (setChoice2 == 1)
                {
                    checkBoxMotionSensor2.Checked = true;
                }
                else
                {
                    checkBoxMotionSensor2.Checked = false;
                }

                if (setChoice3 == 1)
                {
                    checkBoxDoorSensor1.Checked = true;
                }
                else
                {
                    checkBoxDoorSensor1.Checked = false;
                }
                buttonOk.Enabled = false;

            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
            }
            labelDateModified.Text = "Settings last modified: " + changeDate;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            checkChanges = true;
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

            if (textBoxEmailadress.Text == "")
            {
                emailAdress = emailAdress2;
            }

            streamVideo = textBoxStream.Text;
            rowsOfNumbers = textBoxRows.Text;

            try
            {
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                checkString = "update settings set drive='" + drive + "', email ='" + emailAlert + "', sendemail = '" + emailAdress + "', motionchoice1 = '" + setChoice + "', motionchoice2 = '" + setChoice2 + "', stream = '" + streamVideo + "', numberofrows = '" + rowsOfNumbers + "', openstatus = '" + setChoice3 + "' where id = 1;";
                MySqlCommand command = new MySqlCommand(checkString, conn);
                command.ExecuteReader();
                conn.Close();
                conn.Open();
                checkString = "insert into cameralogs(logtext) values('Settings were updated.');";
                MySqlCommand command2 = new MySqlCommand(checkString, conn);
                MySqlDataReader reader2 = command2.ExecuteReader();
                conn.Close();

                MessageBox.Show("Settings updated.", "Camera Device");
                checkSensors = true;

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
                startInfo.Arguments = "/C ssh camerauser@cameradevice sudo /home/camerauser/camerasystem/camerarestart.sh";
                process.StartInfo = startInfo;
                process.Start();
            }
            catch (Exception i)
            {
                MessageBox.Show("The Camera device is down! ", "Camera Device");
                Clipboard.SetText(i.ToString());
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
                if ((textBoxStream.Text.Length > 0) && (textBoxEmailadress.Text.Length > 0))
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

                if (textBoxStream.Text.Length > 0)
                {
                    buttonOk.Enabled = true;
                }
            }

        }

        private void textBoxStream_TextChanged(object sender, EventArgs e)
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
        private void textBoxEmailadress_TextChanged(object sender, EventArgs e)
        {
            if ((textBoxStream.Text.Length > 0) && (textBoxEmailadress.Text.Length > 0))
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

        private void textBoxRows_TextChanged(object sender, EventArgs e)
        {
            if (textBoxRows.Text.Length > 0)
            {
                buttonOk.Enabled = true;
            }
            else
            {
                buttonOk.Enabled = false;
            }
        }

        private void textBoxRows_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private void checkBoxDoorSensor1_Click(object sender, EventArgs e)
        {
            if (checkBoxDoorSensor1.Checked)
            {
                setChoice3 = 1;
            }
            else
            {
                setChoice3 = 0;
            }
        }

        private void checkBoxMotionSensor1_Click(object sender, EventArgs e)
        {
            if (checkBoxMotionSensor1.Checked)
            {
                setChoice = 1;
            }
            else
            {
                setChoice = 0;
            }
        }

        private void checkBoxMotionSensor2_Click(object sender, EventArgs e)
        {
            if (checkBoxMotionSensor2.Checked)
            {
                setChoice2 = 1;
            }
            else
            {
                setChoice2 = 0;
            }
        }
        private void checkBoxEmail_CheckStateChanged(object sender, EventArgs e)
        {
            buttonOk.Enabled = true;
        }

        private void checkBoxDrive_CheckStateChanged(object sender, EventArgs e)
        {
            buttonOk.Enabled = true;
        }

        private void checkBoxDoorSensor1_CheckedChanged(object sender, EventArgs e)
        {
            buttonOk.Enabled = true;
        }

        private void checkBoxMotionSensor1_CheckedChanged(object sender, EventArgs e)
        {
            buttonOk.Enabled = true;
        }

        private void checkBoxMotionSensor2_CheckedChanged(object sender, EventArgs e)
        {
            buttonOk.Enabled = true;
        }

        private void FormSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (checkChanges == false)
            {
                MessageBox.Show("Changed settings were not updated.", "Camera Device");
            }
        }
    }
}
