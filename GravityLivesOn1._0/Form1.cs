using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace GravityLivesOn1._0
{
	public class Form1 : Form
	{

        

        private Random rand;

        private readonly object objecter;

        private Graphics g;

		private Bitmap bitmap;

		private Affector[] affector;

		private Graphics graphics;

		private Graphics graphics2;

		private Panel panel1;

		private Bitmap bitmap2;

		private SolidBrush b;

        public object Objecter => objecter;

        public Form1()
		{
			rand = new Random();
			getAffector(0);
			InitializeComponent();
			designObjekter(rand.Next(1000, 5000), rand.Next(1000, 5000), affector);
			g = panel1.CreateGraphics();
			bitmap = new Bitmap(2880, 1800, PixelFormat.Format32bppArgb);
			graphics = Graphics.FromImage(bitmap);
			graphics.Clear(Color.FromArgb(rand.Next(255), rand.Next(180, 255), rand.Next(180, 255), rand.Next(180, 255)));
			bitmap2 = new Bitmap(bitmap.Width, bitmap.Height);
			graphics2 = Graphics.FromImage(bitmap2);
			graphics2 = Graphics.FromImage(bitmap2);
			graphics2.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics2.DrawImage(bitmap, 0, 0);
			Thread thread = new Thread(clickMe);
			thread.Start();
		}

		private void panel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void DrawPaintMe()
		{
			
			graphics2.Save();
			g.DrawImage(bitmap2, 0, 0);
			animate();
		}

		private void animate()
		{
			int maxValue = rand.Next(15);
			
		}

		private void getAffector(int numbers)
		{
			affector = new Affector[numbers];
		}

		private void designObjekter(int number, int speed, Affector[] aff)
		{
			affector = aff;
			for (int i = 0; i < number; i++)
			{
				Ding ding = new Ding(rand.Next(speed), rand.Next(100), rand.Next(255), rand.Next(10), this, affector);
			}
		}

		private void panel1_MouseClick(object sender, MouseEventArgs e)
		{
		}

		private void clickMe()
		{
			for (int i = 0; i < 10; i++)
			{
				if (rand.Next(2) == 0)
				{
					designObjekter(rand.Next(100, 300), rand.Next(5), affector);
				}
				for (int j = 0; j < rand.Next(10, 30); j++)
				{
					DrawPaintMe();
				}
				if (rand.Next(6) == 0)
				{
					graphics2.Clear(Color.FromArgb(rand.Next(55), rand.Next(180, 255), rand.Next(180, 255), rand.Next(180, 255)));
				}
			}
			clickMe();
			graphics2.DrawString("Click me!!", new Font("Verdana", 32f, FontStyle.Bold), Brushes.White, new PointF(200f, 900f));
			graphics2.Save();
			g.DrawImage(bitmap2, 0, 0);
		}

		private void InitializeComponent()
		{
			panel1 = new System.Windows.Forms.Panel();
			SuspendLayout();
			panel1.AutoSize = true;
			panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1920, 1062);
			panel1.TabIndex = 0;
			panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
			panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(panel1_MouseClick);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1920, 1062);
			base.Controls.Add(panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Name = "Form1";
			Text = "Gravity v2.0";
			base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			ResumeLayout(performLayout: false);
			PerformLayout();
		}
	}
}
