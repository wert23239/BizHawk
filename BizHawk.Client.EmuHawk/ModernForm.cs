using RealTimeCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;

namespace BizHawk.Client.EmuHawk
{
	public partial class ModernForm : Form
	{
		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;

		[System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
		public static extern bool ReleaseCapture();

		/*private void Form1_MdiChildActivate(object sender,
									EventArgs e)
		{
			if (this.ActiveMdiChild == null)
				tabForms.Visible = false;
			// If no any child form, hide tabControl 
			else
			{
				this.ActiveMdiChild.WindowState =
				FormWindowState.Maximized;
				// Child form always maximized 

				// If child form is new and no has tabPage, 
				// create new tabPage 
				if (this.ActiveMdiChild.Tag == null)
				{
					// Add a tabPage to tabControl with child 
					// form caption 
					TabPage tp = new TabPage(this.ActiveMdiChild
											 .Text);
					tp.Tag = this.ActiveMdiChild;
					tp.Parent = tabForms;
					tabForms.SelectedTab = tp;

					this.ActiveMdiChild.Tag = tp;
					this.ActiveMdiChild.FormClosed +=
						new FormClosedEventHandler(
										ActiveMdiChild_FormClosed);
				}

				if (!tabForms.Visible) tabForms.Visible = true;

			}
		}*/

		public ModernForm()
		{
			InitializeComponent();
			Form1 newGraph = new Form1();
			newGraph.TopLevel = false;
			newGraph.Show();
			this.tabControl1.TabPages[0].Controls.Add(newGraph);
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{

		}

		private void ModernForm_Load(object sender, EventArgs e)
		{

		}

		private void label1_Click_1(object sender, EventArgs e)
		{

		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			rightmostValLabel.Text = trackBar1.Value.ToString();
		}

		private void closeApplication_Click(Object sender, EventArgs e)
		{
			this.Dispose();
		}

		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);
			if (this.FormBorderStyle != FormBorderStyle.None)
			{
					this.FormBorderStyle = FormBorderStyle.None;
			}
		}

		private void minimizeApplication_Click(object sender, EventArgs e)
		{
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.WindowState = FormWindowState.Minimized;
		}

		private void noveltyConstant_Click(object sender, EventArgs e)
		{

		}

		private void rightmostTab_Click(object sender, EventArgs e)
		{
			Form1 newGraph = new Form1();
			newGraph.TopLevel = false;
			newGraph.BackColor = Color.Red;
			newGraph.Show();
			this.tabControl1.TabPages[0].Controls.Add(newGraph);
			this.BackColor = Color.Red;
		}

		private void scoreTab_Click(object sender, EventArgs e)
		{
			Form1 newGraph = new Form1();
			newGraph.TopLevel = false;
			newGraph.BackColor = Color.Red;
			newGraph.Show();
			this.tabControl1.TabPages[2].Controls.Add(newGraph);
			this.BackColor = Color.Red;
		}

		private void noveltyTab_Click(object sender, EventArgs e)
		{
			Form1 newGraph = new Form1();
			newGraph.TopLevel = false;
			newGraph.BackColor = Color.Red;
			newGraph.Show();
			this.tabControl1.TabPages[1].Controls.Add(newGraph);
			this.BackColor = Color.Red;
		}

		private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
		{

		}

		private void tabControl1_Selected(object sender, TabControlEventArgs e)
		{
			Form1 newGraph = new Form1();
			newGraph.TopLevel = false;
			newGraph.Show();


			TabPage current = (sender as TabControl).SelectedTab;
			if (current.Name == "noveltyTab")
			{
				this.tabControl1.TabPages[1].Controls.Add(newGraph);
			}
			else if(current.Name == "scoreTab"){
				this.tabControl1.TabPages[2].Controls.Add(newGraph);
			}
			else if(current.Name == "rightmostTab"){
				this.tabControl1.TabPages[0].Controls.Add(newGraph);
			}
		}
	}
}
