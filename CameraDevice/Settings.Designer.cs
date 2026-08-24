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
            labelText = new Label();
            labelText2 = new Label();
            panel1 = new Panel();
            checkBoxEmail = new CheckBox();
            textBoxStream = new TextBox();
            labelText3 = new Label();
            panel2 = new Panel();
            folderBrowserDialogVideo = new FolderBrowserDialog();
            checkBoxDrive = new CheckBox();
            textBoxRows = new TextBox();
            labelText5 = new Label();
            labelDateModified = new Label();
            labelText6 = new Label();
            checkBoxDoorSensor1 = new CheckBox();
            checkBoxMotionSensor1 = new CheckBox();
            checkBoxMotionSensor2 = new CheckBox();
            labelText7 = new Label();
            checkBoxUsbCamera1 = new CheckBox();
            checkBoxUsbCamera2 = new CheckBox();
            SuspendLayout();
            // 
            // buttonOk
            // 
            buttonOk.Enabled = false;
            buttonOk.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            buttonOk.Location = new Point(340, 520);
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
            buttonCancel.Location = new Point(457, 520);
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
            textBoxEmailadress.Location = new Point(20, 293);
            textBoxEmailadress.Margin = new Padding(4, 3, 4, 3);
            textBoxEmailadress.Name = "textBoxEmailadress";
            textBoxEmailadress.Size = new Size(241, 25);
            textBoxEmailadress.TabIndex = 3;
            textBoxEmailadress.Click += textBoxRows_Click;
            textBoxEmailadress.TextChanged += textBoxEmailadress_TextChanged;
            // 
            // labelText
            // 
            labelText.AutoSize = true;
            labelText.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelText.ForeColor = Color.Black;
            labelText.Location = new Point(20, 274);
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
            labelText2.Location = new Point(15, 90);
            labelText2.Margin = new Padding(4, 0, 4, 0);
            labelText2.Name = "labelText2";
            labelText2.Size = new Size(170, 17);
            labelText2.TabIndex = 6;
            labelText2.Text = "Set active motion sensors.";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlText;
            panel1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            panel1.Location = new Point(3, 231);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(550, 1);
            panel1.TabIndex = 8;
            // 
            // checkBoxEmail
            // 
            checkBoxEmail.AutoSize = true;
            checkBoxEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            checkBoxEmail.Location = new Point(20, 251);
            checkBoxEmail.Margin = new Padding(4, 3, 4, 3);
            checkBoxEmail.Name = "checkBoxEmail";
            checkBoxEmail.Size = new Size(140, 21);
            checkBoxEmail.TabIndex = 9;
            checkBoxEmail.Text = "Enable Email Alert";
            checkBoxEmail.UseVisualStyleBackColor = true;
            checkBoxEmail.CheckStateChanged += checkBoxEmail_CheckStateChanged;
            checkBoxEmail.Click += textBoxRows_Click;
            // 
            // textBoxStream
            // 
            textBoxStream.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            textBoxStream.Location = new Point(20, 342);
            textBoxStream.Margin = new Padding(4, 3, 4, 3);
            textBoxStream.Name = "textBoxStream";
            textBoxStream.Size = new Size(54, 25);
            textBoxStream.TabIndex = 10;
            textBoxStream.Click += textBoxRows_Click;
            textBoxStream.TextChanged += textBoxStream_TextChanged;
            textBoxStream.KeyPress += textBoxStream_KeyPress;
            // 
            // labelText3
            // 
            labelText3.AutoSize = true;
            labelText3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelText3.Location = new Point(20, 321);
            labelText3.Margin = new Padding(4, 0, 4, 0);
            labelText3.Name = "labelText3";
            labelText3.Size = new Size(228, 17);
            labelText3.TabIndex = 11;
            labelText3.Text = "Set video stream lenght in seconds.";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlText;
            panel2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            panel2.Location = new Point(13, 471);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(550, 1);
            panel2.TabIndex = 9;
            // 
            // checkBoxDrive
            // 
            checkBoxDrive.AutoSize = true;
            checkBoxDrive.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            checkBoxDrive.Location = new Point(20, 373);
            checkBoxDrive.Margin = new Padding(4, 3, 4, 3);
            checkBoxDrive.Name = "checkBoxDrive";
            checkBoxDrive.Size = new Size(111, 21);
            checkBoxDrive.TabIndex = 15;
            checkBoxDrive.Text = "Remote Drive";
            checkBoxDrive.UseVisualStyleBackColor = true;
            checkBoxDrive.CheckStateChanged += checkBoxDrive_CheckStateChanged;
            checkBoxDrive.Click += textBoxRows_Click;
            // 
            // textBoxRows
            // 
            textBoxRows.Location = new Point(20, 431);
            textBoxRows.Name = "textBoxRows";
            textBoxRows.Size = new Size(54, 22);
            textBoxRows.TabIndex = 16;
            textBoxRows.Click += textBoxRows_Click;
            textBoxRows.TextChanged += textBoxRows_TextChanged;
            textBoxRows.KeyPress += textBoxRows_KeyPress;
            // 
            // labelText5
            // 
            labelText5.AutoSize = true;
            labelText5.Location = new Point(20, 407);
            labelText5.Name = "labelText5";
            labelText5.Size = new Size(241, 16);
            labelText5.TabIndex = 17;
            labelText5.Text = "Set number of rows for log entries.";
            // 
            // labelDateModified
            // 
            labelDateModified.AutoSize = true;
            labelDateModified.Location = new Point(15, 485);
            labelDateModified.Name = "labelDateModified";
            labelDateModified.Size = new Size(50, 16);
            labelDateModified.TabIndex = 21;
            labelDateModified.Text = "label1";
            // 
            // labelText6
            // 
            labelText6.AutoSize = true;
            labelText6.Location = new Point(15, 171);
            labelText6.Name = "labelText6";
            labelText6.Size = new Size(148, 16);
            labelText6.TabIndex = 28;
            labelText6.Text = "Set active detection.";
            // 
            // checkBoxDoorSensor1
            // 
            checkBoxDoorSensor1.AutoSize = true;
            checkBoxDoorSensor1.Location = new Point(15, 205);
            checkBoxDoorSensor1.Name = "checkBoxDoorSensor1";
            checkBoxDoorSensor1.Size = new Size(109, 20);
            checkBoxDoorSensor1.TabIndex = 29;
            checkBoxDoorSensor1.Text = "Door status.";
            checkBoxDoorSensor1.UseVisualStyleBackColor = true;
            checkBoxDoorSensor1.CheckedChanged += checkBoxDoorSensor1_CheckedChanged;
            checkBoxDoorSensor1.Click += textBoxRows_Click;
            // 
            // checkBoxMotionSensor1
            // 
            checkBoxMotionSensor1.AutoSize = true;
            checkBoxMotionSensor1.Location = new Point(15, 126);
            checkBoxMotionSensor1.Name = "checkBoxMotionSensor1";
            checkBoxMotionSensor1.Size = new Size(135, 20);
            checkBoxMotionSensor1.TabIndex = 30;
            checkBoxMotionSensor1.Text = "Motion sensor 1";
            checkBoxMotionSensor1.UseVisualStyleBackColor = true;
            checkBoxMotionSensor1.CheckedChanged += checkBoxMotionSensor1_CheckedChanged;
            // 
            // checkBoxMotionSensor2
            // 
            checkBoxMotionSensor2.AutoSize = true;
            checkBoxMotionSensor2.Location = new Point(154, 126);
            checkBoxMotionSensor2.Name = "checkBoxMotionSensor2";
            checkBoxMotionSensor2.Size = new Size(135, 20);
            checkBoxMotionSensor2.TabIndex = 31;
            checkBoxMotionSensor2.Text = "Motion sensor 2";
            checkBoxMotionSensor2.UseVisualStyleBackColor = true;
            checkBoxMotionSensor2.CheckedChanged += checkBoxMotionSensor2_CheckedChanged;
            // 
            // labelText7
            // 
            labelText7.AutoSize = true;
            labelText7.Location = new Point(15, 9);
            labelText7.Name = "labelText7";
            labelText7.Size = new Size(173, 16);
            labelText7.TabIndex = 32;
            labelText7.Text = "Set active usb cameras.";
            // 
            // checkBoxUsbCamera1
            // 
            checkBoxUsbCamera1.AutoSize = true;
            checkBoxUsbCamera1.Location = new Point(15, 44);
            checkBoxUsbCamera1.Name = "checkBoxUsbCamera1";
            checkBoxUsbCamera1.Size = new Size(92, 20);
            checkBoxUsbCamera1.TabIndex = 33;
            checkBoxUsbCamera1.Text = "Camera 1";
            checkBoxUsbCamera1.UseVisualStyleBackColor = true;
            checkBoxUsbCamera1.CheckedChanged += checkBoxUsbCamera1_CheckedChanged;
            checkBoxUsbCamera1.Click += checkBoxUsbCamera1_Click;
            // 
            // checkBoxUsbCamera2
            // 
            checkBoxUsbCamera2.AutoSize = true;
            checkBoxUsbCamera2.Location = new Point(122, 44);
            checkBoxUsbCamera2.Name = "checkBoxUsbCamera2";
            checkBoxUsbCamera2.Size = new Size(92, 20);
            checkBoxUsbCamera2.TabIndex = 34;
            checkBoxUsbCamera2.Text = "Camera 2";
            checkBoxUsbCamera2.UseVisualStyleBackColor = true;
            checkBoxUsbCamera2.CheckedChanged += checkBoxUsbCamera2_CheckedChanged;
            checkBoxUsbCamera2.Click += checkBoxUsbCamera2_Click;
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new SizeF(9F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(576, 557);
            Controls.Add(checkBoxUsbCamera2);
            Controls.Add(checkBoxUsbCamera1);
            Controls.Add(labelText7);
            Controls.Add(checkBoxMotionSensor2);
            Controls.Add(checkBoxMotionSensor1);
            Controls.Add(checkBoxDoorSensor1);
            Controls.Add(labelText6);
            Controls.Add(labelDateModified);
            Controls.Add(labelText5);
            Controls.Add(textBoxRows);
            Controls.Add(checkBoxDrive);
            Controls.Add(panel2);
            Controls.Add(labelText3);
            Controls.Add(textBoxStream);
            Controls.Add(checkBoxEmail);
            Controls.Add(panel1);
            Controls.Add(labelText2);
            Controls.Add(labelText);
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
            FormClosed += FormSettings_FormClosed;
            Load += FormSettings_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonOk;
        private Button buttonCancel;
        private TextBox textBoxEmailadress;
        private Label labelText;
        private Label labelText2;
        private Panel panel1;
        private CheckBox checkBoxEmail;
        private TextBox textBoxStream;
        private Label labelText3;
        private Panel panel2;
        private FolderBrowserDialog folderBrowserDialogVideo;
        private CheckBox checkBoxDrive;
        private TextBox textBoxRows;
        private Label labelText5;
        private Label labelDateModified;
        private Label labelText6;
        private CheckBox checkBoxDoorSensor1;
        private CheckBox checkBoxMotionSensor1;
        private CheckBox checkBoxMotionSensor2;
        private Label labelText7;
        private CheckBox checkBoxUsbCamera1;
        private CheckBox checkBoxUsbCamera2;
    }
}