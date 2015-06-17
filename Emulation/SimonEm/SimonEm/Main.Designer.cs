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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.redPanel = new System.Windows.Forms.Panel();
            this.greenPanel = new System.Windows.Forms.Panel();
            this.yellowPanel = new System.Windows.Forms.Panel();
            this.bluePanel = new System.Windows.Forms.Panel();
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
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleStepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ramView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // redPanel
            // 
            this.redPanel.BackColor = System.Drawing.Color.Red;
            this.redPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.redPanel.Location = new System.Drawing.Point(245, 36);
            this.redPanel.Name = "redPanel";
            this.redPanel.Size = new System.Drawing.Size(227, 157);
            this.redPanel.TabIndex = 0;
            // 
            // greenPanel
            // 
            this.greenPanel.BackColor = System.Drawing.Color.Green;
            this.greenPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.greenPanel.Location = new System.Drawing.Point(12, 36);
            this.greenPanel.Name = "greenPanel";
            this.greenPanel.Size = new System.Drawing.Size(227, 157);
            this.greenPanel.TabIndex = 1;
            this.greenPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // yellowPanel
            // 
            this.yellowPanel.BackColor = System.Drawing.Color.Yellow;
            this.yellowPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.yellowPanel.Location = new System.Drawing.Point(245, 199);
            this.yellowPanel.Name = "yellowPanel";
            this.yellowPanel.Size = new System.Drawing.Size(227, 157);
            this.yellowPanel.TabIndex = 2;
            // 
            // bluePanel
            // 
            this.bluePanel.BackColor = System.Drawing.Color.MediumBlue;
            this.bluePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bluePanel.Location = new System.Drawing.Point(12, 199);
            this.bluePanel.Name = "bluePanel";
            this.bluePanel.Size = new System.Drawing.Size(227, 157);
            this.bluePanel.TabIndex = 2;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ramView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ramView.DefaultCellStyle = dataGridViewCellStyle4;
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
            this.codeListBox.Location = new System.Drawing.Point(660, 47);
            this.codeListBox.Name = "codeListBox";
            this.codeListBox.ScrollAlwaysVisible = true;
            this.codeListBox.Size = new System.Drawing.Size(235, 436);
            this.codeListBox.TabIndex = 17;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.runToolStripMenuItem});
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
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.singleStepToolStripMenuItem});
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.runToolStripMenuItem.Text = "&Run";
            // 
            // singleStepToolStripMenuItem
            // 
            this.singleStepToolStripMenuItem.Name = "singleStepToolStripMenuItem";
            this.singleStepToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.singleStepToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.singleStepToolStripMenuItem.Text = "&Single Step";
            this.singleStepToolStripMenuItem.Click += new System.EventHandler(this.singleStepToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 503);
            this.Controls.Add(this.codeListBox);
            this.Controls.Add(this.ramView);
            this.Controls.Add(this.bluePanel);
            this.Controls.Add(this.yellowPanel);
            this.Controls.Add(this.greenPanel);
            this.Controls.Add(this.redPanel);
            this.Controls.Add(this.cpuGroup);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ramView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel redPanel;
        private System.Windows.Forms.Panel greenPanel;
        private System.Windows.Forms.Panel yellowPanel;
        private System.Windows.Forms.Panel bluePanel;
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
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singleStepToolStripMenuItem;
    }
}

