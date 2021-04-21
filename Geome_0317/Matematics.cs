using System;
using System.Collections.Generic;

namespace Geome_0317
{
    public class Matematics
    {
        
        public static float Euclid(Point A, Point B)
        {
            return (float)Math.Sqrt((A.X - B.X) * (A.X - B.X) + (A.Y - B.Y) * (A.Y - B.Y));
        }

        public static float Area(Point A, Point B, Point C)
        {
            return 0.5f * ((A.X * B.Y) + (B.X * C.Y) + (C.X * A.Y) - (C.X * B.Y) - (A.X * C.Y) - (A.Y * B.X));
        }

        public static float Height(Point A, Point B, Point C)
        {
            return (Area(A, B, C) * 2) / Euclid(A, B);
        }


        public static int FindSide(Point p1, Point p2, Point p)
        {
            float val = (p.Y - p1.Y) * (p2.X - p1.X) - (p2.Y - p1.Y) * (p.X - p1.X);
            if (val > 0)
                return 1; // left
            if (val < 0)
                return -1; // right
            return 0;
        }

        public static float Cross(Point a, Point b)
        {
            return a.X * b.Y - a.Y * b.X;
        }

        public static float lineDist(Point p1, Point p2, Point p)
        {
            return Math.Abs((p.Y - p1.Y) * (p2.X - p1.X) -
                       (p2.Y - p1.Y) * (p.X - p1.X));
        }

        

        public static float AreaPoligon(List<Point> points)
        {
            Point O = new Point(0, 0);
            float val = 0;
            for (int i = 0; i < points.Count - 1; i++)
            {
                val += Area(points[i], points[i + 1], O);
            }
            return Math.Abs(val);
        }

        public static (int, int) MinDist(int n, int idx1, int idx2)
        {
            float min = Euclid(Engine.points[0], Engine.points[1]);
            idx1 = 0;
            idx2 = 1;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    float t = Euclid(Engine.points[i], Engine.points[j]);
                    if (t < min)
                    {
                        min = t;
                        idx1 = i;
                        idx2 = j;
                    }
                }
            }
            return (idx1, idx2);
        }


       
    }
}
