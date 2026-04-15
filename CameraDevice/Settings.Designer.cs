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
            radioButtonLocal = new RadioButton();
            radioButtonGdrive = new RadioButton();
            labelText5 = new Label();
            SuspendLayout();
            // 
            // buttonOk
            // 
            buttonOk.Location = new Point(136, 406);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 23);
            buttonOk.TabIndex = 0;
            buttonOk.Text = "Ok";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(227, 406);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // textBoxEmailadress
            // 
            textBoxEmailadress.Location = new Point(22, 66);
            textBoxEmailadress.Name = "textBoxEmailadress";
            textBoxEmailadress.Size = new Size(188, 23);
            textBoxEmailadress.TabIndex = 3;
            // 
            // textBoxAlerttext
            // 
            textBoxAlerttext.Location = new Point(23, 127);
            textBoxAlerttext.Name = "textBoxAlerttext";
            textBoxAlerttext.Size = new Size(188, 23);
            textBoxAlerttext.TabIndex = 4;
            // 
            // labelText
            // 
            labelText.AutoSize = true;
            labelText.ForeColor = Color.Silver;
            labelText.Location = new Point(22, 48);
            labelText.Name = "labelText";
            labelText.Size = new Size(72, 15);
            labelText.TabIndex = 5;
            labelText.Text = "Email adress";
            // 
            // labelText2
            // 
            labelText2.AutoSize = true;
            labelText2.Location = new Point(22, 109);
            labelText2.Name = "labelText2";
            labelText2.Size = new Size(54, 15);
            labelText2.TabIndex = 6;
            labelText2.Text = "Alert text";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlText;
            panel1.Location = new Point(0, 168);
            panel1.Name = "panel1";
            panel1.Size = new Size(330, 1);
            panel1.TabIndex = 8;
            // 
            // checkBoxEmail
            // 
            checkBoxEmail.AutoSize = true;
            checkBoxEmail.Location = new Point(22, 26);
            checkBoxEmail.Name = "checkBoxEmail";
            checkBoxEmail.Size = new Size(121, 19);
            checkBoxEmail.TabIndex = 9;
            checkBoxEmail.Text = "Enable Email Alert";
            checkBoxEmail.UseVisualStyleBackColor = true;
            checkBoxEmail.Click += checkBoxEmail_Click;
            // 
            // textBoxStream
            // 
            textBoxStream.Location = new Point(19, 198);
            textBoxStream.Name = "textBoxStream";
            textBoxStream.Size = new Size(43, 23);
            textBoxStream.TabIndex = 10;
            // 
            // labelText3
            // 
            labelText3.AutoSize = true;
            labelText3.Location = new Point(19, 178);
            labelText3.Name = "labelText3";
            labelText3.Size = new Size(134, 15);
            labelText3.TabIndex = 11;
            labelText3.Text = "Set video stream lenght.";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlText;
            panel2.Location = new Point(0, 296);
            panel2.Name = "panel2";
            panel2.Size = new Size(330, 1);
            panel2.TabIndex = 9;
            // 
            // buttonFolder
            // 
            buttonFolder.Location = new Point(18, 339);
            buttonFolder.Name = "buttonFolder";
            buttonFolder.Size = new Size(75, 23);
            buttonFolder.TabIndex = 12;
            buttonFolder.Text = "Browse";
            buttonFolder.UseVisualStyleBackColor = true;
            buttonFolder.Click += buttonFolder_Click;
            // 
            // labelText4
            // 
            labelText4.AutoSize = true;
            labelText4.Location = new Point(22, 310);
            labelText4.Name = "labelText4";
            labelText4.Size = new Size(122, 15);
            labelText4.TabIndex = 13;
            labelText4.Text = "Set main video folder.";
            // 
            // labelFolder
            // 
            labelFolder.AutoSize = true;
            labelFolder.Location = new Point(22, 381);
            labelFolder.Name = "labelFolder";
            labelFolder.Size = new Size(38, 15);
            labelFolder.TabIndex = 14;
            labelFolder.Text = "label1";
            // 
            // radioButtonLocal
            // 
            radioButtonLocal.AutoSize = true;
            radioButtonLocal.Location = new Point(19, 258);
            radioButtonLocal.Name = "radioButtonLocal";
            radioButtonLocal.Size = new Size(53, 19);
            radioButtonLocal.TabIndex = 15;
            radioButtonLocal.TabStop = true;
            radioButtonLocal.Text = "Local";
            radioButtonLocal.UseVisualStyleBackColor = true;
            // 
            // radioButtonGdrive
            // 
            radioButtonGdrive.AutoSize = true;
            radioButtonGdrive.Location = new Point(136, 258);
            radioButtonGdrive.Name = "radioButtonGdrive";
            radioButtonGdrive.Size = new Size(59, 19);
            radioButtonGdrive.TabIndex = 16;
            radioButtonGdrive.TabStop = true;
            radioButtonGdrive.Text = "gDrive";
            radioButtonGdrive.UseVisualStyleBackColor = true;
            // 
            // labelText5
            // 
            labelText5.AutoSize = true;
            labelText5.Location = new Point(21, 234);
            labelText5.Name = "labelText5";
            labelText5.Size = new Size(127, 15);
            labelText5.TabIndex = 17;
            labelText5.Text = "Set location for videos.";
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(314, 445);
            Controls.Add(labelText5);
            Controls.Add(radioButtonGdrive);
            Controls.Add(radioButtonLocal);
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
        private RadioButton radioButtonLocal;
        private RadioButton radioButtonGdrive;
        private Label labelText5;
    }
}