using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    public class Shape
    {
        private const string SHAPE_NAME = "Default Shape";
        private const string SELECTED = "Selected : ";
        private const string LEFT_BRACKET = "(";
        private const string RIGHT_BRACKET = ")";
        private const string COMMA = ",";
        private const int SELECT_MARGIN = 10;
        protected string _shapeName;
        protected double _x1;
        protected double _y1;
        protected double _x2;
        protected double _y2;

        public Shape()
        {
            this._shapeName = SHAPE_NAME;
            this._x1 = 0;
            this._x2 = 0;
            this._y1 = 0;
            this._y2 = 0;
        }

        public Shape(Shape shape)
        {
            this._shapeName = shape._shapeName;
            this._x1 = shape._x1;
            this._x2 = shape._x2;
            this._y1 = shape._y1;
            this._y2 = shape._y2;
        }

        //Draw
        public virtual void Draw(IGraphics graphics)
        {

        }

        //Clone
        public virtual Shape Clone()
        {
            return new Shape(this);
        }

        //GetShapeInfo
        public string GetShapeInfo()
        {
            return SELECTED + _shapeName + LEFT_BRACKET + ((int)_x1).ToString() + COMMA + ((int)_y1).ToString() + COMMA + ((int)_x2).ToString() + COMMA + ((int)_y2).ToString() + RIGHT_BRACKET;
        }

        //DrawBorder
        public void DrawBorder(IGraphics graphics)
        {
            graphics.DrawDashBorder(_x1, _y1, _x2, _y2);
        }

        //IsShapeClick
        public bool IsShapeClick(double x, double y)
        {
            return (_x1 < x && _x2 > x) && (_y1 < y && _y2 > y);
        }

        //IsShapeResizeClick
        public bool IsShapeResizeClick(double x, double y)
        {
            return (_x2 - SELECT_MARGIN < x && _x2 + SELECT_MARGIN > x) && (_y2 - SELECT_MARGIN < y && _y2 + SELECT_MARGIN > y);
        }

        //GetShapeName
        public string GetShapeName()
        {
            return this._shapeName;
        }

        //SetResizePoint
        public virtual void SetResizePoint(double x, double y)
        {
            this._x2 = x;
            this._y2 = y;
        }

        //StartPoint
        public virtual void SetStartPoint(double x, double y)
        {
            this._x1 = x;
            this._y1 = y;
            this._x2 = x;
            this._y2 = y;
        }

        //OnDrag
        public virtual void OnDrag(double x, double y)
        {
            this._x2 = x;
            this._y2 = y;
        }

        //SetStopPoint
        public void SetStopPoint(double x, double y)
        {
            if (x > _x1)
                _x2 = x;
            else
            {
                _x2 = _x1;
                _x1 = x;
            }
            if (y > _y1)
                _y2 = y;
            else
            {
                _y2 = _y1;
                _y1 = y;
            }
        }
    }
}
