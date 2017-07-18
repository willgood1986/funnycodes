namespace EventlogViewer
{
	partial class Form1
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
			this.label1 = new System.Windows.Forms.Label();
			this.tbIndex = new System.Windows.Forms.TextBox();
			this.btnQuery = new System.Windows.Forms.Button();
			this.btnLoad = new System.Windows.Forms.Button();
			this.lbEventlogs = new System.Windows.Forms.ListBox();
			this.tbLog = new System.Windows.Forms.TextBox();
			this.tbServer = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnDuplicate = new System.Windows.Forms.Button();
			this.btnPrintIndex = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Index";
			// 
			// tbIndex
			// 
			this.tbIndex.Location = new System.Drawing.Point(65, 10);
			this.tbIndex.Name = "tbIndex";
			this.tbIndex.Size = new System.Drawing.Size(182, 20);
			this.tbIndex.TabIndex = 1;
			// 
			// btnQuery
			// 
			this.btnQuery.Location = new System.Drawing.Point(263, 8);
			this.btnQuery.Name = "btnQuery";
			this.btnQuery.Size = new System.Drawing.Size(108, 22);
			this.btnQuery.TabIndex = 2;
			this.btnQuery.Text = "Query";
			this.btnQuery.UseVisualStyleBackColor = true;
			this.btnQuery.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point(377, 8);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(106, 20);
			this.btnLoad.TabIndex = 3;
			this.btnLoad.Text = "Load";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// lbEventlogs
			// 
			this.lbEventlogs.ColumnWidth = 300;
			this.lbEventlogs.FormattingEnabled = true;
			this.lbEventlogs.HorizontalScrollbar = true;
			this.lbEventlogs.Location = new System.Drawing.Point(12, 132);
			this.lbEventlogs.Name = "lbEventlogs";
			this.lbEventlogs.Size = new System.Drawing.Size(856, 329);
			this.lbEventlogs.TabIndex = 4;
			// 
			// tbLog
			// 
			this.tbLog.Location = new System.Drawing.Point(65, 45);
			this.tbLog.Name = "tbLog";
			this.tbLog.Size = new System.Drawing.Size(127, 20);
			this.tbLog.TabIndex = 5;
			// 
			// tbServer
			// 
			this.tbServer.Location = new System.Drawing.Point(65, 77);
			this.tbServer.Name = "tbServer";
			this.tbServer.Size = new System.Drawing.Size(132, 20);
			this.tbServer.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 84);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Server";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 51);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(25, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Log";
			// 
			// btnDuplicate
			// 
			this.btnDuplicate.Location = new System.Drawing.Point(524, 8);
			this.btnDuplicate.Name = "btnDuplicate";
			this.btnDuplicate.Size = new System.Drawing.Size(75, 23);
			this.btnDuplicate.TabIndex = 9;
			this.btnDuplicate.Text = " Duplicate";
			this.btnDuplicate.UseVisualStyleBackColor = true;
			this.btnDuplicate.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// btnPrintIndex
			// 
			this.btnPrintIndex.Location = new System.Drawing.Point(606, 8);
			this.btnPrintIndex.Name = "btnPrintIndex";
			this.btnPrintIndex.Size = new System.Drawing.Size(137, 23);
			this.btnPrintIndex.TabIndex = 10;
			this.btnPrintIndex.Text = "Print Index";
			this.btnPrintIndex.UseVisualStyleBackColor = true;
			this.btnPrintIndex.Click += new System.EventHandler(this.btnPrintIndex_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(880, 473);
			this.Controls.Add(this.btnPrintIndex);
			this.Controls.Add(this.btnDuplicate);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbServer);
			this.Controls.Add(this.tbLog);
			this.Controls.Add(this.lbEventlogs);
			this.Controls.Add(this.btnLoad);
			this.Controls.Add(this.btnQuery);
			this.Controls.Add(this.tbIndex);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbIndex;
		private System.Windows.Forms.Button btnQuery;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.ListBox lbEventlogs;
		private System.Windows.Forms.TextBox tbLog;
		private System.Windows.Forms.TextBox tbServer;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnDuplicate;
		private System.Windows.Forms.Button btnPrintIndex;
	}
}

