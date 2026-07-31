namespace CameraDevice
{
    partial class FormVideoFolders
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
            buttonDelete = new Button();
            listBoxVideoFolders = new ListBox();
            labelText = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabelNumbers = new ToolStripStatusLabel();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(290, 773);
            buttonClose.Margin = new Padding(4);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(96, 31);
            buttonClose.TabIndex = 0;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(175, 772);
            buttonDelete.Margin = new Padding(4);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(96, 31);
            buttonDelete.TabIndex = 1;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // listBoxVideoFolders
            // 
            listBoxVideoFolders.FormattingEnabled = true;
            listBoxVideoFolders.Location = new Point(6, 47);
            listBoxVideoFolders.Margin = new Padding(4);
            listBoxVideoFolders.Name = "listBoxVideoFolders";
            listBoxVideoFolders.SelectionMode = SelectionMode.MultiSimple;
            listBoxVideoFolders.Size = new Size(392, 704);
            listBoxVideoFolders.TabIndex = 2;
            // 
            // labelText
            // 
            labelText.AutoSize = true;
            labelText.Location = new Point(9, 12);
            labelText.Margin = new Padding(4, 0, 4, 0);
            labelText.Name = "labelText";
            labelText.Size = new Size(42, 20);
            labelText.TabIndex = 3;
            labelText.Text = "label";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelNumbers });
            statusStrip1.Location = new Point(0, 812);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(411, 22);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelNumbers
            // 
            toolStripStatusLabelNumbers.Name = "toolStripStatusLabelNumbers";
            toolStripStatusLabelNumbers.Size = new Size(118, 17);
            toolStripStatusLabelNumbers.Text = "toolStripStatusLabel1";
            // 
            // FormVideoFolders
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(411, 834);
            Controls.Add(statusStrip1);
            Controls.Add(labelText);
            Controls.Add(listBoxVideoFolders);
            Controls.Add(buttonDelete);
            Controls.Add(buttonClose);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormVideoFolders";
            ShowIcon = false;
            Text = "Camera Device";
            Load += VideoFolders_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonClose;
        private Button buttonDelete;
        private ListBox listBoxVideoFolders;
        private Label labelText;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabelNumbers;
    }
}