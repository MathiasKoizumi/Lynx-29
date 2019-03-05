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

		private Ding[] objekter;

		private Graphics g;

		private Bitmap bitmap;

		private Affector[] affector;

		private Graphics graphics;

		private Graphics graphics2;

		private Panel panel1;

		private Bitmap bitmap2;

		private SolidBrush b;

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
			for (int i = 0; i < objekter.Length; i++)
			{
				b = new SolidBrush(objekter[i].farve);
				graphics2.FillEllipse(b, objekter[i].positionX, objekter[i].positionY, (int)objekter[i].størrelse, (int)objekter[i].størrelse);
				b.Dispose();
			}
			for (int j = 0; j < affector.GetLength(0); j++)
			{
				graphics2.DrawLine(new Pen(Brushes.Gray), rand.Next(1000), rand.Next(600), (float)affector[j].start.X, (float)affector[j].end.Y);
				new Point3D(affector[j].end.X, affector[j].end.Y, affector[j].end.Z);
				new Point3D(affector[j].start.X, affector[j].start.Y, affector[j].start.Z);
			}
			graphics2.Save();
			g.DrawImage(bitmap2, 0, 0);
			animate();
		}

		private void animate()
		{
			int maxValue = rand.Next(15);
			for (int i = 0; i < objekter.Length; i++)
			{
				objekter[i].positionX = objekter[i].positionX + objekter[i].hastighedX;
				objekter[i].positionY = objekter[i].positionY + objekter[i].hastighedY;
				objekter[i].positionZ = objekter[i].positionZ + objekter[i].hastighedZ;
				for (int j = 0; j < affector.GetLength(0); j++)
				{
					objekter[i].positionX += (float)affector[j].destination.X;
					objekter[i].positionY += (float)affector[j].destination.Y;
					objekter[i].positionZ += (float)affector[j].destination.Z;
				}
				switch (rand.Next(2))
				{
				case 0:
					objekter[i].hastighedX = objekter[i].hastighedX + (float)(rand.Next(maxValue) * 6);
					objekter[i].hastighedY = objekter[i].hastighedY + (float)(rand.Next(maxValue) * 6);
					objekter[i].hastighedZ = objekter[i].hastighedZ + (float)(rand.Next(maxValue) * 6);
					break;
				case 1:
					objekter[i].hastighedX = objekter[i].hastighedX - (float)(rand.Next(maxValue) * 6);
					objekter[i].hastighedY = objekter[i].hastighedY - (float)(rand.Next(maxValue) * 6);
					objekter[i].hastighedZ = objekter[i].hastighedZ - (float)(rand.Next(maxValue) * 6);
					break;
				}
				if (rand.Next(0) == 0)
				{
					objekter[i].størrelse = objekter[i].størrelse + (double)objekter[i].positionZ * 0.1;
				}
			}
		}

		private void getAffector(int numbers)
		{
			affector = new Affector[numbers];
		}

		private void designObjekter(int number, int speed, Affector[] aff)
		{
			affector = aff;
			objekter = new Ding[number];
			for (int i = 0; i < number; i++)
			{
				Ding ding = new Ding(rand.Next(speed), rand.Next(100), rand.Next(255), rand.Next(10), this, affector);
				objekter[i] = ding;
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
