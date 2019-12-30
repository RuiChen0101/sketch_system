using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingModel
{
    class Hexagon : Shape
    {
        private const string SHAPE_NAME = "Hexagon";
        private const int EDGE = 6;
        private const int DIVIDER = 2;
        private Tuple<double,double>[] _points = new Tuple<double, double>[EDGE];

        public Hexagon(Hexagon shape) : base(shape)
        {

        }

        public Hexagon()
        {
            base._shapeName = SHAPE_NAME;
        }

        //Draw
        public override void Draw(IGraphics graphics)
        {
            this.ConvertPoints();
            graphics.DrawHexagon(_points);
        }

        //Clone
        public override Shape Clone()
        {
            return new Hexagon(this);
        }

        //ConvertPoint
        private void ConvertPoints()
        {
            const int ANGEL = 60;
            const float HALF_CIRCLE = 180f;
            double height = Math.Abs(_y1 - _y2);
            double width = Math.Abs(_x1 - _x2);
            double centerX = (_x1 < _x2 ? _x1 : _x2) + (width / DIVIDER);
            double centerY = (_y1 < _y2 ? _y1 : _y2) + (height / DIVIDER);
            double radius = (height < width ? height : width) / DIVIDER;
            for (int i = 0 ; i < EDGE ; i++)
            {
                _points[i] = new Tuple<double, double>(centerX + radius * (double)Math.Cos(i * ANGEL * Math.PI / HALF_CIRCLE), centerY + radius * (double)Math.Sin(i * ANGEL * Math.PI / HALF_CIRCLE));
            }
        }
    }
}
