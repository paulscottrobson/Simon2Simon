using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NAudio.Wave;

namespace SimonEm
{

	public partial class Main : Form
	{
		private SimonHardware simon = new SimonHardware();

		private static String[] registers = { "3pctr", "1a", "1x", "1y", "2xy", "1s", "1pa", "1pb", "2pc", "2sr", "1sl", "1cl","2o","4cycles" };

		private Stopwatch stopwatch = new Stopwatch();
		private Label[] registerLabels;
		private int[] registerWidths;
		private IList<String> disassembly;
		private int[] codeItem = new int[1024];
		private bool[] LightStatus = new bool[4];
		private float[] LightTimers = new float[4];
		private WaveOut waveout;

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
				if (s != "" && !s.StartsWith("Page", StringComparison.InvariantCulture))
				{
					int address = Convert.ToInt32(s.Substring(0, 3), 16);
					codeItem[address] = codeListBox.Items.Count;
				}
				codeListBox.Items.Add(s);
			}
			RefreshProcessor();
									
			//setup sound
			waveout = new WaveOut();
			SampleProvider sampleProvider = new SampleProvider(simon);			   
			waveout.DesiredLatency = 100;
			waveout.Init(sampleProvider);		

			clipZones = GetClipZones();
			clipRegion = GetClipRegion();
		}
		
		public void Stop()
		{
			if(timer1.Enabled)
			{
				Console.WriteLine("stop");
				timer1.Enabled = false;
				RefreshProcessor();
			}
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
					data[col] = "	 " + simon.getRAMMemory(row * 16 + col).ToString("X1") + "	  ";
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

		private void singleStepToolStripMenuItem_Click(object sender, EventArgs e)
		{
			timer1.Enabled = false;
			runToolStripMenuItem.Enabled = true;
			stopToolStripMenuItem.Enabled = true;
			simon.execute();
			RefreshProcessor();			   
		}
		
		void RunToolStripMenuItem1Click(object sender, EventArgs e)
		{
			cyclesSoFar = 0;
			stopwatch.Restart();
			waveout.Play();
			
			runToolStripMenuItem.Enabled = false;
			stopToolStripMenuItem.Enabled = true;
			timer1.Enabled = true;
		}
		
		void StopToolStripMenuItem1Click(object sender, EventArgs e)
		{
			simon.reset();
			waveout.Stop();
			
			timer1.Enabled = false;
			stopToolStripMenuItem.Enabled = false;
			runToolStripMenuItem.Enabled = true;
			RefreshProcessor();			 
		}
		
		int cyclesSoFar;		
		void Timer1Tick(object sender, EventArgs e)
		{
			//300000hz / 6 cycles = 50000hz
			long ticks = (stopwatch.ElapsedMilliseconds * 50000) / 1000;
			while(ticks > cyclesSoFar && timer1.Enabled)
			{					
				simon.execute();
				cyclesSoFar++;
				updateLights();
			}
		}
		
		void StartButtonMouseDown(object sender, MouseEventArgs e)
		{
			simon.Start = true;
		}
		
		void StartButtonMouseUp(object sender, MouseEventArgs e)
		{
			simon.Start = false;
		}
		
		void LastButtonMouseDown(object sender, MouseEventArgs e)
		{
			simon.Last = true;
		}
		
		void LastButtonMouseUp(object sender, MouseEventArgs e)
		{
			simon.Last = false;
		}
		
		void LongestButtonMouseDown(object sender, MouseEventArgs e)
		{
			simon.Longest = true;
		}
		
		void LongestButtonMouseUp(object sender, MouseEventArgs e)
		{
			simon.Longest = false;
		}			
		
		void GameButton1Click(object sender, EventArgs e)
		{
			simon.Game = 1;
		}
		
		void GameButton2Click(object sender, EventArgs e)
		{
			simon.Game = 2;
		}
		
		void GameButton3Click(object sender, EventArgs e)
		{
			simon.Game = 3;
		}
		
		void SkillButton1Click(object sender, EventArgs e)
		{
			simon.Skill = 1;
		}
		
		void SkillButton2Click(object sender, EventArgs e)
		{
			simon.Skill = 2;
		}
		
		void SkillButton3Click(object sender, EventArgs e)
		{
			simon.Skill = 3;
		}
				
		void SkillButton4Click(object sender, EventArgs e)
		{
			simon.Skill = 4;
		}
		
		private readonly Rectangle[] clipZones;
		
		private readonly Region clipRegion;
		
		private Rectangle[] GetClipZones()
		{
			int halfWidth = simonPanel.Width / 2;
			int halfHeight = simonPanel.Height / 2;
			
			return new []
			{
				new Rectangle(0, 0, halfWidth, halfHeight),
				new Rectangle(halfWidth, 0, halfWidth, halfHeight),
				new Rectangle(halfWidth, halfHeight, halfWidth, halfHeight),
				new Rectangle(0, halfHeight, halfWidth, halfHeight)
			};
		}
		
		private Region GetClipRegion()
		{
			const int border = 18;
			Rectangle rect = new Rectangle(border, border, simonPanel.Width - border * 2, simonPanel.Height - border * 2);
			Rectangle outerRectangle = new Rectangle(new Point(rect.Left, rect.Top), rect.Size);
			Rectangle innerRectangle = new Rectangle(new Point(rect.Left+rect.Size.Width / 4, rect.Top+rect.Size.Height / 4),
													 new Size(rect.Size.Width / 2, rect.Size.Height / 2));
			
			GraphicsPath outerPath = new GraphicsPath();
			outerPath.AddEllipse(outerRectangle);
			
			GraphicsPath innerPath = new GraphicsPath();
			innerPath.AddEllipse(innerRectangle);
			
			Region r = new Region(outerPath);			
			r.Exclude(new Rectangle(rect.Left + rect.Width / 2 - border / 2, rect.Top, border, rect.Height));
			r.Exclude(new Rectangle(rect.Left, rect.Top + rect.Height / 2 - border / 2, rect.Width, border));
			r.Exclude(innerPath);
						
			return r;
		}
				
		private readonly Color[] colorsOff =
		{
			Color.FromArgb(255, 25, 100, 75),
			Color.FromArgb(255, 100, 25, 25),
			Color.FromArgb(255, 0, 100, 150),
			Color.FromArgb(255, 120, 100, 50)
		};

		private readonly Color[] colorsOn =
		{
			Color.FromArgb(255, 50, 200, 100),
			Color.FromArgb(255, 200, 50, 50),
			Color.FromArgb(255, 0, 200, 250),
			Color.FromArgb(255, 250, 250, 100)
		};
				
		void simonPanelPaint(object sender, PaintEventArgs e)
		{			
			e.Graphics.SetClip(clipRegion, CombineMode.Replace);
			
			for (int i = 0; i < 4; i++)
			{ 
				if(e.ClipRectangle.IntersectsWith(clipZones[i]))
				{ 	
                    									
					e.Graphics.FillRectangle(new SolidBrush(LightStatus[i] ? colorsOn[i] : colorsOff[i]), clipZones[i]);
				}
			}			
		}
						
		private void simonPanel_MouseDown(object sender, MouseEventArgs e)
		{
			for (int i = 0; i < 4; i++)
			{
				if (clipZones[i].Contains(e.X, e.Y))
				{
					simon.LightStatus[i] = true;
				}
			}
		}

		private void simonPanel_MouseUp(object sender, MouseEventArgs e)
		{
			for (int i = 0; i < 4; i++)
			{
				simon.LightStatus[i] = false;
			}
		}
		
		private void updateLights()
		{
			//light need to be off for a given period
			//before changing state
			for (int i = 0; i < 4; i++)
			{
				if(simon.getRegisterStatus(i + 4) == 1)
				{
					//light on
					LightTimers[i] = 1.0f;
					if(!LightStatus[i])
					{
						LightStatus[i] = true;
						simonPanel.Invalidate(clipZones[i]);
					}
				}
				else
				{
					//light off
					LightTimers[i] -= 0.005f;
					
					if(LightTimers[i] < 0.0f)
					{
						LightTimers[i] = 0.0f;
						if(LightStatus[i])
						{
							LightStatus[i] = false;
							simonPanel.Invalidate(clipZones[i]);
						}
					}
				}								
			}
		}
		
	}
}
