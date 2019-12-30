using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingModel
{
    public interface IGraphics
    {
        //ClearAll
        void ClearAll();

        //DrawLine
        void DrawLine(double x1, double y1, double x2, double y2);

        //DrawRectangle
        void DrawRectangle(double x1, double y1, double width, double height);

        //DrawHexagon
        void DrawHexagon(Tuple<double, double>[] points);

        //DrawHexagon
        void DrawDashBorder(double x1, double y1, double x2, double y2);
    }
}
