namespace CameraDevice
{
    partial class FormConfirm
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
            textBoxConfirm = new TextBox();
            buttonYes = new Button();
            buttonNo = new Button();
            labelText = new Label();
            labelText2 = new Label();
            SuspendLayout();
            // 
            // textBoxConfirm
            // 
            textBoxConfirm.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            textBoxConfirm.Location = new Point(186, 66);
            textBoxConfirm.Name = "textBoxConfirm";
            textBoxConfirm.Size = new Size(91, 25);
            textBoxConfirm.TabIndex = 0;
            textBoxConfirm.TextChanged += textBoxConfirm_TextChanged;
            // 
            // buttonYes
            // 
            buttonYes.Enabled = false;
            buttonYes.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            buttonYes.Location = new Point(107, 112);
            buttonYes.Name = "buttonYes";
            buttonYes.Size = new Size(75, 23);
            buttonYes.TabIndex = 1;
            buttonYes.Text = "Yes";
            buttonYes.UseVisualStyleBackColor = true;
            buttonYes.Click += buttonYes_Click;
            // 
            // buttonNo
            // 
            buttonNo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            buttonNo.Location = new Point(201, 112);
            buttonNo.Name = "buttonNo";
            buttonNo.Size = new Size(75, 23);
            buttonNo.TabIndex = 2;
            buttonNo.Text = "No";
            buttonNo.UseVisualStyleBackColor = true;
            buttonNo.Click += buttonNo_Click;
            // 
            // labelText
            // 
            labelText.AutoSize = true;
            labelText.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelText.Location = new Point(12, 27);
            labelText.Name = "labelText";
            labelText.Size = new Size(216, 17);
            labelText.TabIndex = 3;
            labelText.Text = "Are you sure to empty Logs data?";
            // 
            // labelText2
            // 
            labelText2.AutoSize = true;
            labelText2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            labelText2.Location = new Point(12, 74);
            labelText2.Name = "labelText2";
            labelText2.Size = new Size(176, 17);
            labelText2.TabIndex = 4;
            labelText2.Text = "Write 'confirm' to proceed.";
            // 
            // FormConfirm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(288, 147);
            Controls.Add(labelText2);
            Controls.Add(labelText);
            Controls.Add(buttonNo);
            Controls.Add(buttonYes);
            Controls.Add(textBoxConfirm);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormConfirm";
            ShowIcon = false;
            Text = "Camera Device";
            Load += Confirm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxConfirm;
        private Button buttonYes;
        private Button buttonNo;
        private Label labelText;
        private Label labelText2;
    }
}