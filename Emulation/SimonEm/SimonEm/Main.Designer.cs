using System.Drawing;
namespace SimonEm
{
	partial class Main
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.cpuGroup = new System.Windows.Forms.GroupBox();
			this.ramView = new System.Windows.Forms.DataGridView();
			this.A0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.A1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.A2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.A3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.A4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.A5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.A6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.A7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.A8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.A9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AA = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AB = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AC = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AD = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AE = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.AF = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.codeListBox = new System.Windows.Forms.ListBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.singleStepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.gameButton1 = new System.Windows.Forms.RadioButton();
			this.gameButton2 = new System.Windows.Forms.RadioButton();
			this.gameButton3 = new System.Windows.Forms.RadioButton();
			this.skillButton3 = new System.Windows.Forms.RadioButton();
			this.skillButton2 = new System.Windows.Forms.RadioButton();
			this.skillButton1 = new System.Windows.Forms.RadioButton();
			this.startButton = new System.Windows.Forms.Button();
			this.longestButton = new System.Windows.Forms.Button();
			this.lastButton = new System.Windows.Forms.Button();
			this.labGame = new System.Windows.Forms.Label();
			this.labSkillLevel = new System.Windows.Forms.Label();
			this.panelGame = new System.Windows.Forms.Panel();
			this.panelSkill = new System.Windows.Forms.Panel();
			this.skillButton4 = new System.Windows.Forms.RadioButton();
			this.simonPanel = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.ramView)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.panelGame.SuspendLayout();
			this.panelSkill.SuspendLayout();
			this.SuspendLayout();
			// 
			// cpuGroup
			// 
			this.cpuGroup.BackColor = System.Drawing.SystemColors.Control;
			this.cpuGroup.Location = new System.Drawing.Point(475, 37);
			this.cpuGroup.Name = "cpuGroup";
			this.cpuGroup.Size = new System.Drawing.Size(169, 319);
			this.cpuGroup.TabIndex = 15;
			this.cpuGroup.TabStop = false;
			this.cpuGroup.Text = "TMS1000 CPU";
			// 
			// ramView
			// 
			this.ramView.AllowUserToAddRows = false;
			this.ramView.AllowUserToDeleteRows = false;
			this.ramView.AllowUserToResizeColumns = false;
			this.ramView.AllowUserToResizeRows = false;
			this.ramView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.ramView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.ramView.CausesValidation = false;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.ramView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.ramView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ramView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.A0,
            this.A1,
            this.A2,
            this.A3,
            this.A4,
            this.A5,
            this.A6,
            this.A7,
            this.A8,
            this.A9,
            this.AA,
            this.AB,
            this.AC,
            this.AD,
            this.AE,
            this.AF});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.ramView.DefaultCellStyle = dataGridViewCellStyle2;
			this.ramView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.ramView.Location = new System.Drawing.Point(12, 362);
			this.ramView.MultiSelect = false;
			this.ramView.Name = "ramView";
			this.ramView.ReadOnly = true;
			this.ramView.RowHeadersVisible = false;
			this.ramView.RowHeadersWidth = 27;
			this.ramView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.ramView.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.ramView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.ramView.ShowCellErrors = false;
			this.ramView.ShowCellToolTips = false;
			this.ramView.ShowEditingIcon = false;
			this.ramView.ShowRowErrors = false;
			this.ramView.Size = new System.Drawing.Size(632, 127);
			this.ramView.TabIndex = 16;
			// 
			// A0
			// 
			this.A0.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.A0.HeaderText = "0";
			this.A0.Name = "A0";
			this.A0.ReadOnly = true;
			this.A0.Width = 38;
			// 
			// A1
			// 
			this.A1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.A1.HeaderText = "1";
			this.A1.Name = "A1";
			this.A1.ReadOnly = true;
			this.A1.Width = 38;
			// 
			// A2
			// 
			this.A2.HeaderText = "2";
			this.A2.Name = "A2";
			this.A2.ReadOnly = true;
			this.A2.Width = 38;
			// 
			// A3
			// 
			this.A3.HeaderText = "3";
			this.A3.Name = "A3";
			this.A3.ReadOnly = true;
			this.A3.Width = 38;
			// 
			// A4
			// 
			this.A4.HeaderText = "4";
			this.A4.Name = "A4";
			this.A4.ReadOnly = true;
			this.A4.Width = 38;
			// 
			// A5
			// 
			this.A5.HeaderText = "5";
			this.A5.Name = "A5";
			this.A5.ReadOnly = true;
			this.A5.Width = 38;
			// 
			// A6
			// 
			this.A6.HeaderText = "6";
			this.A6.Name = "A6";
			this.A6.ReadOnly = true;
			this.A6.Width = 38;
			// 
			// A7
			// 
			this.A7.HeaderText = "7";
			this.A7.Name = "A7";
			this.A7.ReadOnly = true;
			this.A7.Width = 38;
			// 
			// A8
			// 
			this.A8.HeaderText = "8";
			this.A8.Name = "A8";
			this.A8.ReadOnly = true;
			this.A8.Width = 38;
			// 
			// A9
			// 
			this.A9.HeaderText = "9";
			this.A9.Name = "A9";
			this.A9.ReadOnly = true;
			this.A9.Width = 38;
			// 
			// AA
			// 
			this.AA.HeaderText = "A";
			this.AA.Name = "AA";
			this.AA.ReadOnly = true;
			this.AA.Width = 39;
			// 
			// AB
			// 
			this.AB.HeaderText = "B";
			this.AB.Name = "AB";
			this.AB.ReadOnly = true;
			this.AB.Width = 39;
			// 
			// AC
			// 
			this.AC.HeaderText = "C";
			this.AC.Name = "AC";
			this.AC.ReadOnly = true;
			this.AC.Width = 39;
			// 
			// AD
			// 
			this.AD.HeaderText = "D";
			this.AD.Name = "AD";
			this.AD.ReadOnly = true;
			this.AD.Width = 40;
			// 
			// AE
			// 
			this.AE.HeaderText = "E";
			this.AE.Name = "AE";
			this.AE.ReadOnly = true;
			this.AE.Width = 39;
			// 
			// AF
			// 
			this.AF.HeaderText = "F";
			this.AF.Name = "AF";
			this.AF.ReadOnly = true;
			this.AF.Width = 38;
			// 
			// codeListBox
			// 
			this.codeListBox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.codeListBox.FormattingEnabled = true;
			this.codeListBox.ItemHeight = 18;
			this.codeListBox.Location = new System.Drawing.Point(660, 29);
			this.codeListBox.Name = "codeListBox";
			this.codeListBox.ScrollAlwaysVisible = true;
			this.codeListBox.Size = new System.Drawing.Size(235, 454);
			this.codeListBox.TabIndex = 17;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.gameToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(907, 24);
			this.menuStrip1.TabIndex = 18;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// gameToolStripMenuItem
			// 
			this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.singleStepToolStripMenuItem});
			this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
			this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
			this.gameToolStripMenuItem.Text = "&Game";
			// 
			// runToolStripMenuItem
			// 
			this.runToolStripMenuItem.Name = "runToolStripMenuItem";
			this.runToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.runToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.runToolStripMenuItem.Text = "Run";
			this.runToolStripMenuItem.Click += new System.EventHandler(this.RunToolStripMenuItem1Click);
			// 
			// stopToolStripMenuItem
			// 
			this.stopToolStripMenuItem.Enabled = false;
			this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
			this.stopToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F5)));
			this.stopToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.stopToolStripMenuItem.Text = "Stop";
			this.stopToolStripMenuItem.Click += new System.EventHandler(this.StopToolStripMenuItem1Click);
			// 
			// singleStepToolStripMenuItem
			// 
			this.singleStepToolStripMenuItem.Name = "singleStepToolStripMenuItem";
			this.singleStepToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
			this.singleStepToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.singleStepToolStripMenuItem.Text = "&Single Step";
			this.singleStepToolStripMenuItem.Click += new System.EventHandler(this.singleStepToolStripMenuItem_Click);
			// 
			// timer1
			// 
			this.timer1.Interval = 10;
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// gameButton1
			// 
			this.gameButton1.Checked = true;
			this.gameButton1.Location = new System.Drawing.Point(0, 0);
			this.gameButton1.Name = "gameButton1";
			this.gameButton1.Size = new System.Drawing.Size(36, 24);
			this.gameButton1.TabIndex = 19;
			this.gameButton1.TabStop = true;
			this.gameButton1.Text = "1";
			this.gameButton1.UseVisualStyleBackColor = true;
			this.gameButton1.Click += new System.EventHandler(this.GameButton1Click);
			// 
			// gameButton2
			// 
			this.gameButton2.Location = new System.Drawing.Point(29, 0);
			this.gameButton2.Name = "gameButton2";
			this.gameButton2.Size = new System.Drawing.Size(36, 24);
			this.gameButton2.TabIndex = 20;
			this.gameButton2.Text = "2";
			this.gameButton2.UseVisualStyleBackColor = true;
			this.gameButton2.Click += new System.EventHandler(this.GameButton2Click);
			// 
			// gameButton3
			// 
			this.gameButton3.Location = new System.Drawing.Point(58, 0);
			this.gameButton3.Name = "gameButton3";
			this.gameButton3.Size = new System.Drawing.Size(36, 24);
			this.gameButton3.TabIndex = 21;
			this.gameButton3.Text = "3";
			this.gameButton3.UseVisualStyleBackColor = true;
			this.gameButton3.Click += new System.EventHandler(this.GameButton3Click);
			// 
			// skillButton3
			// 
			this.skillButton3.Location = new System.Drawing.Point(58, 0);
			this.skillButton3.Name = "skillButton3";
			this.skillButton3.Size = new System.Drawing.Size(36, 24);
			this.skillButton3.TabIndex = 25;
			this.skillButton3.Text = "3";
			this.skillButton3.UseVisualStyleBackColor = true;
			this.skillButton3.Click += new System.EventHandler(this.SkillButton3Click);
			// 
			// skillButton2
			// 
			this.skillButton2.Location = new System.Drawing.Point(29, 0);
			this.skillButton2.Name = "skillButton2";
			this.skillButton2.Size = new System.Drawing.Size(36, 24);
			this.skillButton2.TabIndex = 24;
			this.skillButton2.Text = "2";
			this.skillButton2.UseVisualStyleBackColor = true;
			this.skillButton2.Click += new System.EventHandler(this.SkillButton2Click);
			// 
			// skillButton1
			// 
			this.skillButton1.Checked = true;
			this.skillButton1.Location = new System.Drawing.Point(0, 0);
			this.skillButton1.Name = "skillButton1";
			this.skillButton1.Size = new System.Drawing.Size(36, 24);
			this.skillButton1.TabIndex = 23;
			this.skillButton1.TabStop = true;
			this.skillButton1.Text = "1";
			this.skillButton1.UseVisualStyleBackColor = true;
			this.skillButton1.Click += new System.EventHandler(this.SkillButton1Click);
			// 
			// startButton
			// 
			this.startButton.Location = new System.Drawing.Point(323, 37);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(74, 21);
			this.startButton.TabIndex = 26;
			this.startButton.Text = "START";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartButtonMouseDown);
			this.startButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StartButtonMouseUp);
			// 
			// longestButton
			// 
			this.longestButton.Location = new System.Drawing.Point(323, 63);
			this.longestButton.Name = "longestButton";
			this.longestButton.Size = new System.Drawing.Size(74, 21);
			this.longestButton.TabIndex = 27;
			this.longestButton.Text = "LONGEST";
			this.longestButton.UseVisualStyleBackColor = true;
			this.longestButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LongestButtonMouseDown);
			this.longestButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LongestButtonMouseUp);
			// 
			// lastButton
			// 
			this.lastButton.Location = new System.Drawing.Point(323, 90);
			this.lastButton.Name = "lastButton";
			this.lastButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lastButton.Size = new System.Drawing.Size(74, 21);
			this.lastButton.TabIndex = 28;
			this.lastButton.Text = "LAST";
			this.lastButton.UseVisualStyleBackColor = true;
			this.lastButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LastButtonMouseDown);
			this.lastButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LastButtonMouseUp);
			// 
			// labGame
			// 
			this.labGame.Location = new System.Drawing.Point(318, 127);
			this.labGame.Name = "labGame";
			this.labGame.Size = new System.Drawing.Size(53, 18);
			this.labGame.TabIndex = 29;
			this.labGame.Text = "GAME";
			// 
			// labSkillLevel
			// 
			this.labSkillLevel.Location = new System.Drawing.Point(315, 175);
			this.labSkillLevel.Name = "labSkillLevel";
			this.labSkillLevel.Size = new System.Drawing.Size(82, 18);
			this.labSkillLevel.TabIndex = 30;
			this.labSkillLevel.Text = "SKILL LEVEL";
			// 
			// panelGame
			// 
			this.panelGame.Controls.Add(this.gameButton3);
			this.panelGame.Controls.Add(this.gameButton2);
			this.panelGame.Controls.Add(this.gameButton1);
			this.panelGame.Location = new System.Drawing.Point(323, 140);
			this.panelGame.Name = "panelGame";
			this.panelGame.Size = new System.Drawing.Size(94, 22);
			this.panelGame.TabIndex = 31;
			// 
			// panelSkill
			// 
			this.panelSkill.Controls.Add(this.skillButton4);
			this.panelSkill.Controls.Add(this.skillButton3);
			this.panelSkill.Controls.Add(this.skillButton2);
			this.panelSkill.Controls.Add(this.skillButton1);
			this.panelSkill.Location = new System.Drawing.Point(323, 190);
			this.panelSkill.Name = "panelSkill";
			this.panelSkill.Size = new System.Drawing.Size(119, 22);
			this.panelSkill.TabIndex = 32;
			// 
			// skillButton4
			// 
			this.skillButton4.Location = new System.Drawing.Point(87, 0);
			this.skillButton4.Name = "skillButton4";
			this.skillButton4.Size = new System.Drawing.Size(36, 24);
			this.skillButton4.TabIndex = 26;
			this.skillButton4.Text = "4";
			this.skillButton4.UseVisualStyleBackColor = true;
			this.skillButton4.Click += new System.EventHandler(this.SkillButton4Click);
			// 
			// simonPanel
			// 
			this.simonPanel.BackColor = SystemColors.Control;
			this.simonPanel.Location = new System.Drawing.Point(12, 36);
			this.simonPanel.Name = "simonPanel";
			this.simonPanel.Size = new System.Drawing.Size(300, 300);
			this.simonPanel.TabIndex = 33;
			this.simonPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.simonPanelPaint);
			this.simonPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.simonPanel_MouseDown);
			this.simonPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.simonPanel_MouseUp);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(907, 503);
			this.Controls.Add(this.simonPanel);
			this.Controls.Add(this.panelSkill);
			this.Controls.Add(this.panelGame);
			this.Controls.Add(this.labSkillLevel);
			this.Controls.Add(this.labGame);
			this.Controls.Add(this.lastButton);
			this.Controls.Add(this.longestButton);
			this.Controls.Add(this.startButton);
			this.Controls.Add(this.codeListBox);
			this.Controls.Add(this.ramView);
			this.Controls.Add(this.cpuGroup);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Main";
			this.Text = "Simon";
			((System.ComponentModel.ISupportInitialize)(this.ramView)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.panelGame.ResumeLayout(false);
			this.panelSkill.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button longestButton;
		private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
		private System.Windows.Forms.GroupBox cpuGroup;
		private System.Windows.Forms.DataGridView ramView;
		private System.Windows.Forms.DataGridViewTextBoxColumn A0;
		private System.Windows.Forms.DataGridViewTextBoxColumn A1;
		private System.Windows.Forms.DataGridViewTextBoxColumn A2;
		private System.Windows.Forms.DataGridViewTextBoxColumn A3;
		private System.Windows.Forms.DataGridViewTextBoxColumn A4;
		private System.Windows.Forms.DataGridViewTextBoxColumn A5;
		private System.Windows.Forms.DataGridViewTextBoxColumn A6;
		private System.Windows.Forms.DataGridViewTextBoxColumn A7;
		private System.Windows.Forms.DataGridViewTextBoxColumn A8;
		private System.Windows.Forms.DataGridViewTextBoxColumn A9;
		private System.Windows.Forms.DataGridViewTextBoxColumn AA;
		private System.Windows.Forms.DataGridViewTextBoxColumn AB;
		private System.Windows.Forms.DataGridViewTextBoxColumn AC;
		private System.Windows.Forms.DataGridViewTextBoxColumn AD;
		private System.Windows.Forms.DataGridViewTextBoxColumn AE;
		private System.Windows.Forms.DataGridViewTextBoxColumn AF;
		private System.Windows.Forms.ListBox codeListBox;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem emulatorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem singleStepToolStripMenuItem;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
		private System.Windows.Forms.RadioButton skillButton3;
		private System.Windows.Forms.RadioButton skillButton2;
		private System.Windows.Forms.RadioButton skillButton1;
		private System.Windows.Forms.RadioButton gameButton1;
		private System.Windows.Forms.RadioButton gameButton2;
		private System.Windows.Forms.RadioButton gameButton3;
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.Button lastButton;
		private System.Windows.Forms.Label labGame;
		private System.Windows.Forms.Label labSkillLevel;
		private System.Windows.Forms.Panel panelGame;
		private System.Windows.Forms.Panel panelSkill;
		private System.Windows.Forms.RadioButton skillButton4;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.Panel simonPanel;
	}
}


