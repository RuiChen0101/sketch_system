using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel
{
    class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        double _firstPointX;
        double _firstPointY;
        bool _isPressed = false;
        List<Line> _lines = new List<Line>();
        Line _hint = new Line();

        //PointerPressed
        public void PressPointer(double x, double y)
        {
            if (x > 0 && y > 0)
            {
                _firstPointX = x;
                _firstPointY = y;
                _hint.x1 = _firstPointX;
                _hint.y1 = _firstPointY;
                _isPressed = true;
            }
        }

        //PointerMoved
        public void MovePointer(double x, double y)
        {
            if (_isPressed)
            {
                _hint.x2 = x;
                _hint.y2 = y;
                NotifyModelChanged();
            }
        }

        //PointerReleased
        public void ReleasePointer(double x, double y)
        {
            if (_isPressed)
            {
                _isPressed = false;
                Line hint = new Line();
                hint.x1 = _firstPointX;
                hint.y1 = _firstPointY;
                hint.x2 = x;
                hint.y2 = y;
                _lines.Add(hint);
                NotifyModelChanged();
            }
        }

        //Clear
        public void Clear()
        {
            _isPressed = false;
            _lines.Clear();
            NotifyModelChanged();
        }

        //Draw
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Line aLine in _lines)
                aLine.Draw(graphics);
            if (_isPressed)
                _hint.Draw(graphics);
        }

        //NotifyModelChanged
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }
    }
}
