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

namespace CameraDevice
{
    public partial class FormLogs : Form
    {
        public FormLogs()
        {
            InitializeComponent();

        }

        string checkString, connString;
        string user = "loguser";
        string password = "Test0880!";
        string host = "cameradevice";
        int counterItems = 0;

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormLogs_Load(object sender, EventArgs e)
        {
            connString = "SERVER = cameradevice; DATABASE = camerasystem; UID = loguser; PASSWORD = Test0880!";
            try
            {
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                checkString = "select * from cameralogs order by datecreated desc;";
                Clipboard.SetText(checkString);
                MySqlCommand command = new MySqlCommand(checkString, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    counterItems++;
                    if (counterItems == 1)
                    {
                        listViewLogs.Items.Clear();
                    }
                    listViewLogs.Items.Add(new ListViewItem(new string[] { reader.GetString("logtext").ToString(), reader.GetDateTime("datecreated").ToString("dd-MM-yyyy HH:mm") }));
                }
                conn.Close();
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
            }

        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            string filename = "";
            SaveFileDialog saveContent = new SaveFileDialog();

            saveContent.Title = "Save Data";
            saveContent.Filter = "Backup log (.log) | *.log";

            try
            {
                if (saveContent.ShowDialog() == DialogResult.OK)
                {
                    filename = saveContent.FileName.ToString();
                    if (filename != "")
                    {
                        using (StreamWriter sw = new StreamWriter(filename))
                        {
                            foreach (ListViewItem item in listViewLogs.Items)
                            {
                                sw.WriteLine("{0}{1}", item.SubItems[0].Text + "  ", item.SubItems[1].Text);
                            }
                        }
                        MessageBox.Show("File " + filename + " is susccessfully saved!");
                    }
                }
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
            }
        }
    }
}
