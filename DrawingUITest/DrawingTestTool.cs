using Microsoft.VisualStudio.TestTools.UITesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingUITest
{
    class DrawingTestTool
    {
        private static string CANVAS_NAME = "canvas";
        //DrawRectangle
        public static void MouseDraw(int x1, int y1, int x2, int y2)
        {
            UITestControl canvas = Robot.FindPanel(CANVAS_NAME);
            Mouse.StartDragging(canvas, new Point(x1, y1));
            Mouse.StopDragging(canvas, new Point(x2, y2));
        }

        //MouseClick
        public static void MouseClick(int x, int y)
        {
            UITestControl canvas = Robot.FindPanel(CANVAS_NAME);
            Mouse.Click(canvas, new Point(x, y));
        }
    }
}