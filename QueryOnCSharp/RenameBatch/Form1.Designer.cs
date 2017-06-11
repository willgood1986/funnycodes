namespace RainyTool.WinForm
{
    partial class MainForm
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tbFolder = new System.Windows.Forms.TextBox();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.btnListFiles = new System.Windows.Forms.Button();
            this.fileBox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.progress = new System.Diagnostics.Process();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMatchPattern = new System.Windows.Forms.TextBox();
            this.tbReplacePattern = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbContinue = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFileExtension = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(612, 12);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Browse ...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tbFolder
            // 
            this.tbFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFolder.Location = new System.Drawing.Point(12, 12);
            this.tbFolder.Name = "tbFolder";
            this.tbFolder.Size = new System.Drawing.Size(582, 20);
            this.tbFolder.TabIndex = 1;
            this.tbFolder.TextChanged += new System.EventHandler(this.tbFolder_TextChanged);
            // 
            // folderBrowser
            // 
            this.folderBrowser.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // btnListFiles
            // 
            this.btnListFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnListFiles.Location = new System.Drawing.Point(694, 12);
            this.btnListFiles.Name = "btnListFiles";
            this.btnListFiles.Size = new System.Drawing.Size(75, 23);
            this.btnListFiles.TabIndex = 2;
            this.btnListFiles.Text = "List Files";
            this.btnListFiles.UseVisualStyleBackColor = true;
            this.btnListFiles.Click += new System.EventHandler(this.btnListFiles_Click);
            // 
            // fileBox
            // 
            this.fileBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileBox.FormattingEnabled = true;
            this.fileBox.Location = new System.Drawing.Point(12, 38);
            this.fileBox.Name = "fileBox";
            this.fileBox.Size = new System.Drawing.Size(582, 420);
            this.fileBox.TabIndex = 3;
            this.fileBox.SelectedIndexChanged += new System.EventHandler(this.fileBox_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(612, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Replace";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(612, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Batch Rename";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // progress
            // 
            this.progress.StartInfo.Domain = "";
            this.progress.StartInfo.LoadUserProfile = false;
            this.progress.StartInfo.Password = null;
            this.progress.StartInfo.StandardErrorEncoding = null;
            this.progress.StartInfo.StandardOutputEncoding = null;
            this.progress.StartInfo.UserName = "";
            this.progress.SynchronizingObject = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(610, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Match Pattern:";
            // 
            // tbMatchPattern
            // 
            this.tbMatchPattern.Location = new System.Drawing.Point(610, 163);
            this.tbMatchPattern.Name = "tbMatchPattern";
            this.tbMatchPattern.Size = new System.Drawing.Size(157, 20);
            this.tbMatchPattern.TabIndex = 7;
            this.tbMatchPattern.Tag = "";
            this.tbMatchPattern.Text = "^(\\d{3}).{0,}\\.mp3$";
            // 
            // tbReplacePattern
            // 
            this.tbReplacePattern.Location = new System.Drawing.Point(610, 217);
            this.tbReplacePattern.Name = "tbReplacePattern";
            this.tbReplacePattern.Size = new System.Drawing.Size(157, 20);
            this.tbReplacePattern.TabIndex = 8;
            this.tbReplacePattern.Text = "$1.mp3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(610, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Replace Pattern";
            // 
            // cbContinue
            // 
            this.cbContinue.AutoSize = true;
            this.cbContinue.Checked = true;
            this.cbContinue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbContinue.Location = new System.Drawing.Point(613, 257);
            this.cbContinue.Name = "cbContinue";
            this.cbContinue.Size = new System.Drawing.Size(104, 17);
            this.cbContinue.TabIndex = 9;
            this.cbContinue.Text = "Continue if failed";
            this.cbContinue.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(613, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "File extention:";
            // 
            // tbFileExtension
            // 
            this.tbFileExtension.Location = new System.Drawing.Point(613, 118);
            this.tbFileExtension.Name = "tbFileExtension";
            this.tbFileExtension.Size = new System.Drawing.Size(154, 20);
            this.tbFileExtension.TabIndex = 11;
            this.tbFileExtension.Text = ".mp3";
            this.tbFileExtension.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 470);
            this.Controls.Add(this.tbFileExtension);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbContinue);
            this.Controls.Add(this.tbReplacePattern);
            this.Controls.Add(this.tbMatchPattern);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fileBox);
            this.Controls.Add(this.btnListFiles);
            this.Controls.Add(this.tbFolder);
            this.Controls.Add(this.btnBrowse);
            this.Name = "MainForm";
            this.Text = "Batch Rename File";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox tbFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Button btnListFiles;
        private System.Windows.Forms.ListBox fileBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Diagnostics.Process progress;
        private System.Windows.Forms.TextBox tbReplacePattern;
        private System.Windows.Forms.TextBox tbMatchPattern;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbContinue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFileExtension;
    }
}

