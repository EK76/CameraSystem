namespace CameraDevice
{
    partial class Logs
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
            SuspendLayout();
            // 
            // buttonClose
            // 
            buttonClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            buttonClose.Location = new Point(441, 669);
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
            listViewLogs.Location = new Point(9, 40);
            listViewLogs.Name = "listViewLogs";
            listViewLogs.Size = new Size(507, 623);
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
            labelText.Location = new Point(12, 9);
            labelText.Name = "labelText";
            labelText.Size = new Size(75, 17);
            labelText.TabIndex = 2;
            labelText.Text = "Show logs.";
            // 
            // buttonBackup
            // 
            buttonBackup.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            buttonBackup.Location = new Point(336, 669);
            buttonBackup.Name = "buttonBackup";
            buttonBackup.Size = new Size(99, 25);
            buttonBackup.TabIndex = 3;
            buttonBackup.Text = "Backup Logs";
            buttonBackup.UseVisualStyleBackColor = true;
            buttonBackup.Click += buttonBackup_Click;
            // 
            // FormLogs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(528, 704);
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
    }
}