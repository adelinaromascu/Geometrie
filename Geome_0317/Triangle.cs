using System;
using System.Drawing;

namespace Geome_0317
{
    public class Triangle
    {
        public Point A;
        public Point B;
        public Point C;

        public Triangle(Point A, Point B, Point C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }
        public Triangle(int idx1, int idx2, int idx3)
        {
            A = Engine.points[idx1];
            B = Engine.points[idx2];
            C = Engine.points[idx3];
        }



        public void Draw(Color color)
        {
            Pen pen = new Pen(color);
            SolidBrush sb = new SolidBrush(color);
            PointF[] pointf = new PointF[3];
            pointf[0] = new PointF(A.X,A.Y);
            pointf[1] = new PointF(B.X,B.Y);
            pointf[2] = new PointF(C.X,C.Y);



            myGraphics.gfx.FillPolygon(sb, pointf);
        }

        public Point GetWeightCenter()
        {
            float x = (A.X + B.X + C.X) / 3;
            float y = (A.Y + B.Y + C.Y) / 3;
            return new Point(x, y);
        }

    }
}