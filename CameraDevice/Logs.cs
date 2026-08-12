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
    public partial class FormLogs : Form
    {
        public FormLogs()
        {
            InitializeComponent();
        }

        string checkString, checkItem, compareString;
        int counterItems = 0, indexItemm, countRows;
        bool answer;
        string connString;
        public static List<string > listDates = new List<string>();


        void countLog(string textLog, string currentSelection)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand command = new MySqlCommand(currentSelection, conn);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            labelCountRows.Text = textLog + reader["numbers"].ToString();
            conn.Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormLogs_Load(object sender, EventArgs e)
        {
            connString = HomeAssistant.Properties.Settings.Default.Database;
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
                comboBoxSelection.Items.Add("All items");
                while (reader.Read())
                {
                   comboBoxSelection.Items.Add(reader.GetString("logtext").ToString());
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
                checkString = "select distinct left(datecreated, instr(datecreated,' ')) as 'datecreated' from cameralogs;";
                Clipboard.SetText(checkString);
                MySqlCommand command = new MySqlCommand(checkString, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    checkItem = reader.GetString("datecreated").ToString();
                    answer = checkItem.Contains(compareString);
                    if (!answer)
                    {
                        comboBoxDate.Items.Add(reader.GetString("datecreated").ToString());
                        listDates.Add(reader.GetString("datecreated").ToString());

                    }

                }
                conn.Close();
                comboBoxDate.Items.Add("All items");
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
            }
            countLog("Total logs :", "select count(*) as 'numbers' from cameralogs;");

            conn.Open();
            checkString = "select * from cameralogs order by datecreated asc limit 1;";
            MySqlCommand command2 = new MySqlCommand(checkString, conn);
            MySqlDataReader reader2 = command2.ExecuteReader();
            reader2.Read();
            labelDateStart.Text = "Start date: " + reader2["datecreated"].ToString();
            conn.Close();

            conn.Open();
            checkString = "select * from cameralogs order by datecreated desc limit 1;";
            MySqlCommand command3 = new MySqlCommand(checkString, conn);
            MySqlDataReader reader3 = command3.ExecuteReader();
            reader3.Read();
            labelDateEnd.Text = "End date: " + reader3["datecreated"].ToString();
            conn.Close();
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
                        MessageBox.Show("File " + filename + " is susccessfully saved!", "Camera Device");
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
                countLog("Total logs :", "select count(*) as 'numbers' from cameralogs;");
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
                countLog("Numbers for selected item: ", "select count(*) as 'numbers' from cameralogs where logtext like '" + comboBoxSelection.SelectedItem + "%';");
            }
        }

        private void comboBoxDate_SelectedValueChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            if (comboBoxDate.SelectedItem == "All items")
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
                countLog("Total logs :", "select count(*) as 'numbers' from cameralogs;");
            }
            else
            {
                try
                {
                    listViewLogs.Items.Clear();
                    conn.Open();
                    checkString = "select * from cameralogs where datecreated like '" + comboBoxDate.SelectedItem + "%'order by datecreated desc;";
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
                countLog("Numbers for selected item: ", "select count(*) as 'numbers' from cameralogs where datecreated like '" + comboBoxDate.SelectedItem + "%';");
            }
        }

        private void buttonGraph_Click(object sender, EventArgs e)
        {
            FormViewgraph viewgraph = new FormViewgraph();
            viewgraph.ShowDialog();
        }
    }
}

