using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geome_0317
{
    public class Square
    {
        public static int id;
        
        //public static int size = 50;
        public static Random rnd = new Random();
        public static Point A;
        public static Point B;
        public static Point C;
        public static Point D;
        public Square(int i)
        {
            int size = rnd.Next(20,200);
            id = i;
            A = new Point(rnd.Next(400 - size), rnd.Next(300 - size));
            B = new Point(A.X + size, A.Y);
            C = new Point(A.X + size, A.Y + size);
            D = new Point(A.X, A.Y + size);
        }

        public static void drawPoints(Graphics gfx)
        {
            A.draw(gfx);
            B.draw(gfx);
            C.draw(gfx);
            D.draw(gfx);
        }

        public static void drawLines(Graphics gfx)
        {
            Color color = Color.FromArgb(rnd.Next(250), rnd.Next(250), rnd.Next(250));
            Pen pen = new Pen(color);
            gfx.DrawLine(pen, A.X, A.Y, B.X, B.Y);
            gfx.DrawLine(pen, B.X, B.Y, C.X, C.Y);
            gfx.DrawLine(pen, C.X, C.Y, D.X, D.Y);
            gfx.DrawLine(pen, A.X, A.Y, D.X, D.Y);
        }

        public static void drawSimetrics(Graphics gfx)
        {
            Color color = Color.Black;
            Pen pen = new Pen(color);

            Point E = new Point((A.X + B.X) / 2, (A.Y + B.Y) / 2);
            Point F = new Point((C.X + D.X) / 2, (C.Y + D.Y) / 2);
            gfx.DrawLine(pen, E.X, E.Y, F.X, F.Y);

            Point G = new Point((A.X + D.X) / 2, (A.Y + D.Y) / 2);
            Point H = new Point((C.X + B.X) / 2, (C.Y + B.Y) / 2);
            gfx.DrawLine(pen, G.X, G.Y, H.X, H.Y);

            gfx.DrawLine(pen, C.X, C.Y, A.X, A.Y);
            gfx.DrawLine(pen, B.X, B.Y, D.X, D.Y);
        }

        public void draw(Graphics gfx)
        {
           //drawPoints(gfx);
           drawLines(gfx);
           drawSimetrics(gfx);
        }
    }
}
