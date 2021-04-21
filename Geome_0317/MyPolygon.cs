using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geome_0317
{
    public class MyPolygon
    {
        public List<Point> points = new List<Point>();
        public List<Triangle> triangles = new List<Triangle>();
        public List<Point> hull = new List<Point>();
        public MyPolygon(List<Point> points)
        {
            this.points = points;
        }

    }
}
