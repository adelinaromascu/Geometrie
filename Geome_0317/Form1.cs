using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Geome_0317
{

    public partial class Form1 : Form
    {
        private static Random rnd = new Random();
        private static int border = 10;
        private static int width;
        private static int height;
        private static bool animationWasStarted = false;
        private static string status;
        private static int tick = 100;

        private List<Color> Colors = new List<Color>();
        public Form1()
        {
            InitializeComponent();
            myGraphics.initGraph(pictureBox1);
            width = pictureBox1.Width;
            height = pictureBox1.Height;
            timer.Interval = tick;

            Colors.Add(Color.Red);
            Colors.Add(Color.Green);
            Colors.Add(Color.Blue);

        }


        #region Mouse input handler

        private void MouseUp(object sender, MouseEventArgs e)
        {
            // fires when mouse button is released after click

            if (e.Button == MouseButtons.Left) // if left-click
            {
                // we're getting point input from user
                Point p = new Point(e.X, e.Y);
                Engine.points.Add(p);
                status = "drawing";
            }
            else if (e.Button == MouseButtons.Right) // right-click
            {
                if (Engine.points.Count < 3) // polygon needs at least 3 points
                {
                    MessageBox.Show("You have to click at least 3 points!");
                    return;
                }

                draw_polygon_Click(sender, null);
            }


            foreach (Point point in Engine.points)
            {
                point.draw(myGraphics.gfx);
            }
            myGraphics.refreshGraph();
        }

        // mouse move handler - for drawing the polygon
        //private void panel_screen_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (status == "drawing") // if we'r currently in draw-mode
        //    {
        //        Point start, end;
        //        //Graphics g = panel_screen.CreateGraphics();
        //        g.Clear(Color.CornflowerBlue); // we need to clear screen as we drive lines to current mouse point

        //        // draw all entered vertices markers
        //        start = (Point)points[0];
        //        g.DrawLine(new Pen(Color.Yellow, 2), start.X - 6, start.Y, start.X + 6, start.Y);
        //        g.DrawLine(new Pen(Color.Yellow, 2), start.X, start.Y - 6, start.X, start.Y + 6);

        //        // continue drawing vertice markers
        //        for (int i = 0; i < points.Count - 1; i++)
        //        {
        //            start = (Point)points[i];
        //            g.DrawLine(new Pen(Color.Yellow, 2), start.X - 6, start.Y, start.X + 6, start.Y);
        //            g.DrawLine(new Pen(Color.Yellow, 2), start.X, start.Y - 6, start.X, start.Y + 6);
        //            end = (Point)points[i + 1];
        //            g.DrawLine(new Pen(Color.Yellow, 2), end.X - 6, end.Y, end.X + 6, end.Y);
        //            g.DrawLine(new Pen(Color.Yellow, 2), end.X, end.Y - 6, end.X, end.Y + 6);
        //            g.DrawLine(new Pen(Color.Blue, 2), start, end);
        //        }

        //        // draw a line from last entered vertice to current mouse cursor coordinate
        //        start = (Point)points[points.Count - 1];
        //        end = new Point(e.X, e.Y);
        //        g.DrawLine(new Pen(Color.Blue, 2), start, end);
        //        // marker to current mouse coordinate
        //        g.DrawLine(new Pen(Color.Yellow, 2), end.X - 6, end.Y, end.X + 6, end.Y);
        //        g.DrawLine(new Pen(Color.Yellow, 2), end.X, end.Y - 6, end.X, end.Y + 6);

        //    }

        //    // rulers

        //    Graphics f = panel_screen.CreateGraphics();
        //    for (int i = 0; i < panel_screen.Width; i += 100)
        //        f.DrawString(i.ToString(), lbl_cords.Font, Brushes.Black, i, 3);
        //    for (int i = 100; i < panel_screen.Height; i += 100)
        //        f.DrawString(i.ToString(), lbl_cords.Font, Brushes.Black, 3, i);

        //    Application.DoEvents();
        //}

        #endregion







        private void btn_refresh_Click(object sender, EventArgs e)
        {
            myGraphics.refreshGraph();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {

            Engine.clear();
            myGraphics.clearGraph();
            myGraphics.refreshGraph();
        }

        private void btn_addPoint_Click(object sender, EventArgs e)
        {
            //myGraphics.clearGraph();
            //Engine.clear();
            //output.Text = "Punctele eliminate sunt:" ;
            if (GetInputs() == 0) return;
            Engine.drawPoints(myGraphics.gfx);
            myGraphics.refreshGraph();

        }

        private int GetInputs()
        {
            string input = textBox1.Text;
            if (input == "")
            {
                return 0;
            }
            if (float.TryParse(input, out float n))
            {
                myGraphics.clearGraph();
                Engine.clear();

                for (int i = 0; i < n; i++)
                {
                    Engine.points.Add(new Point(rnd.Next(width), rnd.Next(height)));
                }
            }
            else
            {
                string[] line = textBox1.Text.Split(' ');
                float X = float.Parse(line[0]);
                float Y = float.Parse(line[1]);
                Engine.points.Add(new Point(X, Y));
            }
            return Engine.points.Count;
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            myGraphics.clearGraph();
            Engine.remove();
            Engine.draw(myGraphics.gfx);
            myGraphics.refreshGraph();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            Engine.drawLines(myGraphics.gfx);
            myGraphics.refreshGraph();
        }

        private void DrawLasloPoly(int n)
        {
            Engine.drawPolygon(myGraphics.gfx, n);


        }



        private void draw_polygon_Click(object sender, EventArgs e)
        {
            //myGraphics.gfx.Clear(Color.AliceBlue);
            //Engine.clear();
            output.Text = "Aria Poligonului: ";
            if (Engine.points.Count == 0)
            {
                if (textBox1.Text == "") return;
                int n = int.Parse(textBox1.Text);
                if (n < 3) return;
                DrawLasloPoly(n);
                myGraphics.refreshGraph();
            }
            else
            {
                Engine.drawLines(myGraphics.gfx);
                myGraphics.refreshGraph();
            }

        }

        private void DrawCordinates()
        {
            for (int i = 0; i < Engine.points.Count; i++)
            {
                Point p = Engine.points[i];
                string text = $"P{i}({p.X},{p.Y})";
                Font font = new Font(FontFamily.GenericSansSerif, 100);
                using (Font myfont = new Font("Arial", 8))
                {
                    if (!checkBox_Show_cordinates.Checked)
                    {
                        text = " ";
                    }
                    myGraphics.gfx.DrawString(text, myfont, Brushes.Purple, p.X, p.Y);
                }

            }


        }

        

        

       

        private void QuickHull()
        {
            Engine.hull.Clear();
            int min_x = 0, max_x = 0;
            for (int i = 1; i < Engine.points.Count; i++)
            {
                if (Engine.points[i].X < Engine.points[min_x].X)
                    min_x = i;
                if (Engine.points[i].X > Engine.points[max_x].X)
                    max_x = i;
            }
            Engine.hull.Add(Engine.points[min_x]);
            Engine.hull.Add(Engine.points[max_x]);
            Point A = Engine.hull[0];
            Point B = Engine.hull[1];

            //the separator line
            if (checkBox_separatorLine.Checked)
            {
                myGraphics.gfx.DrawLine(new Pen(Color.Purple), A.X, A.Y, B.X, B.Y);
            }

            List<Point> S1 = new List<Point>();
            List<Point> S2 = new List<Point>();


            foreach (Point point in Engine.points)
            {
                float side = Matematics.FindSide(A, B, point);
                if (side == -1) S1.Add(point);
                side = Matematics.FindSide(B, A, point);
                if (side == -1) S2.Add(point);
            }

            foreach (Point point in S1)
            {
                //point.fillColor = Color.Blue;
                point.fillColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                point.draw(myGraphics.gfx);
            }

            foreach (Point point in S2)
            {
                //point.fillColor = Color.Green;
                point.fillColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                point.draw(myGraphics.gfx);
            }
            FindHull(S1, A, B);
            FindHull(S2, B, A);



        }

        private void FindHull(List<Point> sk, Point P, Point Q)
        {
            if (sk.Count == 0) return;
            int farthestPointIndex = 0;

            float max_dist = 0;
            for (int i = 0; i < sk.Count; i++)
            {
                float dist = Matematics.lineDist(P, Q, sk[i]);
                if (dist > max_dist)
                {
                    max_dist = dist;
                    farthestPointIndex = i;
                }

            }

            Point C = sk[farthestPointIndex];
            int idx = Engine.hull.IndexOf(P);
            Engine.hull.Insert(idx, C);


            List<Point> S1 = new List<Point>();
            List<Point> S2 = new List<Point>();

            foreach (Point point in Engine.points)
            {
                float side = Matematics.FindSide(P, C, point);
                if (side == -1) S1.Add(point);
                side = Matematics.FindSide(C, Q, point);
                if (side == -1) S2.Add(point);
            }


            FindHull(S1, P, C);
            FindHull(S2, C, Q);



        }




        private void FindLowestPoint()
        {
            int lowestPointIndex = 0;
            for (int i = 1; i < Engine.points.Count; i++)
            {
                if (Engine.points[i].Y > Engine.points[lowestPointIndex].Y)
                {
                    lowestPointIndex = i;
                }
                else if (Engine.points[i].Y == Engine.points[lowestPointIndex].Y)
                {
                    if (Engine.points[i].X < Engine.points[lowestPointIndex].X)
                    {
                        lowestPointIndex = i;
                    }
                }
            }
            Point aux = Engine.points[lowestPointIndex];
            Engine.points[lowestPointIndex] = Engine.points[0];
            Engine.points[0] = aux;
        }


        private int GetTurnType(Point a, Point b, Point c)
        {
            float area = (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
            if (area < 0) return -1; // counterclockwise
            if (area > 0) return 1; // clockwiseollinear
            return 0;               // collinear
        }

        private bool IsCounterClockwiseTurn(Point points, Point b, Point c)
        {
            return GetTurnType(points, b, c) == -1;
        }

        private void SortPointsByAngle(Point center)
        {
            List<Point> sortedPoints =
            Engine.points.GetRange(1, Engine.points.Count - 1).OrderBy(p => -Math.Atan2(p.Y - center.Y, p.X - center.X)).ToList();
            Point firstPoint = Engine.points[0];
            Engine.points.Clear();
            Engine.points.Add(firstPoint);
            Engine.points.AddRange(sortedPoints);
        }

        private void Graham()
        {
            Engine.hull.Clear();
            FindLowestPoint();
            SortPointsByAngle(Engine.points[0]);
            Engine.hull.Add(Engine.points[0]);
            Engine.hull.Add(Engine.points[1]);
            for (int i = 2; i < Engine.points.Count; i++)
            {
                while (Engine.hull.Count > 1 && !IsCounterClockwiseTurn(Engine.hull[Engine.hull.Count - 2], Engine.hull[Engine.hull.Count - 1], Engine.points[i]))
                {
                    Engine.hull.RemoveAt(Engine.hull.Count - 1);
                }
                Engine.hull.Add(Engine.points[i]);
            }
        }

        private void Jarvis()
        {
            Engine.hull.Clear();
            FindLowestPoint();
            Engine.hull.Add(Engine.points[0]);
            Point previous = Engine.points[0];
            while (true)
            {
                Point next = new Point();
                next.X = -1;
                next.Y = -1;
                foreach (Point p in Engine.points)
                {
                    if (p.X == previous.X && p.Y == previous.Y) continue;
                    if (next.X == -1 && next.Y == -1)
                    {
                        next = p;
                        continue;
                    }

                    if (IsCounterClockwiseTurn(previous, next, p))
                    {
                        next = p;
                    }
                }
                if (next.X == Engine.points[0].X && next.Y == Engine.points[0].Y) break;
                Engine.hull.Add(next);
                previous = next;
            }
        }

        private void button_Animate_QuickHull_Click(object sender, EventArgs e)
        {
            timer.Start();
            QuickHull();

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //checkBox_Show_cordinates_CheckedChanged(sender, e);
            button_Disco_Click(sender, e);
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void button_Triangulate_Click(object sender, EventArgs e)
        {

            double area = 0;
            int count = Engine.points.Count;
            if (count < 3) return;
            if (count == 3) { area = Matematics.Area(Engine.points[0], Engine.points[1], Engine.points[2]); return; }

            List<Point> points = Engine.points;// lista temporara
            List<int> indexList = new List<int>();

            for (int i = 0; i < points.Count; i++)
            {
                indexList.Add(i); //initializarea listei de indecsi de la 0 pana la nr de puncte
            }

            Point A;
            Point B;
            Point C;

            while (indexList.Count > 3)
            {
                for (int i = 0; i < indexList.Count; i++)
                {
                    int a = indexList[i]; // the index of current Item
                    int b = GetItem(indexList, i - 1); // the index of leftside neighbour
                    int c = GetItem(indexList, i + 1); // the index of righside neighbour

                    A = points[a];
                    B = points[b];
                    C = points[c];

                    int clockwise = GetTurnType(A, B, C);
                    if (clockwise != -1) continue; // make a salt to next index


                    bool isEar = true;  //presupunem ca este o ureche valida daca este 
                    for (int j = 0; j < points.Count; j++)
                    {
                        if (j == a || j == b || j == c)
                        {
                            continue; //excluding the current index and the neighbours from test
                        }

                        if (IsPointInTriangle(points[j], A, B, C))
                        {
                            isEar = false;
                            break;
                        }
                    }


                    if (isEar)
                    {

                        Engine.triangles.Add(new Triangle(A, B, C)); //add the triangle in the list, if is a valid ear.

                        indexList.RemoveAt(i); //remove the current index from the indexlist

                        //drawing the line to make a triangle visualy
                        Pen pen = new Pen(Color.Green);
                        myGraphics.gfx.DrawLine(pen, C.X, C.Y, B.X, B.Y);
                        myGraphics.refreshGraph();
                        break;
                    }

                }

            }


            //adding last 3 points what makes a triangle
            A = points[indexList[0]];
            B = points[indexList[1]];
            C = points[indexList[2]];
            Engine.triangles.Add(new Triangle(A, B, C));

            // calculate the polygon area using triangle's area.
            foreach (Triangle triangle in Engine.triangles)
            {
                area += Math.Abs(Matematics.Area(triangle.A, triangle.B, triangle.C));

            }



            points.Clear();
            indexList.Clear();

            output.Text = "Area:" + Environment.NewLine + area;
            status = "triangulation completed";

        }

        private bool IsPointInTriangle(Point P, Point A, Point B, Point C)
        {
            float areaOfTriangle = Math.Abs(Matematics.Area(A, B, C));
            float area_APB = Math.Abs(Matematics.Area(A, P, B));
            float area_APC = Math.Abs(Matematics.Area(A, P, C));
            float area_BPC = Math.Abs(Matematics.Area(B, P, C));
            return areaOfTriangle == area_APB + area_APC + area_BPC;
        }

        /// <summary>
        /// Treats the list as a circle. Is used for getting elements from list,
        /// keeping the elements in the list's boundary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <returns>A specified element from the list</returns>
        public static T GetItem<T>(List<T> list, int index)
        {
            if (index >= list.Count)
            {
                return list[index % list.Count];
            }
            else if (index < 0)
            {
                return list[index % list.Count + list.Count];
            }
            else
            {
                return list[index];
            }
        }

        

        private void DivideEtConquer()
        {
            Engine.hull.Clear();
            int min_x = 0, max_x = 0;
            for (int i = 1; i < Engine.points.Count; i++)
            {
                if (Engine.points[i].X < Engine.points[min_x].X)
                    min_x = i;
                if (Engine.points[i].X > Engine.points[max_x].X)
                    max_x = i;
            }
            Engine.hull.Add(Engine.points[min_x]);
            Engine.hull.Add(Engine.points[max_x]);
            Point A = Engine.hull[0];
            Point B = Engine.hull[1];

            List<Point> S1 = new List<Point>();
            List<Point> S2 = new List<Point>();


            foreach (Point point in Engine.points)
            {
                float side = Matematics.FindSide(A, B, point);
                if (side == -1) S1.Add(point);
                side = Matematics.FindSide(B, A, point);
                if (side == -1) S2.Add(point);
            }

            FindHull(S1, A, B);
            FindHull(S2, B, A);
        }

        private void button_test_Click(object sender, EventArgs e)
        {
            //this button is reserved for testing//

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void button_Colorful_Click(object sender, EventArgs e)
        {
            if (Engine.triangles.Count == 0)
            {
                return;
            }

            foreach (Triangle triangle in Engine.triangles)
            {
                Color color = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                triangle.Draw(color);
            }
            myGraphics.refreshGraph();
        }


        private void button_Disco_Click(object sender, EventArgs e)
        {
            if (!timer.Enabled)
            {
                timer.Start();

            }
            if (checkBox1.Checked)
            {
                timer.Stop();
            }

            //draw_polygon_Click(sender, e);
            //button_Triangulate_Click(sender, e);
            //button_QuickHull_Click(sender, e);
            button_Colorful_Click(sender, e);
            //button_QuickHull_Click(sender, e);
        }

        private void checkBox_Show_cordinates_CheckedChanged(object sender, EventArgs e)
        {
            DrawCordinates();
            myGraphics.refreshGraph();
        }

        private void button_Dual_Click(object sender, EventArgs e)
        {
            List<Triangle> triangles = Engine.triangles;
            List<int> indexes = new List<int>();
            if (triangles.Count == 0) return;
            indexes.Add(0);
            Dual(triangles[0], indexes);
            myGraphics.refreshGraph();
        }

        private void Dual(Triangle triangle, List<int> indexes)
        {
            Point weightCenter = triangle.GetWeightCenter();
            //afisare centru de greutate
            weightCenter.fillColor = Color.Coral; 
            weightCenter.draw(myGraphics.gfx);
            int neighbourContor = 0;
            for (int i = 0; i < Engine.triangles.Count; i++)
            {
                if (indexes.Contains(i)) continue;
                if (TrianglesHaveCommonSide(triangle, Engine.triangles[i]))
                {
                    indexes.Add(i);
                    Point newWeightCenter = Engine.triangles[i].GetWeightCenter();
                    Dual(Engine.triangles[i], indexes); //reapelare functie(recursivitate);
                    myGraphics.gfx.DrawLine(Pens.Black, weightCenter.X, weightCenter.Y, newWeightCenter.X, newWeightCenter.Y);
                    neighbourContor++;
                }
                if (neighbourContor == 2) break;
            }
        }

        private bool TrianglesHaveCommonSide(Triangle triangle1, Triangle triangle2)
        {
            int commonvertexcount = 0;
            if (triangle1.A == triangle2.A || triangle1.A == triangle2.B || triangle1.A == triangle2.C) commonvertexcount++;
            if (triangle1.B == triangle2.A || triangle1.B == triangle2.B || triangle1.B == triangle2.C) commonvertexcount++;
            if (triangle1.C == triangle2.A || triangle1.C == triangle2.B || triangle1.C == triangle2.C) commonvertexcount++;
            if (commonvertexcount == 2) return true;
            return false;
        }

        

        private void button_3color_Click(object sender, EventArgs e)
        {
            if (status == "triangulation completed")
            {

                List<Triangle> triangles = Engine.triangles;
                List<int> indexes = new List<int>();
                if (triangles.Count == 0) return;
                indexes.Add(0);

                triangles[0].A.fillColor = Color.Blue;
                triangles[0].B.fillColor = Color.Red;
                triangles[0].C.fillColor = Color.Green;

                threecolors(triangles[0], indexes);

                foreach (Triangle triangle in Engine.triangles)
                {
                    triangle.A.draw(myGraphics.gfx);
                    triangle.B.draw(myGraphics.gfx);
                    triangle.C.draw(myGraphics.gfx);
                }
                myGraphics.refreshGraph();
            }
        }

        public void threecolors(Triangle triangle, List<int> indexes)
        {

            if (triangle.A.fillColor == Color.Black)
            {
                foreach (Color color in Colors)
                {
                    if (triangle.B.fillColor != color && triangle.C.fillColor != color)
                    {
                        triangle.A.fillColor = color;
                        break;
                    }
                }
            }
            else if (triangle.B.fillColor == Color.Black)
            {
                foreach (Color color in Colors)
                {
                    if (triangle.A.fillColor != color && triangle.C.fillColor != color)
                    {
                        triangle.B.fillColor = color;
                        break;
                    }
                }
            }
            else if (triangle.C.fillColor == Color.Black)
            {
                foreach (Color color in Colors)
                {
                    if (triangle.B.fillColor != color && triangle.A.fillColor != color)
                    {
                        triangle.C.fillColor = color;
                        break;
                    }
                }
            }

            int neighbourContor = 0;
            for (int i = 0; i < Engine.triangles.Count; i++)
            {
                if (indexes.Contains(i)) continue;
                if (TrianglesHaveCommonSide(triangle, Engine.triangles[i]))
                {
                    indexes.Add(i);
                    threecolors(Engine.triangles[i], indexes);
                    neighbourContor++;
                }
                if (neighbourContor == 2) break;
            }

        }

       

        private void output_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_separatorLine_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

}
