namespace CameraDevice
{
    partial class FormLogs
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
            buttonClose = new Button();
            listViewLogs = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            labelText = new Label();
            buttonBackup = new Button();
            comboBoxSelection = new ComboBox();
            labelCountRows = new Label();
            comboBoxDate = new ComboBox();
            labelDateStart = new Label();
            labelDateEnd = new Label();
            buttonGraph = new Button();
            SuspendLayout();
            // 
            // buttonClose
            // 
            buttonClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            buttonClose.Location = new Point(518, 719);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(75, 25);
            buttonClose.TabIndex = 0;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // listViewLogs
            // 
            listViewLogs.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listViewLogs.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            listViewLogs.Location = new Point(11, 84);
            listViewLogs.Name = "listViewLogs";
            listViewLogs.Size = new Size(583, 623);
            listViewLogs.TabIndex = 1;
            listViewLogs.UseCompatibleStateImageBehavior = false;
            listViewLogs.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Log";
            columnHeader1.Width = 380;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Date";
            columnHeader2.Width = 120;
            // 
            // labelText
            // 
            labelText.AutoSize = true;
            labelText.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelText.Location = new Point(14, 53);
            labelText.Name = "labelText";
            labelText.Size = new Size(75, 17);
            labelText.TabIndex = 2;
            labelText.Text = "Show logs.";
            // 
            // buttonBackup
            // 
            buttonBackup.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            buttonBackup.Location = new Point(413, 719);
            buttonBackup.Name = "buttonBackup";
            buttonBackup.Size = new Size(99, 25);
            buttonBackup.TabIndex = 3;
            buttonBackup.Text = "Backup Logs";
            buttonBackup.UseVisualStyleBackColor = true;
            buttonBackup.Click += buttonBackup_Click;
            // 
            // comboBoxSelection
            // 
            comboBoxSelection.FormattingEnabled = true;
            comboBoxSelection.Location = new Point(151, 52);
            comboBoxSelection.Name = "comboBoxSelection";
            comboBoxSelection.Size = new Size(205, 23);
            comboBoxSelection.TabIndex = 4;
            comboBoxSelection.SelectedIndexChanged += comboBoxSelection_SelectedIndexChanged;
            // 
            // labelCountRows
            // 
            labelCountRows.AutoSize = true;
            labelCountRows.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelCountRows.Location = new Point(14, 724);
            labelCountRows.Name = "labelCountRows";
            labelCountRows.Size = new Size(45, 17);
            labelCountRows.TabIndex = 5;
            labelCountRows.Text = "label1";
            // 
            // comboBoxDate
            // 
            comboBoxDate.FormattingEnabled = true;
            comboBoxDate.Location = new Point(391, 52);
            comboBoxDate.Name = "comboBoxDate";
            comboBoxDate.Size = new Size(121, 23);
            comboBoxDate.TabIndex = 6;
            comboBoxDate.SelectedValueChanged += comboBoxDate_SelectedValueChanged;
            // 
            // labelDateStart
            // 
            labelDateStart.AutoSize = true;
            labelDateStart.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelDateStart.Location = new Point(157, 10);
            labelDateStart.Name = "labelDateStart";
            labelDateStart.Size = new Size(96, 17);
            labelDateStart.TabIndex = 7;
            labelDateStart.Text = "labelDateStart";
            // 
            // labelDateEnd
            // 
            labelDateEnd.AutoSize = true;
            labelDateEnd.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelDateEnd.Location = new Point(394, 7);
            labelDateEnd.Name = "labelDateEnd";
            labelDateEnd.Size = new Size(45, 17);
            labelDateEnd.TabIndex = 8;
            labelDateEnd.Text = "label2";
            // 
            // buttonGraph
            // 
            buttonGraph.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            buttonGraph.ImageAlign = ContentAlignment.BottomCenter;
            buttonGraph.Location = new Point(316, 721);
            buttonGraph.Name = "buttonGraph";
            buttonGraph.Size = new Size(91, 23);
            buttonGraph.TabIndex = 9;
            buttonGraph.Text = "View Graph";
            buttonGraph.UseVisualStyleBackColor = true;
            buttonGraph.Click += buttonGraph_Click;
            // 
            // FormLogs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(606, 754);
            Controls.Add(buttonGraph);
            Controls.Add(labelDateEnd);
            Controls.Add(labelDateStart);
            Controls.Add(comboBoxDate);
            Controls.Add(labelCountRows);
            Controls.Add(comboBoxSelection);
            Controls.Add(buttonBackup);
            Controls.Add(labelText);
            Controls.Add(listViewLogs);
            Controls.Add(buttonClose);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogs";
            ShowIcon = false;
            Text = "Camera Device";
            Load += FormLogs_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonClose;
        private ListView listViewLogs;
        private Label labelText;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button buttonBackup;
        private ComboBox comboBoxSelection;
        private Label labelCountRows;
        private ComboBox comboBoxDate;
        private Label labelDateStart;
        private Label labelDateEnd;
        private Button buttonGraph;
    }
}