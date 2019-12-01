using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
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
            _graphics.DrawRectangle(Pens.Black, (float)x1, (float)y1, (float)width, (float)height);
        }
    }
}
