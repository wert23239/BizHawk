namespace BizHawk.Client.EmuHawk
{
	partial class ModernForm
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.LoadCurrentButton = new System.Windows.Forms.Button();
            this.RestartButton = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.rightmostLabel = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.roundsLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.noveltyLabel = new System.Windows.Forms.Label();
            this.noveltyConstant = new System.Windows.Forms.Label();
            this.trackBar5 = new System.Windows.Forms.TrackBar();
            this.rightmostValLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.noveltyConstVal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.closeApplication = new System.Windows.Forms.Label();
            this.minimizeApplication = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.rightmostTab = new System.Windows.Forms.TabPage();
            this.noveltyTab = new System.Windows.Forms.TabPage();
            this.scoreTab = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.Color.White;
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Show Map",
            "Show Mutate"});
            this.checkedListBox1.Location = new System.Drawing.Point(56, 369);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(98, 75);
            this.checkedListBox1.TabIndex = 1;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.Black;
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Location = new System.Drawing.Point(438, 441);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(76, 25);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            // 
            // LoadButton
            // 
            this.LoadButton.BackColor = System.Drawing.Color.Black;
            this.LoadButton.ForeColor = System.Drawing.Color.White;
            this.LoadButton.Location = new System.Drawing.Point(575, 441);
            this.LoadButton.Margin = new System.Windows.Forms.Padding(2);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(76, 25);
            this.LoadButton.TabIndex = 3;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = false;
            // 
            // LoadCurrentButton
            // 
            this.LoadCurrentButton.BackColor = System.Drawing.Color.Black;
            this.LoadCurrentButton.ForeColor = System.Drawing.Color.White;
            this.LoadCurrentButton.Location = new System.Drawing.Point(708, 441);
            this.LoadCurrentButton.Margin = new System.Windows.Forms.Padding(2);
            this.LoadCurrentButton.Name = "LoadCurrentButton";
            this.LoadCurrentButton.Size = new System.Drawing.Size(76, 25);
            this.LoadCurrentButton.TabIndex = 4;
            this.LoadCurrentButton.Text = "Load Current";
            this.LoadCurrentButton.UseVisualStyleBackColor = false;
            // 
            // RestartButton
            // 
            this.RestartButton.BackColor = System.Drawing.Color.Black;
            this.RestartButton.ForeColor = System.Drawing.Color.White;
            this.RestartButton.Location = new System.Drawing.Point(308, 441);
            this.RestartButton.Margin = new System.Windows.Forms.Padding(2);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(76, 25);
            this.RestartButton.TabIndex = 5;
            this.RestartButton.Text = "Restart";
            this.RestartButton.UseVisualStyleBackColor = false;
            this.RestartButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.SystemColors.Window;
            this.trackBar1.Location = new System.Drawing.Point(52, 84);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar1.Maximum = 5;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(132, 45);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(52, 261);
            this.trackBar2.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar2.Maximum = 1;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(132, 45);
            this.trackBar2.TabIndex = 7;
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(52, 198);
            this.trackBar3.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar3.Maximum = 1;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(132, 45);
            this.trackBar3.TabIndex = 8;
            // 
            // trackBar4
            // 
            this.trackBar4.Location = new System.Drawing.Point(52, 144);
            this.trackBar4.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar4.Maximum = 1;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(132, 45);
            this.trackBar4.TabIndex = 9;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(606, 216);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(71, 15);
            this.textBox3.TabIndex = 12;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rightmostLabel
            // 
            this.rightmostLabel.AutoSize = true;
            this.rightmostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightmostLabel.Location = new System.Drawing.Point(92, 67);
            this.rightmostLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rightmostLabel.Name = "rightmostLabel";
            this.rightmostLabel.Size = new System.Drawing.Size(71, 17);
            this.rightmostLabel.TabIndex = 14;
            this.rightmostLabel.Text = "Rightmost";
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(606, 162);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(71, 13);
            this.textBox2.TabIndex = 11;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // roundsLabel
            // 
            this.roundsLabel.AutoSize = true;
            this.roundsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundsLabel.Location = new System.Drawing.Point(65, 237);
            this.roundsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.roundsLabel.Name = "roundsLabel";
            this.roundsLabel.Size = new System.Drawing.Size(127, 17);
            this.roundsLabel.TabIndex = 15;
            this.roundsLabel.Text = "Number of Rounds";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(100, 181);
            this.scoreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(45, 17);
            this.scoreLabel.TabIndex = 16;
            this.scoreLabel.Text = "Score";
            // 
            // noveltyLabel
            // 
            this.noveltyLabel.AutoSize = true;
            this.noveltyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noveltyLabel.Location = new System.Drawing.Point(99, 129);
            this.noveltyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.noveltyLabel.Name = "noveltyLabel";
            this.noveltyLabel.Size = new System.Drawing.Size(55, 17);
            this.noveltyLabel.TabIndex = 17;
            this.noveltyLabel.Text = "Novelty";
            // 
            // noveltyConstant
            // 
            this.noveltyConstant.AutoSize = true;
            this.noveltyConstant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noveltyConstant.Location = new System.Drawing.Point(65, 299);
            this.noveltyConstant.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.noveltyConstant.Name = "noveltyConstant";
            this.noveltyConstant.Size = new System.Drawing.Size(115, 17);
            this.noveltyConstant.TabIndex = 19;
            this.noveltyConstant.Text = "Novelty Constant";
            this.noveltyConstant.Click += new System.EventHandler(this.noveltyConstant_Click);
            // 
            // trackBar5
            // 
            this.trackBar5.Location = new System.Drawing.Point(52, 322);
            this.trackBar5.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar5.Maximum = 1;
            this.trackBar5.Name = "trackBar5";
            this.trackBar5.Size = new System.Drawing.Size(132, 45);
            this.trackBar5.TabIndex = 18;
            // 
            // rightmostValLabel
            // 
            this.rightmostValLabel.AutoSize = true;
            this.rightmostValLabel.Location = new System.Drawing.Point(212, 84);
            this.rightmostValLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rightmostValLabel.Name = "rightmostValLabel";
            this.rightmostValLabel.Size = new System.Drawing.Size(13, 13);
            this.rightmostValLabel.TabIndex = 20;
            this.rightmostValLabel.Text = "0";
            this.rightmostValLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 199);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 144);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "0";
            // 
            // noveltyConstVal
            // 
            this.noveltyConstVal.AutoSize = true;
            this.noveltyConstVal.Location = new System.Drawing.Point(212, 322);
            this.noveltyConstVal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.noveltyConstVal.Name = "noveltyConstVal";
            this.noveltyConstVal.Size = new System.Drawing.Size(13, 13);
            this.noveltyConstVal.TabIndex = 23;
            this.noveltyConstVal.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 261);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "0";
            // 
            // closeApplication
            // 
            this.closeApplication.AutoSize = true;
            this.closeApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeApplication.Location = new System.Drawing.Point(840, 9);
            this.closeApplication.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.closeApplication.Name = "closeApplication";
            this.closeApplication.Size = new System.Drawing.Size(24, 24);
            this.closeApplication.TabIndex = 25;
            this.closeApplication.Text = "X";
            this.closeApplication.Click += new System.EventHandler(this.closeApplication_Click);
            // 
            // minimizeApplication
            // 
            this.minimizeApplication.AutoSize = true;
            this.minimizeApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeApplication.Location = new System.Drawing.Point(805, 2);
            this.minimizeApplication.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.minimizeApplication.Name = "minimizeApplication";
            this.minimizeApplication.Size = new System.Drawing.Size(23, 31);
            this.minimizeApplication.TabIndex = 26;
            this.minimizeApplication.Text = "-";
            this.minimizeApplication.Click += new System.EventHandler(this.minimizeApplication_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.rightmostTab);
            this.tabControl1.Controls.Add(this.noveltyTab);
            this.tabControl1.Controls.Add(this.scoreTab);
            this.tabControl1.Location = new System.Drawing.Point(304, 51);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(484, 359);
            this.tabControl1.TabIndex = 27;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // rightmostTab
            // 
            this.rightmostTab.Location = new System.Drawing.Point(4, 22);
            this.rightmostTab.Name = "rightmostTab";
            this.rightmostTab.Padding = new System.Windows.Forms.Padding(3);
            this.rightmostTab.Size = new System.Drawing.Size(476, 333);
            this.rightmostTab.TabIndex = 0;
            this.rightmostTab.Text = "Rightmost";
            this.rightmostTab.UseVisualStyleBackColor = true;
            this.rightmostTab.Click += new System.EventHandler(this.rightmostTab_Click);
            // 
            // noveltyTab
            // 
            this.noveltyTab.Location = new System.Drawing.Point(4, 22);
            this.noveltyTab.Name = "noveltyTab";
            this.noveltyTab.Padding = new System.Windows.Forms.Padding(3);
            this.noveltyTab.Size = new System.Drawing.Size(476, 333);
            this.noveltyTab.TabIndex = 1;
            this.noveltyTab.Text = "Novelty";
            this.noveltyTab.UseVisualStyleBackColor = true;
            this.noveltyTab.Click += new System.EventHandler(this.noveltyTab_Click);
            // 
            // scoreTab
            // 
            this.scoreTab.Location = new System.Drawing.Point(4, 22);
            this.scoreTab.Name = "scoreTab";
            this.scoreTab.Padding = new System.Windows.Forms.Padding(3);
            this.scoreTab.Size = new System.Drawing.Size(476, 333);
            this.scoreTab.TabIndex = 2;
            this.scoreTab.Text = "Score";
            this.scoreTab.UseVisualStyleBackColor = true;
            this.scoreTab.Click += new System.EventHandler(this.scoreTab_Click);
            // 
            // ModernForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(875, 495);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.minimizeApplication);
            this.Controls.Add(this.closeApplication);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.noveltyConstVal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rightmostValLabel);
            this.Controls.Add(this.noveltyConstant);
            this.Controls.Add(this.trackBar5);
            this.Controls.Add(this.noveltyLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.roundsLabel);
            this.Controls.Add(this.rightmostLabel);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.trackBar4);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.RestartButton);
            this.Controls.Add(this.LoadCurrentButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.checkedListBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ModernForm";
            this.Text = "ModernForm";
            this.Load += new System.EventHandler(this.ModernForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckedListBox checkedListBox1;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button LoadButton;
		private System.Windows.Forms.Button LoadCurrentButton;
		private System.Windows.Forms.Button RestartButton;
		public System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.TrackBar trackBar2;
		private System.Windows.Forms.TrackBar trackBar3;
		private System.Windows.Forms.TrackBar trackBar4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label rightmostLabel;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label roundsLabel;
		private System.Windows.Forms.Label scoreLabel;
		private System.Windows.Forms.Label noveltyLabel;
		private System.Windows.Forms.Label noveltyConstant;
		private System.Windows.Forms.TrackBar trackBar5;
		private System.Windows.Forms.Label rightmostValLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label noveltyConstVal;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label closeApplication;
		private System.Windows.Forms.Label minimizeApplication;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage rightmostTab;
		private System.Windows.Forms.TabPage noveltyTab;
		private System.Windows.Forms.TabPage scoreTab;
	}
}