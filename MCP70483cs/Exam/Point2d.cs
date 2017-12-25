using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    public class PointSample
    {
        public PointSample()
        {
            // implicit
            Point3d p1 = new Point2d(3d, 2d);

            // implicit , actually cast does not need.
            Point3d p2 = (Point3d)new Point2d(3d, 2d);

            // explicit
            Point2d p3 = (Point2d)new Point3d(1d, 2d, 3d);
        }
    }


    public struct Point2d
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point2d(double x, double y) : this()
        {
        }

    }

    public struct Point3d
    {
        // ユーザ定義変換
        public static explicit operator Point2d(Point3d value)
        {
            // convert Point3d to Point2d
            return new Point2d(value.X, value.Y);
        }

        public static implicit operator Point3d(Point2d value)
        {
            return new Point3d(value.X, value.Y, 0d);
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3d(double x, double y, double z) : this()
        {
        }
    }
}
