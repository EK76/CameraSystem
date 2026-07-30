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
            radioButtonSensor1 = new RadioButton();
            radioButtonSensor2 = new RadioButton();
            radioButtonBothSensors = new RadioButton();
            labelDateModified = new Label();
            radioButtonNoneSensors = new RadioButton();
            radioButtonDetect1 = new RadioButton();
            radioButtonNoneDetection = new RadioButton();
            panelDetection = new Panel();
            panelMotion = new Panel();
            labelText6 = new Label();
            panelDetection.SuspendLayout();
            panelMotion.SuspendLayout();
            SuspendLayout();
            // 
            // buttonOk
            // 
            buttonOk.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            buttonOk.Location = new Point(350, 458);
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
            buttonCancel.Location = new Point(467, 458);
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
            textBoxEmailadress.Location = new Point(24, 54);
            textBoxEmailadress.Margin = new Padding(4, 3, 4, 3);
            textBoxEmailadress.Name = "textBoxEmailadress";
            textBoxEmailadress.Size = new Size(241, 25);
            textBoxEmailadress.TabIndex = 3;
            textBoxEmailadress.TextChanged += textBoxEmailadress_TextChanged;
            // 
            // labelText
            // 
            labelText.AutoSize = true;
            labelText.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelText.ForeColor = Color.Black;
            labelText.Location = new Point(24, 35);
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
            labelText2.Location = new Point(24, 91);
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
            panel1.Location = new Point(3, 255);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(475, 1);
            panel1.TabIndex = 8;
            // 
            // checkBoxEmail
            // 
            checkBoxEmail.AutoSize = true;
            checkBoxEmail.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            checkBoxEmail.Location = new Point(24, 12);
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
            textBoxStream.Location = new Point(27, 287);
            textBoxStream.Margin = new Padding(4, 3, 4, 3);
            textBoxStream.Name = "textBoxStream";
            textBoxStream.Size = new Size(54, 25);
            textBoxStream.TabIndex = 10;
            textBoxStream.TextChanged += textBoxStream_TextChanged;
            textBoxStream.KeyPress += textBoxStream_KeyPress;
            // 
            // labelText3
            // 
            labelText3.AutoSize = true;
            labelText3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelText3.Location = new Point(27, 266);
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
            panel2.Location = new Point(3, 416);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(475, 1);
            panel2.TabIndex = 9;
            // 
            // checkBoxDrive
            // 
            checkBoxDrive.AutoSize = true;
            checkBoxDrive.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            checkBoxDrive.Location = new Point(27, 318);
            checkBoxDrive.Margin = new Padding(4, 3, 4, 3);
            checkBoxDrive.Name = "checkBoxDrive";
            checkBoxDrive.Size = new Size(111, 21);
            checkBoxDrive.TabIndex = 15;
            checkBoxDrive.Text = "Remote Drive";
            checkBoxDrive.UseVisualStyleBackColor = true;
            checkBoxDrive.Click += checkBoxDrive_Click;
            // 
            // textBoxRows
            // 
            textBoxRows.Location = new Point(27, 376);
            textBoxRows.Name = "textBoxRows";
            textBoxRows.Size = new Size(54, 22);
            textBoxRows.TabIndex = 16;
            textBoxRows.TextChanged += textBoxRows_TextChanged;
            textBoxRows.KeyPress += textBoxRows_KeyPress;
            // 
            // labelText5
            // 
            labelText5.AutoSize = true;
            labelText5.Location = new Point(27, 352);
            labelText5.Name = "labelText5";
            labelText5.Size = new Size(241, 16);
            labelText5.TabIndex = 17;
            labelText5.Text = "Set number of rows for log entries.";
            // 
            // radioButtonSensor1
            // 
            radioButtonSensor1.AutoSize = true;
            radioButtonSensor1.Location = new Point(12, 16);
            radioButtonSensor1.Name = "radioButtonSensor1";
            radioButtonSensor1.Size = new Size(138, 20);
            radioButtonSensor1.TabIndex = 18;
            radioButtonSensor1.TabStop = true;
            radioButtonSensor1.Text = "Motion sensor 1.";
            radioButtonSensor1.UseVisualStyleBackColor = true;
            radioButtonSensor1.Click += radioButtonSensor1_Click;
            // 
            // radioButtonSensor2
            // 
            radioButtonSensor2.AutoSize = true;
            radioButtonSensor2.Location = new Point(157, 16);
            radioButtonSensor2.Name = "radioButtonSensor2";
            radioButtonSensor2.Size = new Size(138, 20);
            radioButtonSensor2.TabIndex = 19;
            radioButtonSensor2.TabStop = true;
            radioButtonSensor2.Text = "Motion sensor 2.";
            radioButtonSensor2.UseVisualStyleBackColor = true;
            radioButtonSensor2.Click += radioButtonSensor2_Click;
            // 
            // radioButtonBothSensors
            // 
            radioButtonBothSensors.AutoSize = true;
            radioButtonBothSensors.Location = new Point(299, 16);
            radioButtonBothSensors.Name = "radioButtonBothSensors";
            radioButtonBothSensors.Size = new Size(119, 20);
            radioButtonBothSensors.TabIndex = 20;
            radioButtonBothSensors.TabStop = true;
            radioButtonBothSensors.Text = "Both sensors.";
            radioButtonBothSensors.UseVisualStyleBackColor = true;
            radioButtonBothSensors.Click += radioButtonBothSensors_Click;
            // 
            // labelDateModified
            // 
            labelDateModified.AutoSize = true;
            labelDateModified.Location = new Point(25, 423);
            labelDateModified.Name = "labelDateModified";
            labelDateModified.Size = new Size(50, 16);
            labelDateModified.TabIndex = 21;
            labelDateModified.Text = "label1";
            // 
            // radioButtonNoneSensors
            // 
            radioButtonNoneSensors.AutoSize = true;
            radioButtonNoneSensors.Location = new Point(424, 16);
            radioButtonNoneSensors.Name = "radioButtonNoneSensors";
            radioButtonNoneSensors.Size = new Size(115, 20);
            radioButtonNoneSensors.TabIndex = 23;
            radioButtonNoneSensors.TabStop = true;
            radioButtonNoneSensors.Text = "None Sensor";
            radioButtonNoneSensors.UseVisualStyleBackColor = true;
            radioButtonNoneSensors.CheckedChanged += radioButtonNoneSensors_CheckedChanged;
            radioButtonNoneSensors.Click += radioButtonNoneSensors_Click;
            // 
            // radioButtonDetect1
            // 
            radioButtonDetect1.AutoSize = true;
            radioButtonDetect1.Location = new Point(15, 11);
            radioButtonDetect1.Name = "radioButtonDetect1";
            radioButtonDetect1.Size = new Size(130, 20);
            radioButtonDetect1.TabIndex = 24;
            radioButtonDetect1.TabStop = true;
            radioButtonDetect1.Text = "Open detection";
            radioButtonDetect1.UseVisualStyleBackColor = true;
            radioButtonDetect1.Click += radioButtonDetect1_Click;
            // 
            // radioButtonNoneDetection
            // 
            radioButtonNoneDetection.AutoSize = true;
            radioButtonNoneDetection.Location = new Point(160, 11);
            radioButtonNoneDetection.Name = "radioButtonNoneDetection";
            radioButtonNoneDetection.Size = new Size(134, 20);
            radioButtonNoneDetection.TabIndex = 25;
            radioButtonNoneDetection.TabStop = true;
            radioButtonNoneDetection.Text = "None detection.";
            radioButtonNoneDetection.UseVisualStyleBackColor = true;
            radioButtonNoneDetection.CheckedChanged += radioButtonNoneDetection_CheckedChanged;
            radioButtonNoneDetection.Click += radioButtonNoneDetection_Click;
            // 
            // panelDetection
            // 
            panelDetection.Controls.Add(radioButtonNoneDetection);
            panelDetection.Controls.Add(radioButtonDetect1);
            panelDetection.Location = new Point(12, 202);
            panelDetection.Name = "panelDetection";
            panelDetection.Size = new Size(552, 34);
            panelDetection.TabIndex = 26;
            // 
            // panelMotion
            // 
            panelMotion.Controls.Add(radioButtonSensor1);
            panelMotion.Controls.Add(radioButtonSensor2);
            panelMotion.Controls.Add(radioButtonNoneSensors);
            panelMotion.Controls.Add(radioButtonBothSensors);
            panelMotion.Location = new Point(12, 118);
            panelMotion.Name = "panelMotion";
            panelMotion.Size = new Size(552, 39);
            panelMotion.TabIndex = 27;
            // 
            // labelText6
            // 
            labelText6.AutoSize = true;
            labelText6.Location = new Point(20, 171);
            labelText6.Name = "labelText6";
            labelText6.Size = new Size(148, 16);
            labelText6.TabIndex = 28;
            labelText6.Text = "Set active detection.";
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new SizeF(9F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(576, 495);
            Controls.Add(labelText6);
            Controls.Add(panelMotion);
            Controls.Add(panelDetection);
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
            Load += FormSettings_Load;
            panelDetection.ResumeLayout(false);
            panelDetection.PerformLayout();
            panelMotion.ResumeLayout(false);
            panelMotion.PerformLayout();
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
        private RadioButton radioButtonSensor1;
        private RadioButton radioButtonSensor2;
        private RadioButton radioButtonBothSensors;
        private Label labelDateModified;
        private RadioButton radioButtonNoneSensors;
        private RadioButton radioButtonDetect1;
        private RadioButton radioButtonNoneDetection;
        private Panel panelDetection;
        private Panel panelMotion;
        private Label labelText6;
    }
}