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
    public partial class Logs : Form
    {
        public Logs()
        {
            InitializeComponent();

        }

        string checkString, checkItem, compareString;
        int counterItems = 0, indexItem;
        bool answer;
        string connString;

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormLogs_Load(object sender, EventArgs e)
        {
            connString = Properties.Settings.Default.Database;
            MySqlConnection conn = new MySqlConnection(connString);
            compareString = "Camera recording value was changed";
            
            try
            {
                conn.Open();
                checkString = "select * from cameralogs order by datecreated desc;";
                Clipboard.SetText(checkString);
                MySqlCommand command = new MySqlCommand(checkString, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                  listViewLogs.Items.Add(new ListViewItem(new string[] { reader.GetString("logtext").ToString(), reader.GetDateTime("datecreated").ToString("dd-MM-yyyy HH:mm") }));
                }
                conn.Close();
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
            }

            try
            {
                conn.Open();
                checkString = "select distinct left(logtext, instr(logtext,'.')) as 'logtext' from cameralogs;";
                Clipboard.SetText(checkString);
                MySqlCommand command = new MySqlCommand(checkString, conn);
                MySqlDataReader reader = command.ExecuteReader();
                comboBoxSelection.Items.Add(compareString);
                while (reader.Read())
                {
                    checkItem = reader.GetString("logtext").ToString();
                    answer = checkItem.Contains(compareString);
                    if (!answer)
                    {
                        comboBoxSelection.Items.Add(reader.GetString("logtext").ToString());
                    }

                }
                conn.Close();
                comboBoxSelection.Items.Add("All items");
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

        private void comboBoxSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connString);

            if (comboBoxSelection.SelectedItem == "All items")
            {
                try
                {
                    listViewLogs.Items.Clear();
                    conn.Open();
                    checkString = "select * from cameralogs order by datecreated desc;";
                    Clipboard.SetText(checkString);
                    MySqlCommand command = new MySqlCommand(checkString, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listViewLogs.Items.Add(new ListViewItem(new string[] { reader.GetString("logtext").ToString(), reader.GetDateTime("datecreated").ToString("dd-MM-yyyy HH:mm") }));
                    }
                    conn.Close();
                }
                catch (Exception i)
                {
                    MessageBox.Show(i.Message);
                }
            }
            else
            {
                try
                {
                    listViewLogs.Items.Clear();
                    conn.Open();
                    checkString = "select * from cameralogs where logtext like '" + comboBoxSelection.SelectedItem + "%'order by datecreated desc;";
                    Clipboard.SetText(checkString);
                    MySqlCommand command = new MySqlCommand(checkString, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        listViewLogs.Items.Add(new ListViewItem(new string[] { reader.GetString("logtext").ToString(), reader.GetDateTime("datecreated").ToString("dd-MM-yyyy HH:mm") }));
                    }
                    conn.Close();
                }
                catch (Exception i)
                {
                    MessageBox.Show(i.Message);
                }
            }
        }
    }
}
