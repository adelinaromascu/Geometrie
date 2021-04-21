using System.Drawing;
using System.Windows.Forms;

namespace Geome_0317
{
    public static class myGraphics
    {
        //GDI / GDI+
        public static Bitmap bmp;
        public static Graphics gfx;
        public static PictureBox display;
        public static int resx, resy;
        public static Color backColor = Color.AliceBlue;

        public static void initGraph(PictureBox Display)
        {
            display = Display;
            bmp = new Bitmap(display.Width, display.Height);
            gfx = Graphics.FromImage(bmp);
            resx = display.Width;
            resy = display.Height;
            clearGraph();
            refreshGraph();
        }

        public static void clearGraph()
        {
            gfx.Clear(backColor);
        }
        public static void refreshGraph()
        {
            display.Image = bmp;
        }
        //transformari de puncte pt zoom;
    }
}