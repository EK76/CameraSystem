namespace CameraDevice
{
    partial class FormAbout
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
            labelText = new Label();
            labelText2 = new Label();
            labelText3 = new Label();
            SuspendLayout();
            // 
            // buttonClose
            // 
            buttonClose.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            buttonClose.Location = new Point(190, 121);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(75, 23);
            buttonClose.TabIndex = 0;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // labelText
            // 
            labelText.AutoSize = true;
            labelText.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelText.Location = new Point(25, 21);
            labelText.Name = "labelText";
            labelText.Size = new Size(170, 17);
            labelText.TabIndex = 1;
            labelText.Text = "Camera Device version 1.3";
            // 
            // labelText2
            // 
            labelText2.AutoSize = true;
            labelText2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelText2.Location = new Point(25, 62);
            labelText2.Name = "labelText2";
            labelText2.Size = new Size(225, 17);
            labelText2.TabIndex = 2;
            labelText2.Text = "Ken Ekholm, ken.ekholm@live.com";
            // 
            // labelText3
            // 
            labelText3.AutoSize = true;
            labelText3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelText3.Location = new Point(25, 102);
            labelText3.Name = "labelText3";
            labelText3.Size = new Size(126, 17);
            labelText3.TabIndex = 3;
            labelText3.Text = "All rights reserved.";
            // 
            // FormAbout
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(283, 157);
            Controls.Add(labelText3);
            Controls.Add(labelText2);
            Controls.Add(labelText);
            Controls.Add(buttonClose);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormAbout";
            ShowIcon = false;
            Text = "Camera Device";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonClose;
        private Label labelText;
        private Label labelText2;
        private Label labelText3;
    }
}