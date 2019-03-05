using System;
using System.Windows.Media.Media3D;

namespace GravityLivesOn1._0
{
	internal class Affector
	{
		public Point3D start;

		public Point3D end;

		public double speed;

		public Point3D destination;

		public Affector(Point3D startpoint, Point3D endpoint)
		{
			start = startpoint;
			end = endpoint;
			int num = (int)(Math.Pow(startpoint.X - endpoint.X, 2.0) + Math.Pow(startpoint.Y - endpoint.Y, 2.0));
			speed = Math.Sqrt(num) / 800.0;
			destination = new Point3D((int)((start.X - end.X) * speed), (int)((start.Y - end.Y) * speed), (int)((start.Z - end.Z) * speed));
		}
	}
}
