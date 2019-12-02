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

        public enum Status
        {
            IDLE,
            LINE,
            RECTANGLE
        };

        Status _currentShape = Status.IDLE;
        bool _isPressed = false;
        List<Shape> _shapes = new List<Shape>();
        Shape _hint = null;

        //ChangeShape
        public void ChangeShape(Status status)
        {
            _currentShape = status;
            switch (status)
            {
                case Status.IDLE:
                    _hint = null;
                    break;
                case Status.LINE:
                    _hint = new Line();
                    break;
                case Status.RECTANGLE:
                    _hint = new Rectangle();
                    break;
            }
        }

        //PointerPressed
        public void PressPointer(double x, double y)
        {
            if (x > 0 && y > 0 && _hint != null)
            {
                _hint.x1 = x;
                _hint.y1 = y;
                _isPressed = true;
            }
        }

        //PointerMoved
        public void MovePointer(double x, double y)
        {
            if (_isPressed && _hint != null)
            {
                _hint.x2 = x;
                _hint.y2 = y;
                NotifyModelChanged();
            }
        }

        //PointerReleased
        public void ReleasePointer(double x, double y)
        {
            if (_isPressed && _hint != null)
            {
                _isPressed = false;
                _shapes.Add(_hint);
                ChangeShape(_currentShape);
                NotifyModelChanged();
            }
        }

        //Clear
        public void Clear()
        {
            _isPressed = false;
            _shapes.Clear();
            NotifyModelChanged();
        }

        //Draw
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Shape aShape in _shapes)
                aShape.Draw(graphics);
            if (_isPressed && _hint != null)
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
