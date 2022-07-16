using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace xor
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			this.InitializeComponent();
			XorTool.SetText = (Action<string>)Delegate.Combine(XorTool.SetText, new Action<string>(this.LableSetText));
			XorTool.enablebutton = (Action)Delegate.Combine(XorTool.enablebutton, new Action(this.enablebut));
		}

		private void enablebut()
		{
			if (base.InvokeRequired)
			{
				base.BeginInvoke(new Action(delegate()
				{
					this.button4.Enabled = true;
				}));
				return;
			}
			this.button4.Enabled = true;
		}

		private void LableSetText(string value)
		{
			if (base.InvokeRequired)
			{
				base.BeginInvoke(new Action(delegate()
				{
					this.label2.Text = value;
				}));
				return;
			}
			this.label2.Text = value;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (File.Exists(this.textBox1.Text))
			{
				XorTool.Decrypt(this.textBox1.Text);
				return;
			}
			this.label2.Text = "not a file.";
		}

		private void button2_Click(object sender, EventArgs e)
		{
			FileDialog fileDialog = new OpenFileDialog();
			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				this.textBox1.Text = fileDialog.FileName;
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			XorTool.Encrypt(this.textBox1.Text);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			this.button4.Enabled = false;
			FolderBrowserDialog folder = new FolderBrowserDialog();
			if (folder.ShowDialog() == DialogResult.OK)
			{
				ThreadPool.QueueUserWorkItem(delegate(object x)
				{
					XorTool.DecryptFolder(folder.SelectedPath);
					this.enablebut();
				});
			}
		}

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
			FileDialog fileDialog = new OpenFileDialog();
			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				this.textBox1.Text = fileDialog.FileName;
			}
		}
    }
}
