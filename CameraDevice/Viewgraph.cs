using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CameraDevice
{
    public partial class FormViewgraph : Form
    {
        public FormViewgraph()
        {
            InitializeComponent();
        }

        List<int> dateCounts = new List<int>();
        string connString, checkString;
        int dateNumbers, count, checkCount, index, index2;
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Viewgraph_Load(object sender, EventArgs e)
        {
            connString = HomeAssistant.Properties.Settings.Default.Database;
            MySqlConnection conn = new MySqlConnection(connString);
            dateNumbers = FormLogs.listDates.Count;
            dateCounts.Clear();

            chartView.Series[0].Points.Clear();


            for (int index = 0; index < dateNumbers; index++)
            {
                conn.Open();
                checkString = "select count(*) from cameralogs where datecreated like '" + FormLogs.listDates[index] + "%'";
                MySqlCommand command = new MySqlCommand(checkString, conn);
                count = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();
                dateCounts.Add(count);
                checkCount++;
            }

            index = 0;
            index2 = 1;
            
            foreach (var addValue in dateCounts)
            {
                chartView.Series[0].Points.AddXY(index2, addValue);
                chartView.Series[0].Points[index].Label = addValue.ToString();
                chartView.Series[0].Points[index].AxisLabel = FormLogs.listDates[index].ToString();
                index++;
                index2++;
            }
            
        }
    }
}
