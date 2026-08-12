namespace CameraDevice
{
    partial class FormViewgraph
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            buttonClose = new Button();
            chartView = new System.Windows.Forms.DataVisualization.Charting.Chart();
            labelText = new Label();
            ((System.ComponentModel.ISupportInitialize)chartView).BeginInit();
            SuspendLayout();
            // 
            // buttonClose
            // 
            buttonClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonClose.Location = new Point(728, 542);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(75, 23);
            buttonClose.TabIndex = 0;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // chartView
            // 
            chartView.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.Name = "ChartArea1";
            chartView.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartView.Legends.Add(legend2);
            chartView.Location = new Point(12, 43);
            chartView.Name = "chartView";
            series2.ChartArea = "ChartArea1";
            series2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            series2.IsValueShownAsLabel = true;
            series2.IsVisibleInLegend = false;
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.YValuesPerPoint = 2;
            chartView.Series.Add(series2);
            chartView.Size = new Size(798, 484);
            chartView.TabIndex = 1;
            chartView.Text = "chart1";
            // 
            // labelText
            // 
            labelText.AutoSize = true;
            labelText.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelText.Location = new Point(12, 9);
            labelText.Name = "labelText";
            labelText.Size = new Size(230, 17);
            labelText.TabIndex = 2;
            labelText.Text = "Number of evenrs for current dates.";
            // 
            // FormViewgraph
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(822, 581);
            Controls.Add(labelText);
            Controls.Add(chartView);
            Controls.Add(buttonClose);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormViewgraph";
            ShowIcon = false;
            Text = "Camera Device";
            Load += Viewgraph_Load;
            ((System.ComponentModel.ISupportInitialize)chartView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonClose;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartView;
        private Label labelText;
    }
}