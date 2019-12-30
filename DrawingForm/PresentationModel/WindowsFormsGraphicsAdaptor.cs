using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using DrawingModel;

namespace DrawingForm.PresentationModel
{
    class WindowsFormsGraphicsAdaptor : IGraphics
    {
        private Graphics _graphics;
        public WindowsFormsGraphicsAdaptor(Graphics graphics)
        {
            this._graphics = graphics;
        }

        //ClearAll
        public void ClearAll()
        {

        }

        //DrawLine
        public void DrawLine(double x1, double y1, double x2, double y2)
        {
            _graphics.DrawLine(Pens.Black, (float)x1, (float)y1, (float)x2, (float)y2);
        }

        //DrawRectangle
        public void DrawRectangle(double x1, double y1, double width, double height)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle((int)x1, (int)y1, (int)width, (int)height);
            _graphics.FillRectangle(new SolidBrush(Color.Green), rectangle);
            _graphics.DrawRectangle(Pens.Black, rectangle);
        }

        //DrawHexagon
        public void DrawHexagon(Tuple<double, double>[] points)
        {
            const int EDGE = 6;
            Point[] shape = new Point[EDGE];
            for (int i = 0; i < EDGE; i++)
            {
                shape[i] = new Point((int)points[i].Item1, (int)points[i].Item2);
            }
            _graphics.FillPolygon(new SolidBrush(Color.RoyalBlue), shape);
            _graphics.DrawPolygon(Pens.Black, shape);
        }

        //DrawDashBorder
        public void DrawDashBorder(double x1, double y1, double x2, double y2)
        {
            const int POINT_OFFSET = 5;
            const int CIRCLE_RADIUS = 10;
            const int PEN_WIDTH = 2;
            Pen pen = new Pen(Color.Black, PEN_WIDTH);
            pen.DashStyle = DashStyle.Dash;
            _graphics.DrawRectangle(pen, (int)x1, (int)y1, (int)(x2 - x1), (int)(y2 - y1));
            _graphics.DrawEllipse(Pens.Black, (int)(x1 - POINT_OFFSET), (int)(y1 - POINT_OFFSET), CIRCLE_RADIUS, CIRCLE_RADIUS);
            _graphics.DrawEllipse(Pens.Black, (int)(x2 - POINT_OFFSET), (int)(y1 - POINT_OFFSET), CIRCLE_RADIUS, CIRCLE_RADIUS);
            _graphics.DrawEllipse(Pens.Black, (int)(x1 - POINT_OFFSET), (int)(y2 - POINT_OFFSET), CIRCLE_RADIUS, CIRCLE_RADIUS);
            _graphics.DrawEllipse(Pens.Black, (int)(x2 - POINT_OFFSET), (int)(y2 - POINT_OFFSET), CIRCLE_RADIUS, CIRCLE_RADIUS);
            _graphics.FillEllipse(new SolidBrush(Color.White), (int)(x1 - POINT_OFFSET), (int)(y1 - POINT_OFFSET), CIRCLE_RADIUS, CIRCLE_RADIUS);
            _graphics.FillEllipse(new SolidBrush(Color.White), (int)(x2 - POINT_OFFSET), (int)(y1 - POINT_OFFSET), CIRCLE_RADIUS, CIRCLE_RADIUS);
            _graphics.FillEllipse(new SolidBrush(Color.White), (int)(x1 - POINT_OFFSET), (int)(y2 - POINT_OFFSET), CIRCLE_RADIUS, CIRCLE_RADIUS);
            _graphics.FillEllipse(new SolidBrush(Color.White), (int)(x2 - POINT_OFFSET), (int)(y2 - POINT_OFFSET), CIRCLE_RADIUS, CIRCLE_RADIUS);
        }
    }
}
