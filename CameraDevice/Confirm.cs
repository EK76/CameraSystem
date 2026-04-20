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
    public partial class FormConfirm : Form
    {
        public FormConfirm()
        {
            InitializeComponent();
        }

       
        string checkString, connString;
        
        private void buttonNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            try
            {
                connString = Properties.Settings.Default.Database;
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                checkString = "delete from cameralogs";
                MySqlCommand command = new MySqlCommand(checkString, conn);
                MySqlDataReader reader = command.ExecuteReader();
                conn.Close();
                MessageBox.Show("Table have been emptied!");
            }
            catch (Exception i)
            {
                MessageBox.Show(i.Message);
            }
            Close();

        }

        private void textBoxConfirm_TextChanged(object sender, EventArgs e)
        {
            if (textBoxConfirm.Text == "confirm")
            {
                buttonYes.Enabled = true;
            }
            else
            {
                buttonYes.Enabled = false;
            }
        }

        private void Confirm_Load(object sender, EventArgs e)
        {

        }
    }
}
