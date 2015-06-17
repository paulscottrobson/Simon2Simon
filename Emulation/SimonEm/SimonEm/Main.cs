using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimonEm
{

    public partial class Main : Form
    {
        private SimonHardware simon = new SimonHardware();

        private static String[] registers = { "3pctr", "1a", "1x", "1y", "2xy", "1s", "1pa", "1pb", "2pc", "2sr", "1sl", "1cl","2o","4cycles" };

        private Label[] registerLabels;
        private int[] registerWidths;
        private IList<String> disassembly;
        private int[] codeItem = new int[1024];

        public Main()
        {
            InitializeComponent();
            registerLabels = new Label[registers.Length];
            registerWidths = new int[registers.Length];
            Font lblFont = new Font(FontFamily.GenericSansSerif, 11);
            for (int i = 0; i < registers.Length; i++)
            {
                int x = cpuGroup.Left + 16;
                int y = cpuGroup.Top + 16 + (cpuGroup.Height - 32) * i / (registers.Length-0);
                Label lbl = new Label();
                y = y + lbl.Height / 2;
                lbl.Text = registers[i].Substring(1).ToUpper() + ":";
                lbl.Left = x; lbl.Top = y;
                this.Controls.Add(lbl);
                lbl.BringToFront();
                lbl.Font = lblFont;

                registerWidths[i] = Int32.Parse(registers[i].Substring(0, 1));
                registerLabels[i] = new Label();
                registerLabels[i].Left = x + 72; registerLabels[i].Top = y;
                registerLabels[i].Text = "XXXXXX".Substring(0, registerWidths[i]);
                this.Controls.Add(registerLabels[i]);
                registerLabels[i].BringToFront();
                registerLabels[i].Font = lblFont;
                registerLabels[i].Width = 48;
            }
            for (int i = 0; i < 16; i++)
            {
                ramView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            disassembly = simon.getAssemblerCode();
            foreach (String s in disassembly)
            {
                if (s != "")
                {
                    int address = Convert.ToInt32(s.Substring(0, 3), 16);
                    codeItem[address] = codeListBox.Items.Count;
                }
                codeListBox.Items.Add(s);
            }
            RefreshProcessor();
        }


        private void RefreshProcessor()
        {
            String[] data;
            IDictionary<string, int> status = simon.getStatus();
            for (int i = 0; i < registers.Length; i++)
            {
                String text = status[registers[i].Substring(1)].ToString("X"+(registerWidths[i].ToString()));
                registerLabels[i].Text = text;
            }
            ramView.Rows.Clear();
            for (int row = 0; row < 4; row++)
            {
                data = new String[16];
                for (int col = 0; col < 16; col++)
                    data[col] = "    " + simon.getRAMMemory(row * 16 + col).ToString("X1") + "    ";
                ramView.Rows.Add(data);
            }
            ramView.Rows.Add("");
            data = new String[16];
            for (int col = 0; col <= 10; col++)
                data[col] = status["r" + col.ToString()].ToString();
            ramView.Rows.Add(data);
            ramView.CurrentCell = ramView.Rows[status["x"]].Cells[status["y"]];

            int pctr = codeItem[status["pctr"]];
            codeListBox.SelectionMode = SelectionMode.MultiExtended ;
            codeListBox.ClearSelected();
            codeListBox.SelectedIndex = pctr;
            codeListBox.TopIndex = pctr - 4;
            
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void singleStepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            simon.execute();
            RefreshProcessor();
        }
    }
}
