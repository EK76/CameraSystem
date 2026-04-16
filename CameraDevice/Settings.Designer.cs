namespace CameraDevice
{
    partial class FormSettings
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
            buttonOk = new Button();
            buttonCancel = new Button();
            textBoxEmailadress = new TextBox();
            textBoxAlerttext = new TextBox();
            labelText = new Label();
            labelText2 = new Label();
            panel1 = new Panel();
            checkBoxEmail = new CheckBox();
            textBoxStream = new TextBox();
            labelText3 = new Label();
            panel2 = new Panel();
            folderBrowserDialogVideo = new FolderBrowserDialog();
            buttonFolder = new Button();
            labelText4 = new Label();
            labelFolder = new Label();
            checkBoxDrive = new CheckBox();
            SuspendLayout();
            // 
            // buttonOk
            // 
            buttonOk.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            buttonOk.Location = new Point(175, 433);
            buttonOk.Margin = new Padding(4, 3, 4, 3);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(96, 25);
            buttonOk.TabIndex = 0;
            buttonOk.Text = "Ok";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            buttonCancel.Location = new Point(292, 433);
            buttonCancel.Margin = new Padding(4, 3, 4, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(96, 25);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // textBoxEmailadress
            // 
            textBoxEmailadress.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            textBoxEmailadress.Location = new Point(28, 70);
            textBoxEmailadress.Margin = new Padding(4, 3, 4, 3);
            textBoxEmailadress.Name = "textBoxEmailadress";
            textBoxEmailadress.Size = new Size(241, 25);
            textBoxEmailadress.TabIndex = 3;
            // 
            // textBoxAlerttext
            // 
            textBoxAlerttext.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            textBoxAlerttext.Location = new Point(30, 135);
            textBoxAlerttext.Margin = new Padding(4, 3, 4, 3);
            textBoxAlerttext.Name = "textBoxAlerttext";
            textBoxAlerttext.Size = new Size(241, 25);
            textBoxAlerttext.TabIndex = 4;
            // 
            // labelText
            // 
            labelText.AutoSize = true;
            labelText.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelText.ForeColor = Color.DimGray;
            labelText.Location = new Point(28, 51);
            labelText.Margin = new Padding(4, 0, 4, 0);
            labelText.Name = "labelText";
            labelText.Size = new Size(85, 17);
            labelText.TabIndex = 5;
            labelText.Text = "Email adress";
            // 
            // labelText2
            // 
            labelText2.AutoSize = true;
            labelText2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelText2.Location = new Point(28, 116);
            labelText2.Margin = new Padding(4, 0, 4, 0);
            labelText2.Name = "labelText2";
            labelText2.Size = new Size(66, 17);
            labelText2.TabIndex = 6;
            labelText2.Text = "Alert text";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlText;
            panel1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            panel1.Location = new Point(0, 179);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(424, 1);
            panel1.TabIndex = 8;
            // 
            // checkBoxEmail
            // 
            checkBoxEmail.AutoSize = true;
            checkBoxEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            checkBoxEmail.Location = new Point(28, 28);
            checkBoxEmail.Margin = new Padding(4, 3, 4, 3);
            checkBoxEmail.Name = "checkBoxEmail";
            checkBoxEmail.Size = new Size(140, 21);
            checkBoxEmail.TabIndex = 9;
            checkBoxEmail.Text = "Enable Email Alert";
            checkBoxEmail.UseVisualStyleBackColor = true;
            checkBoxEmail.Click += checkBoxEmail_Click;
            // 
            // textBoxStream
            // 
            textBoxStream.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            textBoxStream.Location = new Point(24, 211);
            textBoxStream.Margin = new Padding(4, 3, 4, 3);
            textBoxStream.Name = "textBoxStream";
            textBoxStream.Size = new Size(54, 25);
            textBoxStream.TabIndex = 10;
            // 
            // labelText3
            // 
            labelText3.AutoSize = true;
            labelText3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelText3.Location = new Point(24, 190);
            labelText3.Margin = new Padding(4, 0, 4, 0);
            labelText3.Name = "labelText3";
            labelText3.Size = new Size(159, 17);
            labelText3.TabIndex = 11;
            labelText3.Text = "Set video stream lenght.";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlText;
            panel2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            panel2.Location = new Point(0, 316);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(424, 1);
            panel2.TabIndex = 9;
            // 
            // buttonFolder
            // 
            buttonFolder.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            buttonFolder.Location = new Point(23, 362);
            buttonFolder.Margin = new Padding(4, 3, 4, 3);
            buttonFolder.Name = "buttonFolder";
            buttonFolder.Size = new Size(96, 25);
            buttonFolder.TabIndex = 12;
            buttonFolder.Text = "Browse";
            buttonFolder.UseVisualStyleBackColor = true;
            buttonFolder.Click += buttonFolder_Click;
            // 
            // labelText4
            // 
            labelText4.AutoSize = true;
            labelText4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelText4.Location = new Point(28, 331);
            labelText4.Margin = new Padding(4, 0, 4, 0);
            labelText4.Name = "labelText4";
            labelText4.Size = new Size(144, 17);
            labelText4.TabIndex = 13;
            labelText4.Text = "Set main video folder.";
            // 
            // labelFolder
            // 
            labelFolder.AutoSize = true;
            labelFolder.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelFolder.Location = new Point(28, 406);
            labelFolder.Margin = new Padding(4, 0, 4, 0);
            labelFolder.Name = "labelFolder";
            labelFolder.Size = new Size(45, 17);
            labelFolder.TabIndex = 14;
            labelFolder.Text = "label1";
            // 
            // checkBoxDrive
            // 
            checkBoxDrive.AutoSize = true;
            checkBoxDrive.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            checkBoxDrive.Location = new Point(28, 263);
            checkBoxDrive.Margin = new Padding(4, 3, 4, 3);
            checkBoxDrive.Name = "checkBoxDrive";
            checkBoxDrive.Size = new Size(111, 21);
            checkBoxDrive.TabIndex = 15;
            checkBoxDrive.Text = "Remote Drive";
            checkBoxDrive.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new SizeF(9F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 475);
            Controls.Add(checkBoxDrive);
            Controls.Add(labelFolder);
            Controls.Add(labelText4);
            Controls.Add(buttonFolder);
            Controls.Add(panel2);
            Controls.Add(labelText3);
            Controls.Add(textBoxStream);
            Controls.Add(checkBoxEmail);
            Controls.Add(panel1);
            Controls.Add(labelText2);
            Controls.Add(labelText);
            Controls.Add(textBoxAlerttext);
            Controls.Add(textBoxEmailadress);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOk);
            Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormSettings";
            ShowIcon = false;
            Text = "Camera Device";
            Load += FormSettings_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonOk;
        private Button buttonCancel;
        private TextBox textBoxEmailadress;
        private TextBox textBoxAlerttext;
        private Label labelText;
        private Label labelText2;
        private Panel panel1;
        private CheckBox checkBoxEmail;
        private TextBox textBoxStream;
        private Label labelText3;
        private Panel panel2;
        private FolderBrowserDialog folderBrowserDialogVideo;
        private Button buttonFolder;
        private Label labelText4;
        private Label labelFolder;
        private CheckBox checkBoxDrive;
    }
}