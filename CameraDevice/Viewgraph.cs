using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Sensordevice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CameraDevice
{
    public partial class FormViewgraph : Form
    {
        public FormViewgraph()
        {
            InitializeComponent();
        }

        List<int> dateCounts = new List<int>();
        List<int> topicCounts = new List<int>();
        string connString = HomeAssistant.Properties.Settings.Default.Database, checkString;
        int dateNumbers, topicNumbers, count, checkCount, index, index2, choice = 1;
        bool openForm = false;
        public static string setString, setColumn;
        public static int setColor;
        bool checkView = true;

        void dateView()
        {
            buttonViewChange.Visible = false;
            chartView.Series[0].ChartType = SeriesChartType.Column;
            buttonViewChange.Text = "View as pie";
            checkView = true;
            chartView.Series[0].Points.Clear();
            MySqlConnection conn = new MySqlConnection(connString);
            dateNumbers = FormLogs.listDates.Count;
            dateCounts.Clear();

            for (int index = 0; index < dateNumbers; index++)
            {
                conn.Open();
                checkString = "select count(*) from cameralogs where datecreated like '" + FormLogs.listDates[index] + "%'";
                MySqlCommand command = new MySqlCommand(checkString, conn);
                count = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();
                dateCounts.Add(count);
                checkCount++;
                conn.Close();
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
            choice = 1;
        }

        void topicView()
        {
            buttonViewChange.Visible = true;
            chartView.Series[0].Points.Clear();
            MySqlConnection conn = new MySqlConnection(connString);
            topicNumbers = FormLogs.listTopics.Count;
            topicCounts.Clear();
            for (int index = 0; index < topicNumbers; index++)
            {
                conn.Open();
                checkString = "select count(*) from cameralogs where infocode = '" + FormLogs.listTopics[index] + "';";
                MySqlCommand command = new MySqlCommand(checkString, conn);
                count = Convert.ToInt32(command.ExecuteScalar());
                conn.Close();
                topicCounts.Add(count);
                checkCount++;
            }
            index = 0;
            index2 = 1;

            foreach (var addValue in topicCounts)
            {
                chartView.Series[0].Points.AddXY(index2, addValue);
                chartView.Series[0].Points[index].Label = addValue.ToString();
                chartView.ChartAreas[0].AxisX.Interval = 1;
                chartView.Series[0].Points[index].AxisLabel = FormLogs.listTopics[index];
                if (FormLogs.listTopics[index] == "0")
                {
                    chartView.Series[0].Points[index].Color = Color.Green;
                }
                if (FormLogs.listTopics[index] == "1")
                {
                    chartView.Series[0].Points[index].Color = Color.Yellow;
                }
                if (FormLogs.listTopics[index] == "2")
                {
                    chartView.Series[0].Points[index].Color = Color.Red;
                }
                index++;
                index2++;
            }
            choice = 2;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Viewgraph_Load(object sender, EventArgs e)
        {
            dateView();
        }
        private void radioButtonShowDates_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonShowDates.Checked)
            {
                dateView();
            }
        }

        private void radioButtonShowTopics_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonShowTopics.Checked)
            {
                topicView();
            }
        }

        private void chartView_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            string setValue = "";

            if (choice == 1)
            {
                if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
                {
                    HitTestResult result = chartView.HitTest(e.X, e.Y);
                    if (result.PointIndex >= 0)
                    {
                        setValue = chartView.Series[0].Points[result.PointIndex].AxisLabel;

                    }
                    setString = "select * from cameralogs where datecreated like '" + setValue + "%';";
                    setColumn = "Date " + setValue + "is selected";
                    openForm = true;
                    setColor = 3;
                }
                else
                {
                    openForm = false;
                }
            }
            else
            {
                if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
                {
                    HitTestResult result = chartView.HitTest(e.X, e.Y);
                    if (result.PointIndex >= 0)
                    {
                        setValue = chartView.Series[0].Points[result.PointIndex].AxisLabel;

                    }
                    setString = "select * from cameralogs where infocode = '" + (Convert.ToInt32(setValue)) + "';";
                    setColumn = "Infocode " + (Convert.ToInt32(setValue)) + " is selected";
                    setColor = Convert.ToInt32(setValue);
                    openForm = true;
                }
                else
                {
                    openForm = false;
                }
            }
        }

        private void chartView_Click(object sender, EventArgs e)
        {
            if (openForm)
            {
                FormLogscolumn logsColumn = new FormLogscolumn();
                logsColumn.ShowDialog();
            }
        }

        private void buttonViewChange_Click(object sender, EventArgs e)
        {
            if (checkView)
            {
                chartView.Series[0].ChartType = SeriesChartType.Pie;
                buttonViewChange.Text = "View as column";
                checkView = false;
            }
            else
            {
                chartView.Series[0].ChartType = SeriesChartType.Column;
                buttonViewChange.Text = "View as pie";
                checkView = true;
                index = 0;
            }
        }
    }
}
