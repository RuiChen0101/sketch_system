﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Rectangle : Shape
    {
        private const string SHAPE_NAME = "Rectangle";
        private double _x;
        private double _y;
        private double _width;
        private double _height;

        public Rectangle(Rectangle shape) : base(shape)
        {

        }

        public Rectangle()
        {
            base._shapeName = SHAPE_NAME;
        }

        //Draw
        public override void Draw(IGraphics graphics)
        {
            this.ConvertPointX();
            this.ConvertPointY();
            graphics.DrawRectangle(_x, _y, _width, _height);
        }

        //Clone
        public override Shape Clone()
        {
            return new Rectangle(this);
        }

        //ConvertPointX
        private void ConvertPointX()
        {
            if (_x2 < _x1)
            {
                _x = _x2;
                _width = _x1 - _x2;
            }
            else
            {
                _x = _x1;
                _width = _x2 - _x1;
            }
        }

        //ConvertPointY
        private void ConvertPointY()
        {
            if (_y2 < _y1)
            {
                _y = _y2;
                _height = _y1 - _y2;
            }
            else
            {
                _y = _y1;
                _height = _y2 - _y1;
            }
        }
    }
}
