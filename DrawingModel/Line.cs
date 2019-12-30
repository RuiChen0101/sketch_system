using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Line : Shape
    {
        private const string SHAPE_NAME = "Line";
        protected double _drawX1;
        protected double _drawY1;
        protected double _drawX2;
        protected double _drawY2;

        public Line(Line shape) : base(shape)
        {
            this._drawX1 = shape._drawX1;
            this._drawX2 = shape._drawX2;
            this._drawY1 = shape._drawY1;
            this._drawY2 = shape._drawY2;
        }

        public Line()
        {
            base._shapeName = SHAPE_NAME;
        }

        //Draw
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(_drawX1, _drawY1, _drawX2, _drawY2);
        }

        //Clone
        public override Shape Clone()
        {
            return new Line(this);
        }

        //SetResizePoint
        public override void SetResizePoint(double x, double y)
        {
            if (_drawX2 == _x2 && _drawY2 == _y2)
            {
                _drawX2 = x;
                _drawY2 = y;
            }
            else if (_drawX2 == _x2 && _drawY1 == _y2)
            {
                _drawX2 = x;
                _drawY1 = y;
            }
            else
            {
                _drawX1 = x;
                _drawY2 = y;
            }
            base.SetResizePoint(x, y);
        }

        //SetStartPoint
        public override void SetStartPoint(double x, double y)
        {
            _drawX1 = x;
            _drawY1 = y;
            base.SetStartPoint(x, y);
        }

        //SetStartPoint
        public override void OnDrag(double x, double y)
        {
            _drawX2 = x;
            _drawY2 = y;
            base.OnDrag(x, y);
        }
    }
}
